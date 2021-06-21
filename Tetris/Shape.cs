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
        private bool[,] figureData;
        private Color color;
        private int currentFigureState;
        private int figureNumber;

        public Shape(Random rand, List<List<bool[,]>> figures, List<Color> possibleColors)
        {
            currentFigureState = 0;
            int randIndex = rand.Next(figures.Count);
            figureData = figures[randIndex][currentFigureState];
            figureNumber = randIndex;

            randIndex = rand.Next(possibleColors.Count);
            color = possibleColors[randIndex];
        }

        public void Rotate(List<bool[,]> figureStates)
        {
            currentFigureState = currentFigureState == figureStates.Count - 1 ? 0 : currentFigureState + 1;
            figureData = figureStates[currentFigureState];
        }
    }
}
