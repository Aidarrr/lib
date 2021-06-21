using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class GameInfo
    {
        private DateTime start;

        public string getLabelForLevel(FileReader fileReader)
        {
            return "Уровень № " + fileReader.lvlNumber;
        }

        public string getLabelForMovesCount(Game game)
        {
            return "Ходы: " + game.movesCount;
        }

        public void updateStopWatch()
        {
            start = DateTime.Now;
        }

        public string getLabelForTime()
        {
            TimeSpan duration = DateTime.Now - start;
            
            return "Время: " + duration.ToString(@"mm\:ss");
        }
    }
}
