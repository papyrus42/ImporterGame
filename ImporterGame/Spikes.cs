using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ImporterGame
{
    public class Spikes: IBoundable
    {
        BoundaryRectangle bounds;

        Texture2D texture;
        

        public BoundaryRectangle Bounds => bounds;

        public Spikes(BoundaryRectangle br)
        {
            bounds = br;
        }

        public void LoadContent(ContentManager cm, string name)
        {
            texture = cm.Load<Texture2D>(name);
        }

        public void Draw(SpriteBatch sp)
        {
            sp.Draw(texture, bounds, Color.White);
        }
    }
}
