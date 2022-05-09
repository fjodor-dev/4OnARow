using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4OnARow
{
    internal class VerticalBom : Piece
    {
        internal VerticalBom(Player player) : base(player)
        {

        }

        internal override void FallDown()
        {
            //normely fall down
            base.FallDown();
            //cause a explosion when it hits the bottom
            MakeExplosion();
        }

        private void MakeExplosion()
        {
            Explosion explosion = new Explosion(this.IndexOfBoardX,this.IndexOfBoardY);
            base.ReactToExplosion(explosion);
            explosion.VExplosion();
        }

        
    }
}
