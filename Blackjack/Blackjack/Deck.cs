using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Deck
    {
        private List<Card> deck;

        public Deck()
        {
            deck = new List<Card>();
            string[] faceValues = new string[13] { "Ace","2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string[] suits = new string[4] { "Spades", "Diamonds", "Clubs", "Hearts"};
            foreach(string s in suits)
            {
                foreach(string f in faceValues)
                {
                    deck.Add(new Card(f, s));
                }
            }
        }
        /// <summary>
        /// Shuffles deck of cards using the Fisher-Yates method.
        /// </summary>
        public void Shuffle()
        {
            List<Card> tempDeck = new List<Card>();
            //Implementing Fisher-Yates Shuffle
            Random random = new Random();
            while (deck.Count > 0)
            {
                int card = random.Next(deck.Count);
                tempDeck.Add(deck.ElementAt(card));
                deck.RemoveAt(card);
            }

            deck = tempDeck;
        }
        /// <summary>
        /// Cuts deck at player designated location and transposes cards prior to end of deck.
        /// </summary>
        /// <param name="cutLocation">Int provided by player to identify location of list to "cut" at.</param>
        public void CutDeck(int cutLocation)
        {
            List<Card> tempDeck = new List<Card>();
            tempDeck = deck.GetRange(0, cutLocation-1);
            deck.RemoveRange(0, cutLocation-1);
            deck.AddRange(tempDeck);
        }
        /// <summary>
        /// The ability to remove the top card of a deck without it being dealt.
        /// </summary>
        public void Burn()
        {
            deck.RemoveAt(0);
        }
        /// <summary>
        /// Deals a Card
        /// </summary>
        /// <returns>Returns the top card of the deck</returns>
        public Card DealCard()
        {
            Card dealtCard = deck.ElementAt(0);
            deck.RemoveAt(0);
            return dealtCard;
        }


    }
}
