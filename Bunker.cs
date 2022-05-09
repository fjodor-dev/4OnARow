using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4OnARow
{
    internal class Bunker : Piece
    {
        internal Bunker(Player player) : base(player)
        {

        }
        internal override void ReactToExplosion(Explosion kaboom)
        {
            //the bunker is immune to the Explosion and so it does nothing in this method
        }
    }
}
