﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankD2.Models
{
    public class CanvasStructure
    {
        private String x;
        private String y;

        public CanvasStructure() { }

        public CanvasStructure(String x, String y)
        {
            this.x = x;
            this.y = y;
        }

        public string X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public string Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}
