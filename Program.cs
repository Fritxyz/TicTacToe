using System;

namespace TicTacToe
{
    internal class Program
    {

        // create the PlayField
        static char[,] playField =
        {
            // columns
            {'1', '2', '3'}, // row 0
            {'4', '5', '6'}, // row 1
            {'7', '8', '9'}  // row 2
        };

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; // Player 1 start
            int input = 0;
            bool inputCorrect = true;

            // run the code as long as the program is running
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXOrO(player, input);
                }
                else if(player == 1)
                {
                    player = 2;
                    EnterXOrO(player, input);
                }

                SetField();

                #region
                // check winning condition

                char[] playerChars = { 'X', 'O' };

                foreach(char playerChar in playerChars)
                {
                    if (((playField[0,0] == playerChar) && (playField[0,1] == playerChar) && (playField[0,2] == playerChar))
                        || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                        || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                        || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))
                        )

                    {
                        if(playerChar == 'X')
                        {
                            Console.WriteLine("Player 2 is the winner!");
                        }
                        else
                        {
                            Console.WriteLine("Player 1 is the winner!");
                        }

                        // TODO: reset the field when someone has a winner (DONE)


                        Console.WriteLine("Please press any key to reset the game.");
                        Console.ReadKey();
                        ResetField();
                        break;
                        
                    }
                    else if(turns == 10)
                    {
                        Console.WriteLine("There is no winner :(");
                        Console.WriteLine("Please press any key to reset the game.");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                }

                #endregion

                #region
                // test if field is already taken

                // if the user enters an invalid value, the user will ask again to put an appropriate value
                do
                {
                    Console.WriteLine("\n--------------------------");
                    Console.WriteLine("\nPlayer {0}: Choose your field!", player);

                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("\nPlease enter a number!");
                    }

                    if((input == 1) && (playField[0, 0]) == '1')
                    {
                        inputCorrect = true;
                    }
                    else if((input == 2) && (playField[0, 1]) == '2')
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 3) && (playField[0, 2]) == '3')
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 4) && (playField[1, 0]) == '4')
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 5) && (playField[1, 1]) == '5')
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 6) && (playField[1, 2]) == '6')
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 7) && (playField[2, 0]) == '7')
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 8) && (playField[2, 1]) == '8')
                    {
                        inputCorrect = true;
                    }
                    else if ((input == 9) && (playField[2, 2]) == '9')
                    {
                        inputCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect input!");
                        Console.WriteLine("Please use another field");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);

                #endregion             

            } while (true);

            
        }

        public static void ResetField()
        {
            char[,] playFieldInitial =
            {

                // columns
                {'1', '2', '3'}, // row 0
                {'4', '5', '6'}, // row 1
                {'7', '8', '9'}  // row 2

            };

            playField = playFieldInitial;
            SetField();
            turns = 0; 
        }

        public static void SetField()
        {
            // TODO: replace numbers with variables (DONE)

            Console.Clear();
            Console.WriteLine("_________________________");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|   {0}   |   {1}   |   {2}   |", playField[0,0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("|_______|_______|_______|");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|   {0}   |   {1}   |   {2}   |", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("|_______|_______|_______|");
            Console.WriteLine("|       |       |       |");
            Console.WriteLine("|   {0}   |   {1}   |   {2}   |", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("|_______|_______|_______|");

            turns++;
        }

        public static void EnterXOrO(int player, int input)
        {
            char playerSign = ' ';

            if(player == 1)
            {
                playerSign = 'X';
            }
            else if(player == 2)
            {
                playerSign = 'O';
            }

            switch (input)
            {
                case 1:
                    playField[0, 0] = playerSign;
                    break;
                case 2:
                    playField[0, 1] = playerSign;
                    break;
                case 3:
                    playField[0, 2] = playerSign;
                    break;
                case 4:
                    playField[1, 0] = playerSign;
                    break;
                case 5:
                    playField[1, 1] = playerSign;
                    break;
                case 6:
                    playField[1, 2] = playerSign;
                    break;
                case 7:
                    playField[2, 0] = playerSign;
                    break;
                case 8:
                    playField[2, 1] = playerSign;
                    break;
                case 9:
                    playField[2, 2] = playerSign;
                    break;
            }
        }
    }
}
