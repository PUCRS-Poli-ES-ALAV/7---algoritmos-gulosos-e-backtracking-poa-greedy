// Problema do escalonamento de intervalos
// Um intervalo é um conjunto de números naturais consecutivos. Um intervalo como {s,s+1,…,f−1,f} será denotado por (s,f). O primeiro número do par é o início do intervalo e o segundo é o término. (As letras s e f lembram start e finish respectivamente.)

// Se temos vários intervalos, numerados de 1 a n, o início de um intervalo i será denotado por si e o término por fi. Suporemos sempre que si ≤ fi.

// Um intervalo i é anterior a um intervalo j se fi < sj. Analogamente, i é posterior a j se si > fj. Dois intervalos i e j são disjuntos se e somente se i é posterior a j ou anterior a j. Uma coleção de intervalos é disjunta se os intervalos da coleção são disjuntos dois a dois.

// Dada uma coleção S de intervalos, encontrar uma subcoleção disjunta máxima de S.

// Uma subcoleção disjunta X de S é máxima se não existe outra maior. Em outras palavras, se não existe subcoleção disjunta X′ de S tal que |X′| > |X|.

// Usaremos a abreviatura SDM para a expressão subcoleção disjunta máxima. Nosso problema consiste, portanto, em encontrar uma SDM de uma coleção de intervalos dada. Se os intervalos são numerados de 1 a n, uma SDM pode ser representada por um subconjunto de * {1,2,…,n}.

// Exemplo A figura abaixo especifica uma coleção de intervalos e uma sdm da coleção. A SDM é indicada pelos 1 do seu vetor característico X:

// s 4 6 13 4 2 6 7  9  1 3  9
// f 8 7 14 5 4 9 10 11 6 13 12
// X 0 1 1  0 1 0 0  1  0 0  0
// É fácil verificar que a coleção de 4 intervalos definida por x é disjunta. Mas não é óbvio que ela seja máxima. Você tem certeza de que não existem 5 intervalos disjuntos dois a dois?

// Nosso problema pode ser resolvido por um algoritmo guloso. Para descrever o algoritmo, precisamos do seguinte conceito. Digamos que o primeiro intervalo de um coleção de intervalos é o que tem o menor término.

// Eis o esboço do algoritmo guloso. Ele recebe uma coleção S de intervalos e devolve uma sdm de S:

// X ← { }
// enquanto S ≠ { } faça
//    i ← primeiro intervalo de S
//    X ← X ∪ {i}
//    S ← coleção dos intervalos posteriores a i
// devolva X
// Antes de transformar esse esboço em pseudocódigo de nível mais baixo, convém exigir que os intervalos estejam em ordem crescente de término (Com isso, o primeiro intervalo é o de índice 1).

// O algoritmo supõe f1 ≤ … ≤ fn e n ≥ 0 e devolve uma sdm da coleção de intervalos definida por (s,f,n):

// SDM-Guloso (s, f, n)
// 1   X ← { }
// 2   i ← 1
// 3   enquanto i ≤ n faça
// 4        X ← X ∪ {i}
// 5        k ← i + 1
// 6        enqunto k ≤ n e sk < fi faça
// 7              k ← k + 1
// 8        i ← k
// 9   devolva X
// O código pode ser reescrito de maneira mais elegante:

// SDM-Guloso (s, f, n)
// 1   f0 ← −∞
// 2   X ← { }
// 3   i ← 0
// 4   para k ← 1 até n faça
// 5         se sk > fi
// 6              então X ← X ∪ {k}
// 7                       i ← k
// 8   devolva X
// Assim:
// Implemente e teste uma solução para o problema descrito, usando aboradagem gulosa, como descrita;
// Contabilize e exiba o número de iterações para cada caso de teste;
// O exercício pode ser feito em grupos de um, dois ou três elementos.

using System;
using System.Collections.Generic;
using System.Globalization;

public class IntervalSchedule
{
    static int iterations = 0;


}