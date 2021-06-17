using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class ImageContainer
    {
        public Image boxImage;
        public Image setBoxImage;
        public Image keeperImage;
        public Image locationImage;
        public Image wallImage;
        public Image emptyImage;

        string boxPath = "box.gif";
        string setBoxPath = "box_on_location.gif";
        string keeperPath = "keeper.gif";
        string locationPath = "location.gif";
        string wallPath = "wall.gif";
        string emptyPath = "empty.gif";

        public ImageContainer()
        {
            boxImage = Image.FromFile(boxPath);
            setBoxImage = Image.FromFile(setBoxPath);
            keeperImage = Image.FromFile(keeperPath);
            locationImage = Image.FromFile(locationPath);
            wallImage = Image.FromFile(wallPath);
            emptyImage = Image.FromFile(emptyPath);
        }

        public Image getImageByChar(char symbol, Level level)
        {
            if (symbol == level.boxSym)
            {
                return boxImage;
            }
            else if (symbol == level.setBox)
            {
                return setBoxImage;
            }
            else if (symbol == level.keeperSym)
            {
                return keeperImage;
            }
            else if (symbol == level.goalSym)
            {
                return locationImage;
            }
            else if (symbol == level.wallSym)
            {
                return wallImage;
            }

            return emptyImage;
        }
    }
}
