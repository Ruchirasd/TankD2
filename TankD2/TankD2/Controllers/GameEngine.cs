using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankD2.Controllers
{

    

    class GameEngine
    {

        private static GameCanvas g = new GameCanvas();

      



        public static void Resolve(object stateInfo) {
            String reply = (string)stateInfo;

           /* switch (reply)
            {
                case "PLAYERS_FULL#":
                    Console.Write("PLAYERS_FULL");
                    break;
                case "ALREADY_ADDED#":
                    Console.Write("ALREADY_ADDED");
                    break;
                case "GAME_ALREADY_STARTED#":
                    Console.Write("GAME_ALREADY_STARTED");
                    break;
                case "OBSTACLE#":
                    Console.Write("OBSTACLE");
                    break;
                case "CELL_OCCUPIED#":
                    Console.Write("CELL_OCCUPIED");
                    break;
                case "DEAD#":
                    Console.Write("DEAD");
                    break;
                case "TOO_QUICK#":
                    Console.Write("TOO_QUICK");
                    break;
                case "GAME_HAS_FINISHED#":
                    Console.Write("GAME_HAS_FINISHED");
                    break;
                case "GAME_NOT_STARTED_YET#":
                    Console.Write("GAME_NOT_STARTED_YET");
                    break;
                case "INVALID_CELL#":
                    Console.Write("INVALID_CELL");
                    break;
                default:
                    g.clientConnected(reply);
                    break;

            }*/


            if (reply.StartsWith("GAME"))
            {
                Console.WriteLine("not started");
            }
            else if (reply.StartsWith("TOO_QUICK"))
            {
                Console.WriteLine("too quick");

            }
            else
            {
                g.clientConnected(reply);
            
            }
        }

       
    }
}
