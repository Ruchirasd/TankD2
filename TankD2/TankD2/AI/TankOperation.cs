using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TankD2.Models;

namespace TankD2
{
    class TankOperation
    {
        public void MoveUp(Player myPlayer)
        {
            myPlayer.Y = (Int32.Parse(myPlayer.Y) + 1).ToString();
        }

        public void MoveDown(Player myPlayer)
        {
            myPlayer.Y = (Int32.Parse(myPlayer.Y) - 1).ToString();
        }

        public void MoveLeft(Player myPlayer)
        {
            myPlayer.X = (Int32.Parse(myPlayer.X) + 1).ToString();
        }

        public void MoveRight(Player myPlayer)
        {
            myPlayer.X = (Int32.Parse(myPlayer.X) - 1).ToString();
        }
        public void Shoot(Player myPlayer)
        {

        }

    }
}
