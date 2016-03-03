using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankD2.Models
{
    class Player: CanvasStructure
    {
        String direction;
        String name;
        int status; //status=1 when this is our player otherwise it is zero
        int whethershot;
        int health;
        int coins;
        int points;
    
        public Player(int status,String name,String x, String y, String direction) : base(x, y) {
            this.direction = direction;
            this.name = name;
            this.status = status;

        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }

        public int Coins
        {
            get
            {
                return coins;
            }

            set
            {
                coins = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }

        public int Whethershot
        {
            get
            {
                return whethershot;
            }

            set
            {
                whethershot = value;
            }
        }
    }
}
