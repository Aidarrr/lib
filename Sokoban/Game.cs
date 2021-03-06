using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Game
    {
        private Level currentLevel;
        private char[,] map;
        private Point keeperPosition;
        private List<Tuple<char[,], Point>> previousSteps;
        int cntBoxesOnLocation = 0;
        public int movesCount = 0;

        public Game(Level currentLevel)
        {
            this.currentLevel = currentLevel;
            map = currentLevel.getMap();
            keeperPosition = currentLevel.keeperPosition;
            previousSteps = new List<Tuple<char[,], Point>>();
        }

        public void move(int deltaX, int deltaY)
        {
            Point newPosition = new Point(keeperPosition.X + deltaX, keeperPosition.Y + deltaY);
            char[,] previousStep = new char[map.GetLength(0), map.GetLength(1)];
            Array.Copy(map, previousStep, map.GetLength(0) * map.GetLength(1));

            if (map[newPosition.X, newPosition.Y] == currentLevel.boxSym)
            {
                Point boxCurrentPos = newPosition;
                Point newBoxPosition = new Point(boxCurrentPos.X + deltaX, boxCurrentPos.Y + deltaY);

                if (isBoxMovable(boxCurrentPos, deltaX, deltaY))
                {
                    if(map[newBoxPosition.X, newBoxPosition.Y] == currentLevel.emptySym)
                    {
                        map[boxCurrentPos.X, boxCurrentPos.Y] = currentLevel.emptySym;
                        map[newBoxPosition.X, newBoxPosition.Y] = currentLevel.boxSym;
                    }
                    else if(map[newBoxPosition.X, newBoxPosition.Y] == currentLevel.goalSym)
                    {
                        map[boxCurrentPos.X, boxCurrentPos.Y] = currentLevel.emptySym;
                        map[newBoxPosition.X, newBoxPosition.Y] = currentLevel.setBox;
                        cntBoxesOnLocation++;
                    }
                }
            }
            else if (map[newPosition.X, newPosition.Y] == currentLevel.setBox)
            {
                Point boxCurrentPos = newPosition;
                Point newBoxPosition = new Point(boxCurrentPos.X + deltaX, boxCurrentPos.Y + deltaY);

                if (isBoxMovable(boxCurrentPos, deltaX, deltaY))
                {
                    if (map[newBoxPosition.X, newBoxPosition.Y] == currentLevel.emptySym)
                    {
                        map[boxCurrentPos.X, boxCurrentPos.Y] = currentLevel.goalSym;
                        map[newBoxPosition.X, newBoxPosition.Y] = currentLevel.boxSym;
                        cntBoxesOnLocation--;
                    }
                    else if (map[newBoxPosition.X, newBoxPosition.Y] == currentLevel.goalSym)
                    {
                        map[boxCurrentPos.X, boxCurrentPos.Y] = currentLevel.goalSym;
                        map[newBoxPosition.X, newBoxPosition.Y] = currentLevel.setBox;
                    }
                }
            }

            if(map[newPosition.X, newPosition.Y] == currentLevel.emptySym || map[newPosition.X, newPosition.Y] == currentLevel.goalSym)
            {
                previousSteps.Add(new Tuple<char[,], Point>(previousStep, keeperPosition));

                map[keeperPosition.X, keeperPosition.Y] = currentLevel.keeperBG;
                keeperPosition.X += deltaX;
                keeperPosition.Y += deltaY;
                currentLevel.keeperBG = map[keeperPosition.X, keeperPosition.Y];
                map[keeperPosition.X, keeperPosition.Y] = currentLevel.keeperSym;
                movesCount++;
            }
        }

        public bool isBoxMovable(Point oldBoxPosition, int deltaX, int deltaY)
        {
            Point newPosition = new Point(oldBoxPosition.X + deltaX, oldBoxPosition.Y + deltaY);

            if(map[newPosition.X, newPosition.Y] == currentLevel.emptySym || map[newPosition.X, newPosition.Y] == currentLevel.goalSym)
            {
                return true;
            }

            return false;
        }

        public bool isWon()
        {
            if(cntBoxesOnLocation == currentLevel.boxCount)
            {
                return true;
            }

            return false;
        }

        public void makeMoveBackward()
        {
            int listSize = previousSteps.Count;

            if (listSize > 0 && movesCount > 0)
            {
                map = previousSteps[listSize - 1].Item1;
                currentLevel.setMap(map);
                keeperPosition = previousSteps[listSize - 1].Item2;
                previousSteps.RemoveAt(listSize - 1);
                movesCount--;
            }
        }
    }
}
