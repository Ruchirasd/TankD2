using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankD2.Controllers
{
    abstract class Controller
    {
        internal ContentManager content;
        internal SpriteBatch spriteBatch;

       internal Controller(ContentManager cm,SpriteBatch sp, GraphicsDeviceManager gdm)
        {
            content = cm;
            spriteBatch = sp;
        }

        public abstract void LoadContent();
        public abstract void Draw();
    }
}
