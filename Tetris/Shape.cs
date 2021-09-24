using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Shape
    {
        public bool[,] figureData;
        public Color color;
        private int currentFigureState;
        public int figureNumber;
        public int x, y;

        public Shape(Random rand, List<List<bool[,]>> figures, List<Color> possibleColors)
        {
            currentFigureState = 0;
            int randIndex = rand.Next(figures.Count);
            figureData = figures[randIndex][currentFigureState];
            figureNumber = randIndex;

            randIndex = rand.Next(possibleColors.Count);
            color = possibleColors[randIndex];

            x = 4; y = 0;
        }

        public Shape(Shape shape)
        {
            figureData = shape.figureData;
            color = shape.color;
            currentFigureState = shape.currentFigureState;
            figureNumber = shape.figureNumber;
            x = shape.x;
            y = shape.y;
        }

        public void Rotate(List<bool[,]> figureStates)
        {
            currentFigureState = currentFigureState == figureStates.Count - 1 ? 0 : currentFigureState + 1;
            figureData = figureStates[currentFigureState];
        }

        public void RotateBack(List<bool[,]> figureStates)
        {
            currentFigureState = currentFigureState == 0 ? figureStates.Count - 1 : currentFigureState - 1;
            figureData = figureStates[currentFigureState];
        }
    }
}
