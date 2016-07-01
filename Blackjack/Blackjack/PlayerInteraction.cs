using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class PlayerInteraction
    {
        static GameController gameController;

        static int playerCount = 0;

        static int cutLocation = 0;
        static void Main(string[] args)
        {

            GameLogic();

        }
        /// <summary>
        /// This is where the high level game logic and interaction with the player occurs.
        /// </summary>
        static void GameLogic()
        {
            Console.Clear();
            Console.WriteLine("Do you want to play a game? (Y)es or (N)o");
            string answer = Console.ReadLine();
            if (answer == "N" || answer == "n")
            {
                return;
            }

            while (!PlayerPrompt()) { }

            gameController = new GameController(playerCount);
            Random random = new Random();
            int randomNumber = random.Next(0, playerCount);
            Console.WriteLine("Player " + (randomNumber + 1) + " where shall I cut the deck?");
            while (!CutLocation()) { }


            gameController.StartGame(cutLocation);

            foreach (Player p in gameController.players)
            {
                int playerID = gameController.players.IndexOf(p);
                Console.Clear();
                ShowDealerCards(false);
                Console.Write("Player " + (playerID + 1));
                Console.WriteLine(", your cards in your hand are: ");
                ShowPlayerCards(playerID);
                Console.WriteLine("Your Hand value is: " + gameController.players.ElementAt(playerID).PlayerHand.HandValue);
                string nextPlayer = "";
                if (gameController.players.ElementAt(playerID).PlayerHand.HandValue != 21)
                {
                    while (!PlayerPlay(playerID))
                    {
                        ShowPlayerCards(playerID);
                        Console.WriteLine("Your Hand value is: " + gameController.players.ElementAt(playerID).PlayerHand.HandValue);
                    }
                    Console.WriteLine("Next Player? (Y)es. If not.. you shouldn't have hit stay, this is just a pause so you can review one more time");
                    answer = Console.ReadLine();
                    if (nextPlayer == "Y" || nextPlayer == "y")
                    {
                        continue;
                    }
                    else
                        continue;
                }
                else
                    Console.WriteLine("BlackJack! You win!");

            }

            ShowDealerCards(true);
            gameController.DealerHit();
            Console.Clear();
            ShowDealerCards(true);
            if (gameController.dealer.DealerHand.HandValue > 21)
                EndGame(true);
            EndGame();
        }
        /// <summary>
        /// Asks for how many players will be playing
        /// </summary>
        /// <returns>Returns true only if the number of players playing is between the correct values.</returns>
        static private bool PlayerPrompt()
        {
            Console.WriteLine("How many Players? Use number keys only. It can't be greater than 6");
            playerCount = 0;
            string answer = Console.ReadLine();

            Int32.TryParse(answer, out playerCount);

            if (playerCount <= 6 && playerCount > 0)
                return true;

            Console.WriteLine("Um.. You need to follow instructions");
            return false;
                
        }
        /// <summary>
        /// Asks the chosen player where to cut the deck.
        /// </summary>
        /// <returns>Returns true only if player selects a number in the appropriate range.</returns>
        static private bool CutLocation()
        {
            Console.WriteLine("Use Number Keys only between 1 and 52");
            cutLocation = 0;
            string answer = Console.ReadLine();
            Int32.TryParse(answer, out cutLocation);

            if (cutLocation >= 1 && cutLocation <= 52)
                return true;

            Console.WriteLine("Um.. You need to follow instructions");
            return false;
        }
        /// <summary>
        /// Reveals only cards desired.
        /// </summary>
        /// <param name="showAllCards">True will reveal all cards, False only reveals cards played faceup</param>
        static private void ShowDealerCards(bool showAllCards)
        {
            Console.WriteLine("Dealer is showing");
            foreach (Card c in gameController.dealer.DealerHand.GameHand)
            {
                if (c.Shown || showAllCards)
                {
                    Console.WriteLine(c.ToString());
                }
                
            }
        }
        /// <summary>
        /// Reveals only cards desired
        /// </summary>
        /// <param name="playerID">Reveals cards of the player playing</param>
        static private void ShowPlayerCards(int playerID)
        {
            foreach (Card c in gameController.players.ElementAt(playerID).PlayerHand.GameHand)
            {
                Console.WriteLine(c.ToString());
            }
        }
        /// <summary>
        /// Allows the player to hit or stay continuously
        /// </summary>
        /// <param name="playerID">Allows each player to individually take their turn</param>
        /// <returns>Returns true when they stay or bust, anything else will exit</returns>
        static private bool PlayerPlay(int playerID)
        {
            Console.WriteLine("(H)it or (S)tay?");
            string answer = Console.ReadLine();
            if (answer == "S" || answer == "s")
            {
                return true;
            }
            else if (answer == "H" || answer == "h")
            {
                gameController.Hit(playerID);
                if (gameController.CheckBust(playerID))
                {
                    Console.WriteLine("Your Hand value is: " + gameController.players.ElementAt(playerID).PlayerHand.HandValue);
                    Console.WriteLine("Your final hand was: ");
                    ShowPlayerCards(playerID);
                    Console.WriteLine("I'm sorry you lose");
                    return true;
                }    
                else
                    return false;
            }
            Console.WriteLine("You need to listen, man...");
            return false;
        }
        /// <summary>
        /// Announces who won or lost
        /// </summary>
        static private void EndGame()
        {
            foreach(Player p in gameController.players)
            {
                int playerID = gameController.players.IndexOf(p);
                bool won = gameController.WinCheck(playerID);
                if (won)
                    Console.WriteLine("Player " + (playerID + 1) + "Wins!");
                else
                    Console.WriteLine("Player " + (playerID + 1) + " Loses.. what a sucker");
            }
            Replay();
        }
        /// <summary>
        /// Announces who won or lost Dealer Bust
        /// </summary>
        /// <param name="dealerBust"></param>
        static private void EndGame(bool dealerBust)
        {
            Console.WriteLine("Dealer made a bad call and busted! Everyone wins that didn't bust!");
            Console.WriteLine("Hit Key to continue");
            string temp = Console.ReadLine();
            Replay();
        }
        /// <summary>
        /// Asks for replay
        /// </summary>
        static private void Replay()
        {
           
            while(true)
            {
                Console.WriteLine("Replay? (Y)es or (N)o. ");
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                    GameLogic();
                else if (answer == "N" || answer == "n")
                    return;
                else
                {
                    Console.WriteLine("Two keys.. Those are your only choices");
                    continue;
                }
                    
            }
            
                
        }
    }
}
