using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4OnARow
{
    internal class Barrier : Piece
    {
        internal Barrier(Player player) : base(player)
        {

        }
        internal override void ReactToExplosion(Explosion kaboom)
        {
            //the piece gets destroyed by the explosion
            base.ReactToExplosion(kaboom);
            //stops the ongoing explosion in this derectoin 
            kaboom.ExplosionOngoing = false;
        }

    }
}
