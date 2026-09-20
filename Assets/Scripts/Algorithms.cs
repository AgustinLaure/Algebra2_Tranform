using System;
using UnityEngine;

public static class Algorithms
{
    #region Bitonic
    //O(n log^2(n)) costo computacional
    //O(log(n)) costo en memoria

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

    #region SelectionSort
    //O(n^2) en costo computacional
    //O(1) en memoria

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

    #region BubbleSort

    //O(n^2) costo computacional
    //O(1) costo en memoria

    public static void BubbleSort<T>(T[] array, int direction) where T : IComparable
    {
        int dir = 1 * (int)Mathf.Sign(direction);

        for (int i = 0; i < array.Length - 1; i++)
        {
            bool hasSwapped = false;

            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                int comparison = array[j].CompareTo(array[j + 1]);

                if (comparison * dir > 0)
                {
                    Swap(array, j, j + 1);
                    hasSwapped = true;
                }
            }

            if (!hasSwapped)
            {
                return;
            }
        }
    }

    #endregion

    #region CocktailSort

    //O(n^2) costo computacional
    //O(1) costo en memoria
    public static void CocktailSort<T>(T[] array, int direction) where T : IComparable
    {
        int dir = 1 * (int)Mathf.Sign(direction);
        int start = 0;
        int end = array.Length - 1;

        bool hasSwapped = true;

        while (hasSwapped)
        {
            hasSwapped = false;

            for (int i = start; i < end; i++)
            {
                int comparison = array[i].CompareTo(array[i + 1]);

                if (comparison * dir > 0)
                {
                    Swap(array, i, i + 1);
                    hasSwapped = true;
                }
            }

            if (!hasSwapped)
            {
                return;
            }

            hasSwapped = false;

            end--;

            for (int i = end; i > start; i--)
            {
                int comparison = array[i].CompareTo(array[i - 1]);

                if (comparison * dir < 0)
                {
                    Swap(array, i, i - 1);
                    hasSwapped = true;
                }
            }

            start++;
        }
    }

    #endregion

    #region QuickSort

    //O(n log(n)) en el mejor de los casos y 0(n^2) en el peor, cuando el mas grande o mas chico se selecciona siempre como pivote. costo computacional
    //O(log(n)) costo memoria y O(n) en el peor de los casos. 

    public static void QuickSortArray<T>(T[] array, int direction) where T : IComparable
    {
        int dir = 1 * (int)Mathf.Sign(direction);

        QuickSort(array, 0, array.Length - 1, dir);
    }

    // mueve los valores alrededor del pivote, haciendo que los menores vayan de un lado y lo mayores de otro
    private static int Divide<T>(T[] array, int low, int high, int direction) where T : IComparable
    {
        T pivot = array[high];

        // la posicion de la 'frontera' del mas chico
        int i = low - 1;

        //mueve los elementos mas chicos y desplaza la frontera
        for (int j = low; j <= high - 1; j++)
        {
            int comparison = array[j].CompareTo(pivot);
            if (comparison * direction < 0)
            {
                i++;
                Swap(array, i, j);
            }
        }

        //mueve al pivot adelante de la frontera
        Swap(array, i + 1, high);

        return i + 1;
    }

    //ordena los mayores y menores al rededor del pivot de forma recursiva hasta que ya no hay mas que ordenar
    private static void QuickSort<T>(T[] array, int low, int high, int direction) where T : IComparable
    {
        if (low < high)
        {
            int pivot = Divide(array, low, high, direction);

            // ordena los elementos mayores y menores al pivot respectivamente
            QuickSort(array, low, pivot - 1, direction);
            QuickSort(array, pivot + 1, high, direction);
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
