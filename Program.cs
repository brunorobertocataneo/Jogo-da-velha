namespace Jogo_da_Velha
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            string turno = "X";
            int index = 1;
            int tentativas = 0;

            // Preencher tabuleiro numerado
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    index++;
                }
            }

            // Loop principal
            while (tentativas < 9)
            {
                Console.Clear();

                // Mostrar tabuleiro
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write($" [{matriz[i, j]}]");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"\nVez do jogador {turno}");
                Console.Write("Escolha uma posição (1-9): ");
                string jogada = Console.ReadLine();

                bool jogadaValida = false;

                // Verifica onde substituir
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] == jogada)
                        {
                            matriz[i, j] = turno;
                            jogadaValida = true;
                        }
                    }
                }

                if (jogadaValida)
                {
                    tentativas++;
                    turno = (turno == "X") ? "O" : "X"; // alterna turno
                }
                else
                {
                    Console.WriteLine("Jogada inválida! Aperte Enter para tentar novamente...");
                    Console.ReadLine();
                }
            }

            Console.Clear();
            Console.WriteLine("Fim do jogo!");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($" [{matriz[i, j]}]");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
