﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace TankD2.Controllers
{
    class BackgroundCon : Controller
    {

        GraphicsDeviceManager grx;
        private Texture2D cell;
        private Texture2D water;
        private Texture2D stone;
        private Texture2D white;
        private Texture2D brick;
        private Texture2D brick25;
        private Texture2D brick50;
        private Texture2D backgroundTexture;
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
         }

    }
}