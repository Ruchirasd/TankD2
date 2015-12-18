using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TankD2.Controllers;

namespace TankD2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        BackgroundCon background;
        Connection connection;
        KeyboardState oldState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            connection = new Connection();
            Console.WriteLine("Start");
            connection.ConnectToServer("JOIN#");
            connection.InitializeBackGroundThreads();
           

            
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 555;
            graphics.PreferredBackBufferHeight = 555;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "TankD2";

            oldState = Keyboard.GetState();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = new BackgroundCon( Content, spriteBatch, graphics);
            device = graphics.GraphicsDevice;
            background.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
          
            base.Update(gameTime);
            UpdateInput();
            spriteBatch.Begin();
            background.Draw();

            spriteBatch.End();
          
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            spriteBatch.Begin();
            background.Draw();
            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Space) && !oldState.IsKeyDown(Keys.Space))
            {
                Console.WriteLine("Space");
                connection.ConnectToServer("SHOOT#");
                
            }
            else if (newState.IsKeyDown(Keys.Up) && !oldState.IsKeyDown(Keys.Up))
            {
                Console.WriteLine("Up");
                connection.ConnectToServer("UP#");
            
            }
            else if (newState.IsKeyDown(Keys.Down) && !oldState.IsKeyDown(Keys.Down))
            {
                Console.WriteLine("Down");
                connection.ConnectToServer("DOWN#");  

            }
            else if (newState.IsKeyDown(Keys.Right) && !oldState.IsKeyDown(Keys.Right))
            {
                Console.WriteLine("Right");
                connection.ConnectToServer("RIGHT#");

            }
            else if (newState.IsKeyDown(Keys.Left) && !oldState.IsKeyDown(Keys.Left))
            {
                Console.WriteLine("left");
                connection.ConnectToServer("LEFT#");

            }

            oldState = newState;


        }

    }
}
