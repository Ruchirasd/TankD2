﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TankD2.Controllers;
using TankD2.Models;


namespace TankD2
{
    class MainAI
    {
        //GameCanvas gamecanvas = new GameCanvas();
        //CanvasStructure[,] cellObjects = GameCanvas.cellObjects;
        Connection connection;
        CanvasStructure[,] cellObjects;
        Player myTank;
        int myPlayerX;
        int myPlayerY;
        Type objectType;
        static int i = 0;

        public void startAI(object info) {
            Thread thread = new Thread(new ParameterizedThreadStart(runAI));
            thread.Start(info);
        
        }

        public void runAI(object info) {
            while (true)
            {
                connection = (Connection)info;
                connection.ConnectToServer("SHOOT#");
                Console.WriteLine("run AI");
                Thread.Sleep(1400);
            }
            

        
        }

        public void GetMyTankPosition(CanvasStructure[,] cellobjects)
        {
            this.cellObjects = cellobjects;
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    objectType = cellObjects[i, j].GetType();
                    if (objectType == typeof(Player))
                    {
                        Player player = (Player)cellObjects[i, j];
                        if (player.Status == 1)
                        {
                            myTank = player;
                            myPlayerX = i;
                            myPlayerY = j;
                        }

                    }
                }
            }
        }



        public void move(int myPlayerX, int myPlayerY,Player myTank)
        {
            TankOperation tankOp = new TankOperation();
            objectType = cellObjects[myPlayerX+1, myPlayerY].GetType();
            if (objectType != typeof(Brick) && objectType != typeof(Stone) && objectType != typeof(Water))
            {
                if (objectType == typeof(Player))
                {
                    //have to shoot or move to another location

                }
               else
                    tankOp.MoveLeft(myTank);
            }



        }

   
        
    }
}
