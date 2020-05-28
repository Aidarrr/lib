#include <algorithm>
#include "olcPixelGameEngine.h"
#include "escapi.h"
#define OLC_PGE_APPLICATION

int nFrameWidth = 320;
int nFrameHeight = 240;

struct frame
{
	float* pixels = nullptr;

	frame()
	{
		pixels = new float[nFrameWidth * nFrameHeight];
	}

	~frame()
	{
		delete[] pixels;
	}

	float get(int x, int y)
	{
		if (x >= 0 && x < nFrameWidth && y >= 0 && y < nFrameHeight)
		{
			return pixels[y * nFrameWidth + x];
		}
		else
			return 0.0f;
	}

	float set(int x, int y, float p)
	{
		if (x >= 0 && x < nFrameWidth && y >= 0 && y < nFrameHeight)
		{
			pixels[y * nFrameWidth + x] = p;
		}
	}


	void operator=(const frame &f)
	{
		memcpy(this->pixels, f.pixels, nFrameWidth * nFrameHeight * sizeof(float));
	}
};

class WIP_ImageProcessing : public olc::PixelGameEngine
{
public:
	WIP_ImageProcessing()
	{
		sAppName = "WIP_ImageProcessing";
	}

	union RGBint
	{
		int rgb;
		unsigned char c[4];
	};

	int nCameras = 0;
	SimpleCapParams capture;

public:
	bool OnUserCreate() override
	{
		nCameras = setupESCAPI();
		if (nCameras == 0) return false;
		capture.mWidth = nFrameWidth;
		capture.mHeight = nFrameHeight;
		capture.mTargetBuf = new int[nFrameHeight * nFrameWidth];
		if (initCapture(0, &capture) == 0) return false;
		return true;
	}

	void DrawFrame(frame &f, int x, int y)
	{
		for (int i = 0; i < nFrameWidth; i++)
		{
			for (int j = 0; j < nFrameHeight; j++)
			{
				int c = (int)std::min(std::max(0.0f, f.pixels[j*nFrameWidth + i] * 255.0f), 255.0f);
				Draw(x + i, y + j, olc::Pixel(c, c, c));
				
			}
		}
	}

	enum ALGORITHM
	{
		THRESHOLD, MOTION, LOWPASS, CONVOLUTION, SOBEL, MORPHO, MEDIAN, ADAPTIVE,
	};

	enum MORPHOP
	{
		DILATION,
		EROSION,
		EDGE
	};

	frame input, output, prev_input, activity, threshold;

	ALGORITHM algo = THRESHOLD;
	MORPHOP morph = DILATION;
	int nMorphCount = 1;

	bool OnUserUpdate(float fElapsedTime) override
	{
		//capturing webcam image
		prev_input = input;
		doCapture(0); while (isCaptureDone(0) == 0) {}
		for (int y = 0; y < capture.mHeight; y++)
		{
			for (int x = 0; x < capture.mWidth; x++)
			{
				RGBint col;
				int id = y * capture.mWidth + x;
				col.rgb = capture.mTargetBuf[id];
				input.pixels[y * nFrameWidth + x] = (float)col.c[1] / 255.0f;
			}
		}


		return true;
	}
};


int main()
{
	WIP_ImageProcessing demo;
	if (demo.Construct(670, 460, 2, 2))
		demo.Start();

	return 0;
}