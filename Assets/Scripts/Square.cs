using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Square : MonoBehaviour
{
    public GameObject[] boxes = new GameObject[9];    
    public List<int> row1 = new List<int>();
    public List<int> row2 = new List<int>();
    public List<int> row3 = new List<int>();

    public abstract void FillBoxes();
    

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