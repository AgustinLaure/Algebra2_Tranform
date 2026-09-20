using System;
using UnityEngine;

public static class Algorithms
{
    //O(n log^2(n)) costo computacional
    //O(log(n)) costo en memoria

    #region Bitonic


    // direction == 1 ascendente
    // direction == -1 descendente
    public static void BitonicSortArray<T>(T[] array, int direction) where T : IComparable
    {
        BitonicSort(array, 0, array.Length, direction);
    }

    // sortea el array en secuencias bitonicas y las ordena
    //log(n)
    private static void BitonicSort<T>(T[] array, int lowest, int count, int direction) where T : IComparable
    {
        if (count > 1)
        {
            int k = count / 2;

            //sortea la primera mitad ascendente
            BitonicSort(array, lowest, k, 1);

            // la segunda descendente
            BitonicSort(array, lowest + k, k, -1);

            BitonicMerge(array, lowest, count, direction);
        }
    }

    // ordena una secuencia bitonica
    //log(n) * n
    private static void BitonicMerge<T>(T[] array, int lowest, int count, int direction) where T : IComparable
    {
        if (count > 1)
        {
            int k = count / 2;

            for (int i = lowest; i < lowest + k; i++)
            {
                int comparison = array[i].CompareTo(array[i + k]);
                if ((comparison > 0 && direction == 1) || (comparison < 0 && direction == -1))
                {
                    Swap<T>(array, i, i + k);
                }
            }

            BitonicMerge(array, lowest, k, direction);
            BitonicMerge(array, lowest + k, k, direction);
        }
    }

    #endregion

    //O(n^2) en costo computacional
    //O(1) en memoria
    #region SelectionSort


    //Sortea guardando el indice del mas pequeño/grande para ponerlo en su posicion correspondiente
    public static void SelectionSort<T>(T[] array, int direction) where T : IComparable
    {
        int dir = 1 * (int)Mathf.Sign(direction);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int lowestValueIndex = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                int comparison = array[j].CompareTo(array[lowestValueIndex]);

                if (comparison * dir < 0)
                {
                    lowestValueIndex = j;
                }
            }

            Swap<T>(array, i, lowestValueIndex);
        }
    }

    #endregion

    private static void Swap<T>(T[] array, int i, int j)
    {
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
