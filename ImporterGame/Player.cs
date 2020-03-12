using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace ImporterGame
{
    public class Player
    {
        int playerSpeed = 3;

        bool jumping = false;

        //bool falling = false;

        Texture2D texture;

        public Vector2 Position = new Vector2(200, 400);

        public Vector2 Origin = new Vector2(200, 400);

        public int groundLevel;

        public BoundaryRectangle bounds;

        Game1 game;

        public Player(Game1 g, BoundaryRectangle br, int gl)
        {
            game = g;
            bounds = br;
            groundLevel = gl;
        }


        public void LoadContent(ContentManager cm, string name)
        {
            texture = cm.Load<Texture2D>(name);
        }

        public void Update(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Left))
            {
                Position.X -= playerSpeed;
            }
            else if (keyboard.IsKeyDown(Keys.Right))
            {
                Position.X += playerSpeed;
            }

            if (keyboard.IsKeyDown(Keys.Up))
            {
                Position.Y -= playerSpeed;
            }
            else if(Position.Y < groundLevel)
            {
                Position.Y += playerSpeed;
            }

            bounds.X = Position.X;
            bounds.Y = Position.Y;

            if (bounds.X < 0)
            {
                bounds.X = 0;
                Position.X = 0;
            }
            if (bounds.X > game.GraphicsDevice.Viewport.Width - bounds.Width)
            {
                bounds.X = game.GraphicsDevice.Viewport.Width - bounds.Width;
                Position.X = game.GraphicsDevice.Viewport.Width - bounds.Width;
            }
            if (bounds.Y < 0)
            {
                bounds.Y = 0;
                Position.Y = 0;
            }
        }

        public void CheckForSpikeCollision(IEnumerable<IBoundable> spikes)
        {
                foreach (Spikes spike in spikes)
                {
                    if (bounds.CollidesWith(spike.Bounds))
                    {
                        Position = Origin;
                    }
                }
            
        }

        public void Draw(SpriteBatch sp)
        {
            sp.Draw(texture, bounds, Color.White);
        }
    }
}
