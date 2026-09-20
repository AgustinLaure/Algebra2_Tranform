using UnityEngine;
using System.Collections.Generic;

public class Tester : MonoBehaviour
{
    int[] order = new int[]
    {
        6,1,2,9,1,3,4,6
    };

    private void Start()
    {
        int[] bitonic = order;
        Algorithms.BitonicSortArray<int>(bitonic, 1);
        Debug.Log(bitonic);

        int[] selectionSort = order;
        Algorithms.SelectionSort<int>(selectionSort, 1);
        Debug.Log(selectionSort);

        int[] bubbleSort = order;
        Algorithms.BubbleSort<int>(bubbleSort, 1);
        Debug.Log(bubbleSort);

        int[] cocktailSort = order;
        Algorithms.CocktailSort<int>(cocktailSort, 1);
        Debug.Log(cocktailSort);

        int[] quickSort = order;
        Algorithms.QuickSortArray<int>(quickSort, 1);
        Debug.Log(quickSort);
    }
}
