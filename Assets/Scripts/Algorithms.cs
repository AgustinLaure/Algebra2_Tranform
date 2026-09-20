using System;
using UnityEngine;

public static class Algorithms
{
    private static readonly System.Random rng = new System.Random();

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

    #region RadixSortLSD

    //O(d * (n+10)) costo computacional, hace d pasadas en las que recorre elementos(n) e itera un for de 10
    //d cantidad de digitos del numero mas grande

    //O(n+10) costo de memoria cada bucket de 10 y copiar en un array para reordenar

    public static void RadixSortLSD(int[] array)
    {
        int max = GetMax(array, array.Length);

        //ordena el array segun exponente
        for (int exponent = 1; max / exponent > 0; exponent *= 10)
        {
            CountSort(array, exponent);
        }
    }

    public static int GetMax(int[] array, int n)
    {
        int max = array[0];

        for (int i = 1; i < n; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        return max;
    }

    //hace el sort segun
    public static void CountSort(int[] array, int exp)
    {
        int arrayLength = array.Length;

        int[] output = new int[arrayLength];
        int[] count = new int[10];

        for (int i = 0; i < 10; i++)
        {
            count[i] = 0;
        }

        //calcula cuantos de cada digito hay teniendo en cuenta el exp en que estamos
        for (int i = 0; i < arrayLength; i++)
        {
            count[(array[i] / exp) % 10]++;
        }

        //calcula cual es la posicion maxima que puede tener cada digito
        //cada digito 'empuja' al siguiente
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        //en base a estos count calculados asigna a cada valor que posicion le corresponderia
        //segun el valor de su exponente
        for (int i = arrayLength - 1; i >= 0; i--)
        {
            output[count[(array[i] / exp) % 10] - 1] = array[i];
            count[(array[i] / exp) % 10]--;
        }

        for (int i = 0; i < arrayLength; i++)
        {
            array[i] = output[i];
        }
    }

    #endregion

    #region RadixSortMSD

    //O(cantidad de digitos * cantidad de elementos). por cada digito debe recorrer las buckets revisando el orden en cada exponente.costo computacional
    //O(cantidad de digitos) costo en memoria

    //Ordena en el orden contrario a LSD, primero revisa las centenas luego las decenas etc.
    public static void RadixSortMSD(int[] array)
    {
        int max = GetMax(array, array.Length);

        int exp = 1;
        while (max / exp >= 10)
        {
            exp *= 10;
        }

        MSDRecursive(array, 0, array.Length - 1, exp);
    }
    private static void MSDRecursive(int[] array, int low, int high, int exp)
    {
        if (low >= high || exp == 0)
        {
            return;
        }

        int[] output = new int[high - low + 1];
        int[] count = new int[10];
        int[] bucketSizes = new int[10];

        for (int i = low; i <= high; i++)
        {
            int digit = (array[i] / exp) % 10;
            count[digit]++;
            bucketSizes[digit]++;
        }

        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = high; i >= low; i--)
        {
            int digit = (array[i] / exp) % 10;
            output[count[digit] - 1] = array[i];
            count[digit]--;
        }

        for (int i = 0; i < output.Length; i++)
        {
            array[low + i] = output[i];
        }

        for (int i = 0; i < 10; i++)
        {
            //Permite ordenar por exponentes mas grandes primero e iterar sobre los chicos si ambos comparten exponente
            if (bucketSizes[i] > 1)
            {
                int bucketStart = low + count[i];
                int bucketEnd = bucketStart + bucketSizes[i] - 1;

                MSDRecursive(array, bucketStart, bucketEnd, exp / 10);
            }
        }
    }

    #endregion

    #region ShellSort

    //O(n log(n) en el mejor de los casos y O(n^2) en el peor. costo computacional
    //O(1) costo en memoria 

    //es como el insertion sort pero utiliza gaps para asi mantener los valores mas grandes de un lado y los mas chicos del otro hasta resolver
    public static void ShellSort<T>(T[] array, int direction) where T : IComparable
    {
        int dir = 1 * (int)Mathf.Sign(direction);

        //calcula el gap actual segun la longitud del array
        for (int gap = array.Length / 2; gap > 0; gap /= 2)
        {
            //hace la insercion segun el gap que haya
            for (int i = gap; i < array.Length; i++)
            {
                T temp = array[i];
                int j = i;

                //mueve hacia la derecha teniendo en cuenta el gap
                while (j >= gap && array[j - gap].CompareTo(temp) * dir > 0)
                {
                    array[j] = array[j - gap];
                    j -= gap;
                }

                array[j] = temp;
            }
        }
    }

    #endregion

    #region InsertionSort

    //O(n^2) en el peor de los casos o O(n) en el mejor de los casos. costo computacional
    //O(1) costo en memoria

    //inserta segun el valor a la izquierda o derecha segun corresponda
    public static void InsertionSort<T>(T[] array, int direction) where T : IComparable
    {
        for (int i = 1; i < array.Length; i++)
        {
            T current = array[i];
            int j = i - 1;

            //empuja los valores mayores a la derecha para hacerse 'hueco'
            while (j >= 0 && (array[j].CompareTo(current) * direction > 0))
            {
                array[j + 1] = array[j];
                j--;
            }

            //guarda el valor cacheado en ese hueco
            array[j + 1] = current;
        }
    }

    #endregion

    #region BogoSort

    //O(infinito) costo computacional
    //O(1) costo en memoria

    public static void BogoSort<T>(T[] array, int direction) where T : IComparable
    {
        int dir = 1 * (int)Mathf.Sign(direction);

        while (!IsSorted(array, dir))
        {
            Shuffle(array);
        }
    }

    public static bool IsSorted<T>(T[] array, int direction) where T : IComparable
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i].CompareTo(array[i + 1]) * direction > 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void Shuffle<T>(T[] array) where T : IComparable
    {
        for (int i = 0; i < array.Length; i++)
        {
            int j = rng.Next(0, array.Length);
            Swap(array, i, j);
        }
    }

    #endregion

    #region IntroSort

    public static void IntroSort<T>(T[] array) where T : IComparable
    {

    }

    #endregion

    private static void Swap<T>(T[] array, int i, int j)
    {
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
