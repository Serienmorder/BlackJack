using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        private string faceValue;

        public string FaceValue
        {
            get { return faceValue; }
            private set { faceValue = value; }
        }

        private string cardSuit;

        public string CardSuit
        {
            get { return cardSuit; }
            private set { cardSuit = value; }
        }

        private bool shown = false;

        public bool Shown
        {
            get { return shown; }
            private set { shown = value; }
        }

        public Card(string face, string suit)
        {
            CardSuit = suit;
            faceValue = face;
        }
        /// <summary>
        /// Calculates card value.
        /// </summary>
        /// <returns></returns>
        public int GetValue()
        {
            int value;
            if(Int32.TryParse(FaceValue, out value))
            {
                return value;
            }
            else
            {
                if (FaceValue == "Ace")
                    return 11;
                else
                    return 10;
            }
            
        }
        /// <summary>
        /// Calcultes card value.
        /// </summary>
        /// <param name="aceLow">true calculates card value with Ace Low</param>
        /// <returns>Returns new hand value</returns>
        public int GetValue(bool aceLow)
        {
            if (FaceValue == "Ace")
                return 1;
            else
                return GetValue();
           
        }
        /// <summary>
        /// Flips shown value to opposite of current value.
        /// </summary>
        public void FlipCard()
        {
            Shown = !Shown;
        }
        /// <summary>
        /// Overrides ToString function to print card value in human readable format.
        /// </summary>
        /// <returns>Returns String of card value</returns>
        public override string ToString()
        {
            return FaceValue + " of " + CardSuit;
        }
    }
}
