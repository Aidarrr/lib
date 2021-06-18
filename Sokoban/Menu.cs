using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Menu
    {
        public LevelBoard createLevelBoard(int levelCount)
        {
            return new LevelBoard(levelCount);
        }
    }
}
