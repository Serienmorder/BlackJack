using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Hand
    {
        private List<Card> gameHand;

        private int handValue = 0;

        public int HandValue
        {
            get { return handValue; }
            private set { handValue = value; }
        }

        public List<Card> GameHand
        {
            get { return gameHand; }
            private set { gameHand = value; }
        }

        public Hand()
        {
            gameHand = new List<Card>();
        }
        /// <summary>
        /// The hand must be able to receive a card and then add it to its list
        /// </summary>
        /// <param name="receivedCard">The card that the hand has been dealt</param>
        public void ReceiveCard(Card receivedCard)
        {
            gameHand.Add(receivedCard);
            GetHandValue();
        }
        /// <summary>
        /// Flips the shown value of every card that is not shown to true.
        /// </summary>
        public void ShowHand()
        {
            foreach(Card c in gameHand.Where(g => g.Shown == false))
            {
                c.FlipCard(); 
            }
        }
        /// <summary>
        /// Calculates the Value of the entire hand.
        /// </summary>
        /// <returns>Returns the final calculated value.</returns>
        private int GetHandValue()
        {
            HandValue = 0;
            foreach(Card c in gameHand)
            {
                HandValue += c.GetValue();
            }
            if(HandValue > 21)
            {
                HandValue = 0;
                foreach(Card c in gameHand)
                {
                    HandValue += c.GetValue(true);
                }
            }
                
            return HandValue;

        }
        /// <summary>
        /// Get's the face value of a single card. 
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns>returns the face value of a single card, if that card is not shown returns card back.</returns>
        public string getFaceValue(int cardNumber)
        {
            if (GameHand.ElementAt(cardNumber).Shown)
                return GameHand.ElementAt(cardNumber).FaceValue;
            return "Card Back";
        }
    }
}
