﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankD2;
using TankD2.Models;

namespace TankD2.Controllers
{
    public class GameCanvas


    {
        public static string[,] cells = new string[10, 10];
        public static CanvasStructure[,] cellObjects = new CanvasStructure[10, 10];

        //lists of players,coin etc   
        public static List<Player> players = new List<Player>();
        public static List<Coin> coinPiles = new List<Coin>();
        public static List<LifePack> lifePacks = new List<LifePack>();
        public static List<Brick> bricks = new List<Brick>();
        


        int noOfBricks = 0;
        string[,] bricksCondition;


        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        //public GameCanvas() {
        //    //initiate array
        //    for (int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            cells[i, j] = "N";
        //            cellObjects[i, j] = new CanvasStructure();

        //        }
        //    }
        //}


        //edited temp

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public static void initiateArray()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j] = "N";
                    cellObjects[i, j] = new CanvasStructure();

                }
            }

        }



        public GameCanvas()
        {
            //initiate array
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        cells[i, j] = "N";
            //        cellObjects[i, j] = new CanvasStructure();

            //    }
            //}
        }



        public void printCanvas()
        {

            //Illustrate.getGUI().setTextData(cells);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(cells[i, j] + " ");
                }
                Console.WriteLine();
            }

        }


        //When sever notifies that client has succesfully connected
        public void clientConnected(String reply)
        {
            char val = reply.Substring(0, 1)[0];
            switch (val)
            {

                case 'I':
                    //Console.Write(reply);
                    this.initialcanvas(reply);
                    // this.printCanvas();
                    Console.WriteLine();

                    break;
                case 'S':
                    this.initiatePlayer(reply);
                    // this.printCanvas();
                    Console.WriteLine();
                    break;
                case 'G':
                    Console.Write(reply);
                    this.globalUpdate(reply);
                    //  this.printCanvas();
                    Console.WriteLine();
                    break;
                case 'C':
                    this.coinPile(reply);
                    //   this.printCanvas();
                    Console.WriteLine();
                    break;
                case 'L':
                    this.lifePackSet(reply);
                    //   this.printCanvas();
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine(reply);
                    break;

            }
            //MainAI mainAI = new MainAI();
            // mainAI.move();

            Console.WriteLine("This works");
        }

        //initial point of tank
        public void initiatePlayer(String values)
        {

            String[] val = values.Split(':');
            String[] player = val[1].Split(';');
            String[] cordinates = player[1].Split(',');
            //Console.Write("Lenght of cordinte arr" + cordinates.Length);
            cells[Int32.Parse(cordinates[0]), Int32.Parse(cordinates[1])] = player[0];

            //player[0]=name, player[1]=cordinates, player[2]=direction
            Player myTank = new Player(1, player[0], cordinates[0], cordinates[1], player[2]);
            players.Add(myTank);
            cellObjects[Int32.Parse(cordinates[0]), Int32.Parse(cordinates[1])] = myTank;

        }


        //make initial canvas

        public void initialcanvas(String values)
        {

            String[] val = values.Split(':');
            String[] cordinates;
            String[] xy;
            for (int i = 2; i < 5; i++)
            {
                //val[2]=Bricks , val[3]= Stone , val[4]=water
                if (i == 4)
                    val[4] = val[4].Remove(val[4].Length - 2);


                cordinates = val[i].Split(';');

                for (int j = 0; j < cordinates.Length; j++)
                {
                    xy = cordinates[j].Split(',');
                    switch (i)
                    {
                        case 2:
                            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "B";

                            //creating brick object
                            Brick brick = new Brick(xy[1], xy[0], 0.ToString());

                            //add bricks to brick lists
                            bricks.Add(brick);
                            cellObjects[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = brick;

                            noOfBricks++;
                            break;
                        case 3:
                            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "S";

                            //creating stone pbject
                            Stone stone = new Stone(xy[1], xy[0]);

                            cellObjects[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = stone;

                            break;
                        case 4:
                            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "W";

                            //creating watetr object
                            Water water = new Water(xy[1], xy[0]);
                            cellObjects[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = water;

                            break;
                        default:
                            Console.Write("Something went wrong in initialization");
                            break;
                    }
                    // Console.Write("no of Bricks" + noOfBricks);  
                }

            }


        }

        public void globalUpdate(String values)
        {
            String[] val = values.Split(':');
            String[,] playerInfo = new String[5, 7]; //player 
            String[] temp;
            String[] xyn;
            bool checklist = false;

            //Store player infor in a 2D array
            for (int i = 0; i < val.Length - 2; i++)
            {
                //Console.Write("Error value check"+val[i + 1][0]);
                if ((val[i + 1])[0] != 'P')
                    break;
                temp = val[i + 1].Split(';');
                xyn = temp[1].Split(',');
                Player newplayer;

                //object oriented  approach
                for (int r = 0; r < players.Count; r++)
                {
                    if (temp[0] == players[r].Name)
                    {

                        players[r].Whethershot = Int32.Parse(temp[3]);
                        players[r].Health = Int32.Parse(temp[4]);
                        players[r].Coins = Int32.Parse(temp[5]);
                        players[r].Points = Int32.Parse(temp[6]);
                        checklist = true;

                    }
                }
                if (checklist == true)
                    checklist = false;

                else
                {
                    newplayer = new Player(0, temp[0], xyn[0], xyn[1], temp[2]);

                    newplayer.Whethershot = Int32.Parse(temp[3]);
                    newplayer.Health = Int32.Parse(temp[4]);
                    newplayer.Coins = Int32.Parse(temp[5]);
                    newplayer.Points = Int32.Parse(temp[6]);

                    players.Add(newplayer);
                }

                // for 2d array player info
                for (int j = 0; j < 7; j++)
                {

                    playerInfo[i, j] = temp[j];

                }

            }

            //for (int h = 0; h < players.Count; h++) {
            //    Console.Write(players[h].Name+ "  --");
            //    Console.Write(players[h].Health + "  --");
            //    Console.Write(players[h].Coins + "  --");
            //    Console.Write(players[h].Points + "  --");
               
            //}

            String[] xy;
            //update canvas according to player position
            for (int i = 0; i < 5; i++)
            {
                if (playerInfo[i, 1] == null)
                    break;
                xy = playerInfo[i, 1].Split(',');


                bool keepGoing = true;

                for (int k = 0; k < 10 && keepGoing; k++)
                {
                    for (int j = 0; j < 10 && keepGoing; j++)
                    {
                        if (cells[k, j].Equals(playerInfo[i, 0]))
                        {
                            cells[k, j] = "N";
                            keepGoing = false;
                        }


                    }
                }

                cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = playerInfo[i, 0];

            }

            String bricksStr = val[(val.Length) - 1];
            bricksStr = bricksStr.Remove(bricksStr.Length - 2);
            String[] brickArr = bricksStr.Split(';');
            bricksCondition = new String[this.noOfBricks, 3];

            //update the condition of bricks
            for (int i = 0; i < brickArr.Length; i++)
            {
                temp = brickArr[i].Split(',');
                //for (int j = 0; j < 3; j++)
                //    Console.Write("temp variable" + j + "is" + temp[j]);
                this.updateBricks(temp[1], temp[0], temp[2], i);

                //update brick objects
                for(int j=0; j < bricks.Count; j++)
                {
                    if (temp[0] == bricks[j].X && temp[1] == bricks[j].Y)
                    {
                        bricks[j].DamageLevel = temp[2];
                        break;
                    }
                        
                }

            }

        }

        public void updateBricks(String x, String y, String condition, int count)
        {
            String[] temp = new string[3] { x, y, condition };
            for (int i = 0; i < 3; i++)
            {
                //Console.Write("temp variable" + i + "is" + temp[i]);
                bricksCondition[count, i] = temp[i];
            }

        }

        public void coinPile(String values)
        {
            String[] val = values.Split(':');
            String[] xy = new String[2];
            xy = val[1].Split(',');
            Coin coin = new Coin(xy[1], xy[0], val[2], val[3].Remove(val[3].Length - 2));
            //add coins to the coin list
            coinPiles.Add(coin);

            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "C";
            // coin.startTimer(Int32.Parse(val[2]));
        }

        public void lifePackSet(String values)
        {
            String[] val = values.Split(':');
            String[] xy = new String[2];
            xy = val[1].Split(',');
            LifePack lifePack = new LifePack(xy[1], xy[0], val[2].Remove(val[2].Length - 2));

            //add lifepacks to list
            lifePacks.Add(lifePack);


            cells[Int32.Parse(xy[1]), Int32.Parse(xy[0])] = "L";
            //lifePack.startTimer(Int32.Parse(val[2].Remove(val[2].Length - 2)));
        }

    }
}
