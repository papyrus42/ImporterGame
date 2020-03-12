using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterGame
{
    public class Spikes: IBoundable
    {
        BoundaryRectangle bounds;

        public BoundaryRectangle Bounds => bounds;
    }
}
