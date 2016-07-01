using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        private Hand playerHand;

        public Hand PlayerHand
        {
            get { return playerHand; }
            private set { playerHand = value; }
        }

        public Player()
        {
            PlayerHand = new Hand();
        }
    }
}
