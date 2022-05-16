// ABDIEL WONG AVILA

//(**) Modify the code so that a player can quit or surrender on its turn.

//(**) Modify the code so that by the end of a match the game ask the player whether he/she wants to continue to play another match or to quit the game and respond accordingly to the answer.

//(**) Modify the code so that the game keeps a score of how many games each player has won and/or loss. Show the tally at the end of each match.


using System;
public class TicTacToe
{

    public const string X = "X";

    public const string O = "O";

    public int playerOneWins = 0;

    public int playerOneLoses = 0;

    public int playerTwoWins = 0;

    public int playerTwoLoses = 0;

    public string[] board;

    public bool isPlayerOneTurn;


    public static void Main()

    {

        TicTacToe ttt = new TicTacToe();

        ttt.Start();

    }

    public void Start()

    {

        int input;

        Init(); // 1. Initialize Variables and Environment

        ShowGameStartScreen(); // 2. Show Game Start Screen

        do

        {

            ShowBoard(); // 3. Show Board

            do

            {

                ShowInputOptions(); // 4. Show Input Options

                input = GetInput(); // 5. Get Input

            }

            while (
            !IsValidInput(input)
            ); // 6. Validate Input

            ProcessInput(input); // 7. Process Input

            UpdateGameState(); // 8. Update Game State

        }

        while (
        !IsGameOver()
        ); // 9. Check Termination Condition

        ShowGameOverScreen(); // 10. Show Game Over Screen

    }

    public void Init()

    {

        board = new string[9];

        for (int i = 0; i < board.Length; i++)

        {

            board[i] = i.ToString();

        }

        isPlayerOneTurn = true;

    }

    public void ShowGameStartScreen()

    {

        Console.WriteLine("Welcome to Tic-Tac-Toe!");

    }

    public void ShowBoard()

    {

        string b = board[0] + "|" + board[1] + "|" + board[2] + "\n" +

        "-----\n" +

        board[3] + "|" + board[4] + "|" + board[5] + "\n" +

        "-----\n" +

        board[6] + "|" + board[7] + "|" + board[8] + "\n";

        Console.WriteLine("\n" + b);

    }

    public void ShowInputOptions()

    {

        Console.Write("Input any number between 0 and 8, if you want to quit and surrender input 9: ");

    }

    public int GetInput()

    {

        try

        {

            int input = Convert.ToInt32(Console.ReadLine()
            );

            if (input == 9)

            {

                if (isPlayerOneTurn == true)

                {

                    Console.WriteLine("Player 1 surrenders.\nPlayer 2 won!\n");

                    playerTwoWins = playerTwoWins + 1;

                    playerOneLoses = playerOneLoses + 1;

                    Console.WriteLine("Player 2 wons: " + playerTwoWins + "\n");

                    Console.WriteLine("Player 2 loses: " + playerTwoLoses + "\n\n");

                    Console.WriteLine("Player 1 wons: " + playerOneWins + "\n");

                    Console.WriteLine("Player 1 loses: " + playerOneLoses + "\n\n");

                }

                else

                {

                    Console.WriteLine("Player 2 surrenders.\nPlayer 1 won!\n");

                    playerOneWins = playerOneWins + 1;

                    playerTwoLoses = playerTwoLoses + 1;

                    Console.WriteLine("Player 1 wons: " + playerOneWins + "\n");

                    Console.WriteLine("Player 1 loses: " + playerOneLoses + "\n\n");

                    Console.WriteLine("Player 2 wons: " + playerTwoWins + "\n");

                    Console.WriteLine("Player 2 loses: " + playerTwoLoses + "\n\n");

                }

                Console.WriteLine("Wanna play again?\nPress ENTER to play again.\nPress any other key to exit.");

                if (Console.ReadKey()
                .Key == ConsoleKey.Enter)

                {

                    Console.Clear();

                    Start();

                }

                Environment.Exit(0);

            }

            return input;

        }

        catch (Exception e)

        {

            return -1;

        }

    }

    public bool IsValidInput(int input)

    {

        if (input < 0 || input > 9)

        {

            Console.WriteLine("Please input a number between 0 and 9.\n\n");

            return false;

        }

        else if (
        !IsEmpty(input)
        )

        {

            Console.WriteLine("Position " + input + " has already been played.\n");

            return false;

        }

        else

        {

            return true;

        }

    }

    public bool IsEmpty(int a)

    {

        return (board[a] != X && board[a] != O);

    }


    public void ProcessInput(int input)

    {

        if (isPlayerOneTurn)

        {

            board[input] = X;

        }

        else

        {

            board[input] = O;

        }

    }

    public void UpdateGameState()

    {

        isPlayerOneTurn = !isPlayerOneTurn;

    }

    public bool IsGameOver()

    {

        return CheckWin(X) || CheckWin(O) || CheckDraw();

    }

    public bool CheckWin(string mark)

    {

        return CheckLine(mark, 0, 1, 2) || CheckLine(mark, 3, 4, 5) || CheckLine(mark, 6, 7, 8) || CheckLine(mark, 0, 3, 6) || CheckLine(mark, 1, 4, 7) || CheckLine(mark, 2, 5, 8) || CheckLine(mark, 0, 4, 8) || CheckLine(mark, 2, 4, 6);

    }

    public bool CheckLine(string mark, int a, int b, int c)

    {

        return (board[a] == mark && board[b] == mark && board[c] == mark);

    }

    public bool CheckDraw()

    {

        for (int i = 0; i < board.Length; i++)

        {

            if (IsEmpty(i)
            ) { return false; }

        }

        return true;

    }

    public void ShowGameOverScreen()

    {

        if (CheckWin(X)
        )

        {

            Console.WriteLine("Player 1 won!\n\n");

            playerOneWins = playerOneWins + 1;

            playerTwoLoses = playerTwoLoses + 1;

            Console.WriteLine("Player 1 wons: " + playerOneWins + "\n");

            Console.WriteLine("Player 1 loses: " + playerOneLoses + "\n\n");

            Console.WriteLine("Player 2 wons: " + playerTwoWins + "\n");

            Console.WriteLine("Player 2 loses: " + playerTwoLoses + "\n\n");

        }

        else if (CheckWin(O)
        )

        {

            Console.WriteLine("Player 2 won!\n\n");

            playerTwoWins = playerTwoWins + 1;

            playerOneLoses = playerOneLoses + 1;

            Console.WriteLine("Player 2 wons: " + playerTwoWins + "\n");

            Console.WriteLine("Player 2 loses: " + playerTwoLoses + "\n\n");

            Console.WriteLine("Player 1 wons: " + playerOneWins + "\n");

            Console.WriteLine("Player 1 loses: " + playerOneLoses + "\n\n");

        }

        else

        {

            Console.WriteLine("Draw!\n\n");

            Console.WriteLine("Player 1 wons: " + playerOneWins + "\n");

            Console.WriteLine("Player 1 loses: " + playerOneLoses + "\n\n");

            Console.WriteLine("Player 2 wons: " + playerTwoWins + "\n");

            Console.WriteLine("Player 2 loses: " + playerTwoLoses + "\n\n");

        }

        Console.WriteLine("Wanna play again?\nPress ENTER to play again.\nPress any other key to exit.");

        if (Console.ReadKey()
        .Key == ConsoleKey.Enter)

        {

            Console.Clear();

            Start();

        }

    }
}
// <-- NOT HERE.