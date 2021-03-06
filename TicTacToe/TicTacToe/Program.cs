using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TicTacToe
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            bool whichPlayer = true;  //This variable decide which player moves next - player 1 is true, player 2 is false
            bool reasonEnd = false;  //This variable changes to true when on one won the game, otherwise it stays false 
            char P1 = 'O', P2 = 'X';  //Player 1 is O's and Player 2 in X's
            char[,] TicTac ={ { '1', '2', '3' },
                              { '4', '5', '6' },
                              { '7', '8', '9' } };

            while (true)
            {
                Console.WriteLine("      |       |       ");
                Console.WriteLine("   {0}  |   {1}   |  {2}  ", TicTac[0, 0], TicTac[0, 1], TicTac[0, 2]);
                Console.WriteLine("______|_______|______");
                Console.WriteLine("      |       |       ");
                Console.WriteLine("   {0}  |   {1}   |  {2}  ", TicTac[1, 0], TicTac[1, 1], TicTac[1, 2]);
                Console.WriteLine("______|_______|______");
                Console.WriteLine("      |       |       ");
                Console.WriteLine("   {0}  |   {1}   |  {2}  ", TicTac[2, 0], TicTac[2, 1], TicTac[2, 2]);
                Console.WriteLine("      |       |       ");

                if (whichPlayer)
                {
                    Console.Write("player 1 choose your field:"); //player 1 is O
                    string choice1 = Console.ReadLine();
                    applyChoice(TicTac, choice1, P1);
                    if (checkGrid(TicTac, P1))
                    {
                        Console.WriteLine("\nPlayer 1 won the game, congratulations!");
                        break;
                    }
                    whichPlayer = false;
                }
                else
                {
                    Console.Write("player 2 choose your field:"); //player 2 is X
                    string choice2 = Console.ReadLine();
                    applyChoice(TicTac, choice2, P2);
                    if (checkGrid(TicTac, P2))
                    {
                        Console.WriteLine("\nPlayer 2 won the game, congratulations!");
                        break;
                    }
                    whichPlayer = true;
                }
                if (checkIfFull(TicTac))
                {
                    reasonEnd = true;
                    break;
                }
                Console.Clear();
            }
            if (reasonEnd)
                Console.WriteLine("No one won, play again :)");

            Console.WriteLine("Press any botton to exit.");
            Console.Read();
        }
        static void applyChoice(char[,] mat, string what, char P)  //Function that implements the choice of the player on the board
        {
            bool success = int.TryParse(what, out int result);

            if (success)
            {
                switch (result)
                {
                    case 1:
                        mat[0, 0] = P;
                        break;
                    case 2:
                        mat[0, 1] = P;
                        break;
                    case 3:
                        mat[0, 2] = P;
                        break;
                    case 4:
                        mat[1, 0] = P;
                        break;
                    case 5:
                        mat[1, 1] = P;
                        break;
                    case 6:
                        mat[1, 2] = P;
                        break;
                    case 7:
                        mat[2, 0] = P;
                        break;
                    case 8:
                        mat[2, 1] = P;
                        break;
                    case 9:
                        mat[2, 2] = P;
                        break;
                    default:
                        Console.WriteLine("Error, please try again.");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Error, please try again.");
            }
        }
        static bool checkGrid(char[,] mat, char P)  //Function that checks the grid for any winner
        {
            if (mat[0, 0] == P && mat[0, 1] == P && mat[0, 2] == P)  //checks first row
                return true;
            else if (mat[1, 0] == P && mat[1, 1] == P && mat[1, 2] == P)  //checks second row
                return true;
            else if (mat[2, 0] == P && mat[2, 1] == P && mat[2, 2] == P)  //checks third row
                return true;

            else if (mat[0, 0] == P && mat[1, 0] == P && mat[2, 0] == P)  //checks first col
                return true;
            else if (mat[0, 1] == P && mat[1, 1] == P && mat[2, 1] == P)  //checks second col
                return true;
            else if (mat[0, 2] == P && mat[1, 2] == P && mat[2, 2] == P)  //checks third col
                return true;

            else if (mat[0, 0] == P && mat[1, 1] == P && mat[2, 2] == P)  //checks first diagonal
                return true;
            else if (mat[0, 2] == P && mat[1, 1] == P && mat[2, 0] == P)  //checks second diagonal
                return true;

            else
                return false;
        }
        static bool checkIfFull(char[,] mat)  //Function that checks if maybe no one won and the grid is already full
        {
            foreach (char element in mat)
            {
                if (element >= '0' && element <= '9')
                    return false;
            }
            return true;
        }
    }
}