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
    
        public Player(String name,String x, String y, String direction) : base(x, y) {
            this.direction = direction;
            this.name = name;

        }

    }
}
