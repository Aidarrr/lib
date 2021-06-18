using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class FileReader
    {
        private Level currentLevel;
        private int filesCount = 0;
        private string pathToLevelDirectory = @"Levels\";

        public Level getLevelObject()
        {
            return currentLevel;
        }

        public void readMap(int lvlNumber = 1)
        {
            string fileName = lvlNumber + ".txt";
            string[] lines = System.IO.File.ReadAllLines(pathToLevelDirectory + fileName);
            currentLevel = new Level(lines);
        }

        public int getLevelsCount()
        {
            filesCount = Directory.GetFiles(pathToLevelDirectory, "*", SearchOption.TopDirectoryOnly).Length;
            return filesCount;
        }
    }
}
