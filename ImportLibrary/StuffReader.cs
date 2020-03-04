using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using TRead = ImportLibrary.Stuff;

namespace ImportLibrary
{
    public class StuffReader : ContentTypeReader<TRead>
    {
        protected override TRead Read(ContentReader input, TRead existingInstance)
        {
            int lines = input.ReadInt32();
            List<Vector2> vects = new List<Vector2>();
            for (int i = 0; i < lines; i++)
            {
                string cordString = input.ReadString();
                string[] cords = cordString.Split(new char[] { ' ' });
                int x = Convert.ToInt32(cords[0]);
                int y = Convert.ToInt32(cords[1]);
                vects.Add(new Vector2(x, y));
            }
            Stuff stuff = new Stuff(vects.ToArray());
            return stuff;


        }
    }
}
