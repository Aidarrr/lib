#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"
#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>
#include"Constants.h"

class SnakeCell;

class Food {
private:
	bool isEaten;
	int x, y;
	uint16_t foodIncreaseSize;

	bool isFoodOnSnake(std::vector<SnakeCell>& snake);

public:
	Food();

	int GetX();
	int GetY();
	uint16_t getFoodSize();

	bool GetFoodState();
	void SetFoodState(bool state);
	void CreateFood(std::vector<SnakeCell>& snake);
};

class SnakeCell {
public:
	int x, y;
	Direction direction;
	SnakeCell(int x, int y, Direction direction);
	SnakeCell();
};

class Snake {
private:
	std::vector<SnakeCell> snake;
	std::vector<RotatePoint> rotatePoints;

	void lengthenSnake();

public:
	Snake();

	std::vector<SnakeCell>& GetSnake();

	bool isSnakeAteFood(Food& food);

	void EatFood(Food& food);

	void RotateHead(Direction direction);

	void rotateSnake();

	void Move();
};

class Grid {
private:
	std::vector<std::vector<uint32_t>> gridData;
	uint32_t snakeColor;
	uint32_t foodColor;
	uint32_t bgColor;
	uint32_t snakeHeadColor;

public:
	Grid();

	Grid(uint32_t snakeColor, uint32_t foodColor, uint32_t bgColor);

	std::vector<std::vector<uint32_t>>& GetGridData();

	void FillGrid(Food& food, std::vector<SnakeCell>& snake);

	void ClearGrid();
};


bool Food::isFoodOnSnake(std::vector<SnakeCell>& snake) {
	for (size_t i = 0; i < snake.size(); i++) {
		if ((snake[i].x >= x && snake[i].x <= x + foodIncreaseSize) && (snake[i].y >= y && snake[i].y <= y + foodIncreaseSize)) {
			return true;
		}
	}
	return false;
}

Food::Food() {
	foodIncreaseSize = 1;
	isEaten = false;
}

int Food::GetX() {
	return x;
}
int Food::GetY() {
	return y;
}

uint16_t Food::getFoodSize()
{
	return foodIncreaseSize;
}

bool Food::GetFoodState() {
	return isEaten;
}
void Food::SetFoodState(bool state) {
	isEaten = state;
}
void Food::CreateFood(std::vector<SnakeCell>& snake) {
	do {
		x = rand() % (screenW - foodIncreaseSize);
		y = rand() % (screenH - foodIncreaseSize);
	} while (isFoodOnSnake(snake));
	isEaten = false;
}



SnakeCell::SnakeCell(int x, int y, Direction direction) {
	this->x = x;
	this->y = y;
	this->direction = direction;
}
SnakeCell::SnakeCell() { }

void Snake::lengthenSnake() {
	SnakeCell tail = snake[snake.size() - 1];
	switch (tail.direction) {
	case Direction::UP:
		snake.push_back(SnakeCell(tail.x, tail.y + 1, tail.direction));
		break;
	case Direction::DOWN:
		snake.push_back(SnakeCell(tail.x, tail.y - 1, tail.direction));
		break;
	case Direction::RIGHT:
		snake.push_back(SnakeCell(tail.x - 1, tail.y, tail.direction));
		break;
	case Direction::LEFT:
		snake.push_back(SnakeCell(tail.x + 1, tail.y, tail.direction));
		break;
	case Direction::CALM:
		snake.push_back(SnakeCell(tail.x, tail.y + 1, tail.direction));
		break;
	}
}

Snake::Snake() {
	SnakeCell head;
	head.x = rand() % screenW;
	head.y = rand() % screenH;
	head.direction = Direction::CALM;

	snake.push_back(head);
}

std::vector<SnakeCell>& Snake::GetSnake() {
	return snake;
}

bool Snake::isSnakeAteFood(Food& food) {
	int x = food.GetX();
	int y = food.GetY();
	uint16_t foodSize = food.getFoodSize();

	if ((snake[0].x >= x && snake[0].x <= x + foodSize) && (snake[0].y >= y && snake[0].y <= y + foodSize)){
		return true;
	}
	return false;
}

void Snake::EatFood(Food& food) {
	food.SetFoodState(true);
	lengthenSnake();
}

void Snake::RotateHead(Direction direction) {

	if (snake.size() > 1) {

		if ((direction == Direction::DOWN && snake[1].y == snake[0].y + 1) ||
			(direction == Direction::UP && snake[1].y == snake[0].y - 1) ||
			(direction == Direction::LEFT && snake[1].x == snake[0].x - 1) ||
			(direction == Direction::RIGHT && snake[1].x == snake[0].x + 1))
		{
			return;
		}
		RotatePoint rp;
		rp.rotateTo = direction;
		rp.x = snake[0].x; rp.y = snake[0].y;

		rotatePoints.push_back(rp);
	}
	snake[0].direction = direction;
}

void Snake::rotateSnake() {
	for (size_t i = 1; i < snake.size(); i++) {
		for (size_t j = 0; j < rotatePoints.size(); j++) {
			if (snake[i].x == rotatePoints[j].x && snake[i].y == rotatePoints[j].y) {
				snake[i].direction = rotatePoints[j].rotateTo;
				if (i == snake.size() - 1) rotatePoints.erase(rotatePoints.begin() + j);
				break;
			}
		}
	}
}

void Snake::Move() {

	for (size_t i = 0; i < snake.size(); i++) {
		switch (snake[i].direction) {
		case Direction::UP:
			snake[i].y--;
			break;
		case Direction::DOWN:
			snake[i].y++;
			break;
		case Direction::RIGHT:
			snake[i].x++;
			break;
		case Direction::LEFT:
			snake[i].x--;
			break;
		case Direction::CALM:
			break;
		}

		if (snake[i].x >= screenW - 1) {
			snake[i].x = 0;
		}
		else if (snake[i].x < 0) {
			snake[i].x = screenW - 1;
		}

		if (snake[i].y >= screenH - 1) {
			snake[i].y = 0;
		}
		else if (snake[i].y < 0) {
			snake[i].y = screenH - 1;
		}
	}
}

Grid::Grid() {
	snakeColor = 0xFF4CB122;
	foodColor = 0xFF0000FF;
	bgColor = 0xFFFFFFFF;
	snakeHeadColor = 0xFF000000;
	std::vector<uint32_t> row;

	for (size_t i = 0; i < screenH; i++) {
		for (size_t j = 0; j < screenW; j++) {
			row.push_back(bgColor);
		}
		gridData.push_back(row);
	}
}

Grid::Grid(uint32_t snakeColor, uint32_t foodColor, uint32_t bgColor) {
	this->snakeColor = snakeColor;
	this->foodColor = foodColor;
	this->bgColor = bgColor;

	Grid();
}

std::vector<std::vector<uint32_t>>& Grid::GetGridData() {
	return gridData;
}

void Grid::FillGrid(Food& food, std::vector<SnakeCell>& snake) {
	gridData[snake[0].y][snake[0].x] = snakeHeadColor;
	for (size_t i = 1; i < snake.size(); i++) {
		gridData[snake[i].y][snake[i].x] = snakeColor;
	}

	for (size_t x = food.GetX(); x <= food.getFoodSize() + food.GetX(); x++){
		for (size_t y = food.GetY(); y <= food.getFoodSize() + food.GetY(); y++){
			gridData[y][x] = foodColor;
		}
	}
	
}

void Grid::ClearGrid() {
	for (size_t i = 0; i < screenH; i++) {
		for (size_t j = 0; j < screenW; j++) {
			gridData[i][j] = bgColor;
		}
	}
}


class SnakeGame : public olc::PixelGameEngine
{
public:
	SnakeGame()
	{
		sAppName = "Snake";
	}

private:
	Grid grid;
	Snake snake;
	Food food;

public:
	bool OnUserCreate() override
	{
		food.CreateFood(snake.GetSnake());
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		if (GetKey(olc::Key::RIGHT).bPressed) {
			snake.RotateHead(Direction::RIGHT);
		}
		else if (GetKey(olc::Key::LEFT).bPressed) {
			snake.RotateHead(Direction::LEFT);
		}
		else if (GetKey(olc::Key::UP).bPressed) {
			snake.RotateHead(Direction::UP);
		}
		else if (GetKey(olc::Key::DOWN).bPressed) {
			snake.RotateHead(Direction::DOWN);
		}

		snake.Move();
		snake.rotateSnake();

		if (snake.isSnakeAteFood(food)) {
			snake.EatFood(food);
			food.CreateFood(snake.GetSnake());
		}

		grid.ClearGrid();
		grid.FillGrid(food, snake.GetSnake());

		std::vector<std::vector<uint32_t>> gridData = grid.GetGridData();
		for (int x = 0; x < screenW; x++)
			for (int y = 0; y < screenH; y++) {
				Draw(x, y, olc::Pixel(gridData[y][x]));
			}

		Sleep(14);
		return true;
	}
};

int main()
{
	SnakeGame demo;
	if (demo.Construct(screenW, screenH, 4*4, 4*4))
		demo.Start();

	return 0;
}