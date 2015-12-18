using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TankD2.Models;


namespace TankD2.Controllers
{
    class BackgroundCon : Controller
    {

        GraphicsDeviceManager grx;
        private Texture2D cell;
        private Texture2D water;
        private Texture2D stone;
        private Texture2D t_up;
        private Texture2D brick;
        private Texture2D backgroundTexture;
        private GameCanvas gameCanvas;
        GraphicsDevice device;
        int screenWidth;
        int screenHeight;
        const int space = 5;
        const int size = 50;


         internal BackgroundCon( ContentManager c, SpriteBatch s, GraphicsDeviceManager gr) : base(c, s,gr)
        {
            grx = gr;
        }

         public override void LoadContent()
         {
             device = grx.GraphicsDevice;
             water = content.Load<Texture2D>("water");
             stone = content.Load<Texture2D>("stones");
            // t_up = content.Load<Texture2D>("t_up");
             brick= content.Load<Texture2D>("briks");
             backgroundTexture = content.Load<Texture2D>("background");
             screenWidth = device.PresentationParameters.BackBufferWidth;
             screenHeight = device.PresentationParameters.BackBufferHeight;
            cell = content.Load<Texture2D>("cell");

        }

         public override void Draw()
         {
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
             spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);

            //Aquiring the game object array 
            
         //   CanvasStructure [,] cellObjects = gamecanvas.cellObjects;

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    int posx = size * i + space * (i + 1);
                    int posy = size * j + space * (j + 1);
                    char r = GameCanvas.cells[j,i][0];
                    Rectangle cellRectangle = new Rectangle(posx, posy, size, size);
                    switch(r){
                        case 'W':
                            spriteBatch.Draw(water, cellRectangle, Color.White);
                            break;
                        case 'B':
                            spriteBatch.Draw(brick, cellRectangle, Color.White);
                            break;
                        case 'S':
                            spriteBatch.Draw(stone, cellRectangle, Color.White);
                            break;
                        case 'P':
                           // spriteBatch.Draw(t_up, cellRectangle, Color.White);
                            break;
                        default:
                    spriteBatch.Draw(cell, cellRectangle, Color.White);
                            break;

                    }
                    
                    
                }
            }
         }

    }
}
