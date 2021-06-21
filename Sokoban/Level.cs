using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Level
    {
        private char[,] map;
        public char keeperSym = '@', emptySym = ' ', boxSym = '*', goalSym = '.', setBox = 's', wallSym = 'X';
        public char keeperBG = ' ';
        public Point keeperPosition;
        public int boxCount = 0;

        public Level(char[,] map)
        {
            this.map = map;
        }

        public char[,] getMap()
        {
            return map;
        }

        public void setMap(char[,] map)
        {
            this.map = map;
        }

        public Level(string[] lines)
        {
            map = new char[lines[0].Length, lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[j, i] = lines[i][j];

                    if (map[j, i] == '*')
                    {
                        boxCount++;
                    }
                    else if (map[j, i] == '@')
                    {
                        keeperPosition = new Point(j, i);
                    }
                }
            }
        }
    }
}
