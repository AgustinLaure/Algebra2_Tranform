using UnityEngine;
using System.Collections.Generic;
using System;

public class Tester : MonoBehaviour
{
    private const int maxElements = 8;

    private int[] order = new int[maxElements]
    {
        6,1,2,9,1,3,4,6
    };

    private void Start()
    {
        int[] bitonic = new int[maxElements];
        Array.Copy(order, bitonic, order.Length);
        Algorithms.BitonicSortArray<int>(bitonic, 1);
        Debug.Log(bitonic);

        int[] selectionSort = new int[maxElements];
        Array.Copy(order, selectionSort, order.Length);
        Algorithms.SelectionSort<int>(selectionSort, 1);
        Debug.Log(selectionSort);

        int[] bubbleSort = new int[maxElements];
        Array.Copy(order, bubbleSort, order.Length);
        Algorithms.BubbleSort<int>(bubbleSort, 1);
        Debug.Log(bubbleSort);

        int[] cocktailSort = new int[maxElements];
        Array.Copy(order, cocktailSort, order.Length);
        Algorithms.CocktailSort<int>(cocktailSort, 1);
        Debug.Log(cocktailSort);

        int[] quickSort = new int[maxElements];
        Array.Copy(order, quickSort, order.Length);
        Algorithms.QuickSortArray<int>(quickSort, 1);
        Debug.Log(quickSort);

        int[] radixSortLSD = new int[maxElements];
        Array.Copy(order, radixSortLSD, order.Length);
        Algorithms.RadixSortLSD(radixSortLSD);
        Debug.Log(radixSortLSD);

        int[] insertionSort = new int[maxElements];
        Array.Copy(order, insertionSort, order.Length);
        Algorithms.InsertionSort(insertionSort, 1);
        Debug.Log(insertionSort);

        int[] shellSort = new int[maxElements];
        Array.Copy(order, shellSort, order.Length);
        Algorithms.ShellSort(shellSort, 1);
        Debug.Log(shellSort);

        int[] bogoSort = new int[maxElements];
        Array.Copy(order, bogoSort, order.Length);
        Algorithms.BogoSort(bogoSort, 1);
        Debug.Log(bogoSort);

        int[] radixSortMSD = new int[maxElements];
        Array.Copy(order, radixSortMSD, order.Length);
        Algorithms.RadixSortMSD(radixSortMSD);
        Debug.Log(radixSortMSD);

        int[] introSort = new int[maxElements];
        Array.Copy(order, introSort, order.Length);
        Algorithms.IntroSort(introSort);
        Debug.Log(introSort);
    }
}
