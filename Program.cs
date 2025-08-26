// Estrutura de Dados 1
// Bruno Roberto Cataneo e Alexandre da Silva Rocha


using System;

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
            bool venceu = false;

            // Preencher 
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    index++;
                }
            }

            // Loop 
            while (tentativas < 9 && !venceu)
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
                    venceu = VerificarVencedor(matriz, turno);

                    if (!venceu)
                        turno = (turno == "X") ? "O" : "X"; // alterna turno entre X e O
                }
                else
                {
                    Console.WriteLine("Jogada inválida! Aperte Enter para tentar novamente...");
                    Console.ReadLine();
                }
            }

            Console.Clear();
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($" [{matriz[i, j]}]");
                }
                Console.WriteLine();
            }

            if (venceu)
                Console.WriteLine($"\nJogador {turno} venceu!");
            else
                Console.WriteLine("\nEmpate!");

            Console.ReadLine();
        }

        static bool VerificarVencedor(string[,] tabuleiro, string turno)
        {
            // Verificar linhas
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == turno && tabuleiro[i, 1] == turno && tabuleiro[i, 2] == turno)
                    return true;
            }

            // Verificar colunas
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[0, j] == turno && tabuleiro[1, j] == turno && tabuleiro[2, j] == turno)
                    return true;
            }

            // Verificar diagonais
            if (tabuleiro[0, 0] == turno && tabuleiro[1, 1] == turno && tabuleiro[2, 2] == turno)
                return true;

            if (tabuleiro[0, 2] == turno && tabuleiro[1, 1] == turno && tabuleiro[2, 0] == turno)
                return true;

            return false;
        }
    }
}
