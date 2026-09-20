using UnityEngine;
using System.Collections.Generic;

public class Tester : MonoBehaviour
{
    int[] foo = new int[]
    {
        1,5,3
    };

    private void Start()
    {
        Algorithms.SelectionSort(foo, -1);

        Debug.Log(foo);
    }
}
