using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class FileReader
    {
        private Level currentLevel;

        public void readMap(int lvlNumber = 1)
        {
            string fileName = lvlNumber + ".txt";
            string[] lines = System.IO.File.ReadAllLines(@"Levels\" + fileName);
            currentLevel = new Level(lines);
        }

        public Level getLevelObject()
        {
            return currentLevel;
        }
    }
}
