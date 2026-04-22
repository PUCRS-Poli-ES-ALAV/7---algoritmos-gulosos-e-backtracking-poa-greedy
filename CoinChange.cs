// ## Problema do Troco

// Suponha que tenhamos disponíveis moedas com certos valores (por exemplo, de 100, 25, 10, 5 e 1). O problema do troco consiste criar um algoritmo que para conseguir obter um determinado valor com o menor número de moedas possível.
// Por exemplo, para “dar um troco” de R$2,89, a melhor solução, isto é, o menor número de moedas possível para obter o valor consiste em 10 moedas: 2 de valor 100, 3 de valor 25, 1 de valor 10 e 4 de valor 1.

// 1) **Objetivo:** contrua um algorítmo que recebe a lista das moedas disponíveis e um valor, e retorna uma lista com a menor quantidade de moedas para este troco;
//   * Defina uma assinatura adequada para este método;
//   * Utiliza uma abordagem gulosa (se puder);
//   * Contabilize e exiba o número de iterações para cada caso de teste;
//   * O exercício pode ser feito em grupos de um, dois ou três elementos.

using System;
using System.Collections.Generic;
using System.Globalization;

public class CoinChange
{
    
    static int iterations = 0;

    public static List<int> GetMinimumCoins(List<int> coins, int amount)
    {
        List<int> result = new List<int>();

        coins.Sort((a, b) => b.CompareTo(a));

        foreach (int coin in coins)
        {
            while (amount >= coin)
            {
                result.Add(coin);
                amount -= coin;
                iterations++;
            }
        }

        Console.WriteLine($"Número de iterações: {iterations}");
        return result;
    }

    public static void Main(string[] args)
    {
        List<int> coins = new List<int>();
        decimal amount = 0.0m;

        Console.WriteLine("Vamos calcular o melhor troco com as moedas disponíveis.");
        Console.WriteLine("Quantos tipos de moedas você quer informar?");
        int coinTypes = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Digite os valores das moedas em centavos:");
        for (int i = 0; i < coinTypes; i++)
        {
            Console.WriteLine($"Moeda {i + 1}:");
            int coin = int.Parse(Console.ReadLine() ?? "0");

            if (coin <= 0)
            {
                Console.WriteLine("Valor inválido. A moeda deve ser maior que zero.");
                i--;
                continue;
            }

            coins.Add(coin);
        }

        Console.WriteLine("Digite o valor do troco (em reais):");
        string amountInput = (Console.ReadLine() ?? "0").Replace(',', '.');
        amount = decimal.Parse(amountInput, CultureInfo.InvariantCulture);
        int intAmount = (int)(amount * 100);

        iterations = 0;
        List<int> minimumCoins = GetMinimumCoins(coins, intAmount);
        Console.WriteLine($"Valor do troco: R${amount}");
        Console.WriteLine($"Número de moedas usadas: {minimumCoins.Count}");
        Console.WriteLine("Moedas usadas para o troco:");
        foreach (int coin in minimumCoins)
        {
            Console.WriteLine(coin);
        }
    }
}