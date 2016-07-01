using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class GameController
    {
        public Dealer dealer { get; private set; }

        public List<Player> players {get; private set; }
        public GameController()
        {
            SetupGame(1);
        }
       
        public GameController(int numOfPlayers)
        {
            SetupGame(numOfPlayers);
        }
        /// <summary>
        /// Sets up the game with the correct number of players
        /// </summary>
        /// <param name="numofPlayers">Allows multiple players to play</param>
        private void SetupGame(int numofPlayers)
        {
            dealer = new Dealer();
            players = new List<Player>();
            for(int i = 0; i < numofPlayers; i++)
            {
                players.Add(new Player());
            }
        }
        /// <summary>
        /// Deals cards after a card is cut and burned to every player
        /// </summary>
        /// <param name="cutLocation">Dealer cuts the deck where the player indicated.</param>
        public void StartGame(int cutLocation)
        {
            dealer.ShuffleDeck();
            dealer.CutDeck(cutLocation);
            dealer.BurnCard();
            foreach(Player p in players)
            {
                p.PlayerHand.ReceiveCard(dealer.DealFaceDown());
            }
            dealer.DealerHand.ReceiveCard(dealer.DealFaceUp());
            foreach(Player p in players)
            {
                p.PlayerHand.ReceiveCard(dealer.DealFaceDown());
            }
            dealer.DealerHand.ReceiveCard(dealer.DealFaceDown());

        }
        /// <summary>
        /// Player requests to be given another card.
        /// </summary>
        /// <param name="playerNumber">Gives the card to the correct player ID</param>
        public void Hit(int playerNumber)
        {
            players.ElementAt(playerNumber).PlayerHand.ReceiveCard(dealer.DealFaceUp());
        }
        /// <summary>
        /// Checks if a player has bust
        /// </summary>
        /// <param name="playerNumber">Allows you to check if a specific player bust.</param>
        /// <returns>Returns True if they busted</returns>
        public bool CheckBust(int playerNumber)
        {
            return (players.ElementAt(playerNumber).PlayerHand.HandValue > 21);
        }
        /// <summary>
        /// Shows Dealer Hand
        /// </summary>
        public void DealerShow()
        {
            dealer.DealerHand.ShowHand();
        }
        /// <summary>
        /// Dealer hits until above 17
        /// </summary>
        public void DealerHit()
        {
            while(dealer.DealerHand.HandValue < 17)
            {
                dealer.DealerHand.ReceiveCard(dealer.DealFaceUp());
            }
        }
        /// <summary>
        /// Checks if a specific player beat the dealer.
        /// </summary>
        /// <param name="playerNumber">Specific player ID to be checked</param>
        /// <returns>Returns True if player beat dealer</returns>
        public bool WinCheck(int playerNumber)
        {
            if (players.ElementAt(playerNumber).PlayerHand.HandValue <= 21 && players.ElementAt(playerNumber).PlayerHand.HandValue > dealer.DealerHand.HandValue)
                return true;
            else
                return false;

        }

    }
}
