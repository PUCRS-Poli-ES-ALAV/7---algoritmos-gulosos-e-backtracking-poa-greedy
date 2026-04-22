// # Problema das n-rainhas

// O problema das N-rainhas consiste em encontrar uma combinação possível de N rainhas num tabuleiro de dimensão N por N tal que nenhuma das rainhas ataque qualquer outra. Duas rainhas atacam-se uma à outra quando estão na mesma linha, na mesma coluna ou na mesma diagonal do tabuleiro. Na figura que se segue pode ver-se as posições atacadas por uma rainha colocada num tabuleiro de dimensão 7 por 7 e ao lado uma possível solução para esse mesmo tabuleiro.

// ![N_Rainhas](https://github.com/PUCRS-Poli-ES-ALAV/7-algoritmos-gulosos-e-backtracking/blob/main/nrainhas1.bmp)

// 1. Desenvolver uma aplicação que resolva o problema das n-rainhas, encontrando uma solução válida para o problema. Como entrada, o programa recebe um valor para n >= 2, e retorna a disposição das rainhas no tabuleiro. Utilize uma estratégia de backtracking.
using System;
using System.Collections.Generic;

public class NQueens
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite o valor de n (n >= 2):");
        int n = int.Parse(Console.ReadLine() ?? "0");

        if (n < 2)
        {
            Console.WriteLine("Valor inválido. n deve ser maior ou igual a 2.");
            return;
        }

        List<int[]> solutions = SolveNQueens(n);
        Console.WriteLine($"Número de soluções encontradas: {solutions.Count}");
        foreach (var solution in solutions)
        {
            PrintBoard(solution);
            Console.WriteLine();
        }
    }

    public static List<int[]> SolveNQueens(int n)
    {
        List<int[]> solutions = new List<int[]>();
        int[] board = new int[n];
        PlaceQueens(board, 0, solutions);
        return solutions;
    }

    private static void PlaceQueens(int[] board, int row, List<int[]> solutions)
    {
        int n = board.Length;
        if (row == n)
        {
            solutions.Add((int[])board.Clone());
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (IsSafe(board, row, col))
            {
                board[row] = col;
                PlaceQueens(board, row + 1, solutions);
            }
        }
    }

    private static bool IsSafe(int[] board, int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            if (board[i] == col || Math.Abs(board[i] - col) == Math.Abs(i - row))
            {
                return false;
            }
        }
        return true;
    }

// 2. Ajuste o algoritmo anterior, para que retorne todas as soluções possíveis.
    private static void PrintBoard(int[] board)
    {
        int n = board.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(board[i] == j ? "Q " : ". ");
            }
            Console.WriteLine();
        }
    }
}
