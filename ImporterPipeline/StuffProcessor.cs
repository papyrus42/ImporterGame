using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using ImportLibrary;

using TInput = System.String;
using TOutput = ImportLibrary.Stuff;

namespace ImporterPipeline
{
    [ContentProcessor(DisplayName = "Stuff Processor")]
    public class StuffProcessor : ContentProcessor<TInput, TOutput>
    {
        public override TOutput Process(string input, ContentProcessorContext context)
        {
            string[] lines = input.Split(new char[] { '\n' });
            List<Vector2> vects = new List<Vector2>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cords = lines[i].Split(new char[] { ' ' });
                int x = Convert.ToInt32(cords[0]);
                int y = Convert.ToInt32(cords[1]);
                Vector2 v = new Vector2(x, y);
                vects.Add(v);
            }
            Stuff stuff = new Stuff(vects.ToArray());
            return stuff;


        }
    }
}
