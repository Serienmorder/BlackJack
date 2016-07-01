using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Dealer
    {
        private Hand dealerHand;

        public Hand DealerHand
        {
            get { return dealerHand; }
            private set { dealerHand = value; }
        }

        private Deck gameDeck;

        public Deck GameDeck
        {
            get { return gameDeck; }
            private set { gameDeck = value; }
        }


        public Dealer()
        {
            DealerHand = new Hand();
            GameDeck = new Deck();
        }
        /// <summary>
        /// Dealer can shuffle Deck.
        /// </summary>
        public void ShuffleDeck()
        {
            GameDeck.Shuffle();
        }
        /// <summary>
        /// Dealer tells deck where to be cut from number from player
        /// </summary>
        /// <param name="cutLocation">Player provides a cut location for dealer to cut the deck</param>
        public void CutDeck(int cutLocation)
        {
            GameDeck.CutDeck(cutLocation);
        }
        /// <summary>
        /// Dealer is the one that actually burns a card.
        /// </summary>
        public void BurnCard()
        {
            GameDeck.Burn();
        }
        /// <summary>
        /// Deals face down cards
        /// </summary>
        /// <returns>Returns the card dealt but doesn't show it</returns>
        public Card DealFaceDown()
        {
            return GameDeck.DealCard();
        }
        /// <summary>
        /// Deals Face Up cards
        /// </summary>
        /// <returns>Returns the card dealt but allows it to be shown</returns>
        public Card DealFaceUp()
        {
            Card temp = DealFaceDown();
            temp.FlipCard();
            return temp;
        }
    }
}
