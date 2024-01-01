namespace Tic_Tac_Toe
{
    internal class Program
    {
        static readonly char[] arr = new char[9];
        static int player;

        static void Main()
        {
            ResetVariables();

            GenerateBoard();

            while (true)
            {
                char choice = GetChoice();

                InsertField(choice);
                
                GenerateBoard();

                if (CheckIsWin())
                {
                    GameReapet();
                    ResetVariables();
                    GenerateBoard();
                }
            }
        }

        private static char GetChoice()
        {
            char choice;

            if (player % 2 == 0)
                Console.WriteLine("Wstaw : O");
            else
                Console.WriteLine("Wstaw : X");

            while (true)
            {
                choice = Console.ReadKey(true).KeyChar;

                if (char.IsNumber(choice))
                    break;
                else
                    Console.WriteLine("Wpisz cyfre od 1 - 9");
            }

            return choice;
        }

        private static void GenerateBoard()
        {
            Console.Clear();

            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[0], arr[1], arr[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[3], arr[4], arr[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[6], arr[7], arr[8]);
            Console.WriteLine("     |     |      ");
            Console.WriteLine();
        }

        private static void InsertField(char choice)
        {
            int index = int.Parse(choice.ToString()) - 1;

            if (char.IsNumber(arr[index])) //Is field is empty
            {
                if (player % 2 == 0)
                    arr[index] = 'O';
                else
                    arr[index] = 'X';

                player++;
            }
        }

        private static bool CheckIsWin()
        {
            bool isEnd = true;

            if (IsWin('O'))
            {
                Console.WriteLine();
                Console.WriteLine("---- BRAWO O wygrał ----");
                Console.WriteLine();
            }
            else if (IsWin('X'))
            {
                Console.WriteLine();
                Console.WriteLine("---- BRAWO X wygrał ----");
                Console.WriteLine();
            }
            else if (!arr.Where(char.IsNumber).Any()) //Is all fields are used but no one won
            {
                Console.WriteLine();
                Console.WriteLine("---- REMIS ----");
                Console.WriteLine();
            }
            else
                isEnd = false;

            return isEnd;
        }

        private static void GameReapet()
        {
            Console.WriteLine("Wybierz dowolny klawisz, aby powtorzyc");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ResetVariables()
        {
            player = 1;

            for (int i = 0; i < 9; i++)
                arr[i] = (i + 1).ToString()[0];
        }

        private static bool IsWin(char c)
        {
            return (arr[0] == c && arr[1] == c && arr[2] == c) || (arr[3] == c && arr[4] == c && arr[5] == c) || (arr[6] == c && arr[7] == c && arr[8] == c) ||
                (arr[0] == c && arr[3] == c && arr[6] == c) || (arr[1] == c && arr[4] == c && arr[7] == c) || (arr[2] == c && arr[5] == c && arr[8] == c) ||
                (arr[0] == c && arr[4] == c && arr[8] == c) || (arr[2] == c && arr[4] == c && arr[6] == c);
        }
    }
}
