package kiefac;

import java.awt.*;
import java.lang.reflect.Array;
import java.util.ArrayList;

import javax.swing.SwingUtilities;

class vec3d
{
	public double x, y, z;
	public vec3d(double x, double y, double z)
	{
		this.x = x; this.y = y; this.z = z;
	}
	public vec3d()
	{

	}
}

class triangle
{
	public ArrayList<vec3d> tri;

	public triangle()
	{
		tri = new ArrayList<>();
		tri.add(new vec3d()); tri.add(new vec3d()); tri.add(new vec3d());
	}

	public triangle(vec3d vec1, vec3d vec2, vec3d vec3)
	{
		tri = new ArrayList<vec3d>();
		tri.add(vec1);
		tri.add(vec2);
		tri.add(vec3);
	}
}

class Cube
{
	public ArrayList<triangle> cubeCoord;
	public Cube(triangle tr1, triangle tr2, triangle tr3, triangle tr4, triangle tr5, triangle tr6,
				triangle tr7, triangle tr8, triangle tr9, triangle tr10, triangle tr11, triangle tr12)
	{
		cubeCoord = new ArrayList<triangle>();
		cubeCoord.add(tr1);
		cubeCoord.add(tr2);
		cubeCoord.add(tr3);
		cubeCoord.add(tr4);
		cubeCoord.add(tr5);
		cubeCoord.add(tr6);
		cubeCoord.add(tr7);
		cubeCoord.add(tr8);
		cubeCoord.add(tr9);
		cubeCoord.add(tr10);
		cubeCoord.add(tr11);
		cubeCoord.add(tr12);
	}
}

public class BaristaExample extends Barista
{
	static  double w = 16.0, h = 9.0;
	static  double theta = Math.PI / 2;
	static double rotAngle = 0.0;
	static double a = ( h / w );
	static  double F = 1 / Math.tan(theta / 2);
	static  double Znear = 0.1;
	static double Zfar = 1000.0;
	static double q = (Zfar/(Zfar - Znear));
	static Cube cube;
	static int width, height;
	static double[][] projMatrix =	{{a * F,0,0,0 }, {0, F, 0, 0}, {0,0,q, 1}, {0, 0, -Znear * q, 0}};
	static double[][] matRotZ;
	static double[][] matRotX;

	public static void MultiplyMatrixVector(vec3d i, vec3d o, double[][] m)
	{
		o.x = i.x * m[0][0] + i.y * m[1][0] + i.z * m[2][0] + m[3][0];
		o.y = i.x * m[0][1] + i.y * m[1][1] + i.z * m[2][1] + m[3][1];
		o.z = i.x * m[0][2] + i.y * m[1][2] + i.z * m[2][2] + m[3][2];
		double w = i.x * m[0][3] + i.y * m[1][3] + i.z * m[2][3] + m[3][3];

		if (w != 0.0f) {
			o.x /= w;
			o.y /= w;
			o.z /= w;
		}
	}

	public void DrawTriangle(vec3d vec1, vec3d vec2, vec3d vec3, int offset, Color color)
	{

		drawLine((int)vec1.x + offset, (int)vec1.y + offset, (int)vec2.x + offset, (int)vec2.y + offset, color);
		drawLine((int)vec2.x + offset, (int)vec2.y + offset, (int)vec3.x + offset, (int)vec3.y + offset, color);
		drawLine((int)vec3.x + offset, (int)vec3.y + offset, (int)vec1.x + offset, (int)vec1.y + offset, color);
	}

	@Override
	public boolean onUserCreate()
	{
		gameName = "Barista Example";
		width = screenWidth;
		height = screenHeight;
		matRotZ = new double[4][4];
		matRotX = new double[4][4];


		cube = new Cube
				(
						//SOUTH
						new triangle(new vec3d(0.0,0.0,0.0), new vec3d(0.0,1.0,0.0), new vec3d(1.0,1.0,0.0)),
						new triangle(new vec3d(0.0,0.0,0.0), new vec3d(1.0,1.0,0.0), new vec3d(1.0,0.0,0.0)),

						//EAST
						new triangle(new vec3d(1.0,0.0,0.0), new vec3d(1.0,1.0,0.0), new vec3d(1.0,1.0,1.0)),
						new triangle(new vec3d(1.0,0.0,0.0), new vec3d(1.0,1.0,1.0), new vec3d(1.0,0.0,1.0)),

						//NORTH
						new triangle(new vec3d(1.0,0.0,1.0), new vec3d(1.0,1.0,1.0), new vec3d(0.0,1.0,1.0)),
						new triangle(new vec3d(1.0,0.0,1.0), new vec3d(0.0,1.0,1.0), new vec3d(0.0,0.0,1.0)),

						//WEST
						new triangle(new vec3d(0.0, 0.0, 1.0), new vec3d( 0.0, 1.0, 1.0), new vec3d( 0.0, 1.0, 0.0)),
						new triangle(new vec3d(0.0, 0.0, 1.0), new vec3d( 0.0, 1.0, 0.0), new vec3d(  0.0, 0.0, 0.0)),

						//TOP
						new triangle(new vec3d(0.0, 1.0, 0.0), new vec3d(0.0, 1.0, 1.0), new vec3d(1.0,1.0,1.0)),
						new triangle(new vec3d(0.0f, 1.0f, 0.0f), new vec3d( 1.0f, 1.0f, 1.0f), new vec3d(1.0f, 1.0f, 0.0f)),

						//BOTTOM
						new triangle(new vec3d(1.0, 0.0, 1.0), new vec3d(0.0,0.0,0.0), new vec3d(0.0,0.0,0.0)),
						new triangle(new vec3d(1.0,0.0,1.0), new vec3d(0.0,0.0,0.0), new vec3d(1.0,0.0,0.0))
				);

		return true;
	}

	@Override
	public boolean onUserUpdate(double frameTime)
	{
		fill(0, 0, width, height, Color.BLACK);
		rotAngle += 1.0 * frameTime;

		// Rotation Z
		matRotZ[0][0] = Math.cos(rotAngle);
		matRotZ[0][1] = Math.sin(rotAngle);
		matRotZ[1][0] = -Math.sin(rotAngle);
		matRotZ[1][1] = Math.cos(rotAngle);
		matRotZ[2][2] = 1;
		matRotZ[3][3] = 1;

		// Rotation X
		matRotX[0][0] = 1;
		matRotX[1][1] = Math.cos(rotAngle * 0.5);
		matRotX[1][2] = Math.sin(rotAngle * 0.5);
		matRotX[2][1] = -Math.sin(rotAngle * 0.5);
		matRotX[2][2] = Math.cos(rotAngle * 0.5);
		matRotX[3][3] = 1;

		for (triangle tri : cube.cubeCoord)
		{
			triangle triRotatedZ = new triangle();
			triangle triRotatedZX = new triangle();
			triangle triTranslated;
			triangle triProjected = new triangle();

			MultiplyMatrixVector(tri.tri.get(0), triRotatedZ.tri.get(0), matRotZ);
			MultiplyMatrixVector(tri.tri.get(1), triRotatedZ.tri.get(1), matRotZ);
			MultiplyMatrixVector(tri.tri.get(2), triRotatedZ.tri.get(2), matRotZ);

			MultiplyMatrixVector(triRotatedZ.tri.get(0), triRotatedZX.tri.get(0), matRotX);
			MultiplyMatrixVector(triRotatedZ.tri.get(1), triRotatedZX.tri.get(1), matRotX);
			MultiplyMatrixVector(triRotatedZ.tri.get(2), triRotatedZX.tri.get(2), matRotX);

			triTranslated = triRotatedZX;
			triTranslated.tri.get(0).z += 3.0;
			triTranslated.tri.get(1).z += 3.0;
			triTranslated.tri.get(2).z += 3.0;

			MultiplyMatrixVector(triTranslated.tri.get(0), triProjected.tri.get(0), projMatrix);
			MultiplyMatrixVector(triTranslated.tri.get(1), triProjected.tri.get(1), projMatrix);
			MultiplyMatrixVector(triTranslated.tri.get(2), triProjected.tri.get(2), projMatrix);

			triTranslated.tri.get(0).x += 1.0; triTranslated.tri.get(0).y += 1.0;
			triTranslated.tri.get(1).x += 1.0; triTranslated.tri.get(1).y += 1.0;
			triTranslated.tri.get(2).x += 1.0; triTranslated.tri.get(2).y += 1.0;
			triTranslated.tri.get(0).x *= 0.2 * width; triTranslated.tri.get(0).y *= 0.2 * height;
			triTranslated.tri.get(1).x *= 0.2 * width; triTranslated.tri.get(1).y *= 0.2 * height;
			triTranslated.tri.get(2).x *= 0.2 * width; triTranslated.tri.get(2).y *= 0.2 * height;

			DrawTriangle(triTranslated.tri.get(0), triTranslated.tri.get(1), triTranslated.tri.get(2), 100, Color.WHITE);
		}

		return true;
	}
	
	public static void main(String[] args)
	{
		SwingUtilities.invokeLater(new Runnable( )
		{
			public void run() {
				BaristaExample example = new BaristaExample();
				example.constructFrame(256, 240, 4, 4);
				example.start();
			}
		});
	}
}
