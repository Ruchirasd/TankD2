using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TankD2.Controllers;
using TankD2.Models;

namespace TankD2.AI
{
    class MainAI
    {
        //GameCanvas gamecanvas = new GameCanvas();
        //CanvasStructure[,] cellObjects = GameCanvas.cellObjects;
        CanvasStructure[,] cellObjects;

        public void move(CanvasStructure[,] cellobjects)
        {
            this.cellObjects = cellobjects;
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {

                    
                }
            }
        }
        
    }
}
