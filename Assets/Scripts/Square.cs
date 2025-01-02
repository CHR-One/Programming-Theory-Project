using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Square : MonoBehaviour
{
    public GameObject[] boxes = new GameObject[9];    
    public int[] row1 = new int[3];
    public int[] row2 = new int[3];
    public int[] row3 = new int[3];
    public List<int> remainingNumbers = new List<int>();
    public List<int> possibleNumbers = new List<int>();

    public abstract void FillBox(TextMeshProUGUI box);
    

    public void FillRow(int[] row)
    {

    }

    public void ShuffleList(List<int> list)
    {

        // Shuffle the list of numbers with the Fisher-Yates algorithm
        int n = list.Count;

        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}