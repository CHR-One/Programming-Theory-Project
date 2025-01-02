using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku : MonoBehaviour
{
    public GameObject[] squares = new GameObject[9];
    public List<int>[] columns = new List<int>[9];
    public readonly int[] Numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    private void Start()
    {
        for (int i = 0; i < columns.Length; i++)
        {
            columns[i] = new List<int>();
        }
    }

    public void GenerateGrid()
    {
        // if index = 0
        InitialSquare square1 = squares[0].GetComponent<InitialSquare>();
        square1.remainingNumbers.AddRange(Numbers);
        Debug.Log("remainingNumbers: { " + string.Join(", ", square1.remainingNumbers) + " }");
        square1.ShuffleList(square1.remainingNumbers);
        Debug.Log("remainingNumbers shuffled: { " + string.Join(", ", square1.remainingNumbers) + " }");
        for (int k = 0; k < 3; k++)
        {
            square1.row1[k] = square1.remainingNumbers[k];
            columns[k].Add(square1.row1[k]);
            square1.row2[k] = square1.remainingNumbers[k + 3];
            columns[k].Add(square1.row2[k]);
            square1.row3[k] = square1.remainingNumbers[k + 6];
            columns[k].Add(square1.row3[k]);
        }
        Debug.Log("square1.row1: { " + string.Join(", ", square1.row1) + " }");
        Debug.Log("square1.row2: { " + string.Join(", ", square1.row2) + " }");
        Debug.Log("square1.row3: { " + string.Join(", ", square1.row3) + " }");
        Debug.Log("columns[0]: { " + string.Join(", ", columns[0]) + " }");
        Debug.Log("columns[1]: { " + string.Join(", ", columns[1]) + " }");
        Debug.Log("columns[2]: { " + string.Join(", ", columns[2]) + " }");

        // if index = 3
        InitialSquare square4 = squares[3].GetComponent<InitialSquare>();
    }

    public void GenerateProblem()
    {
        // Generate a sudoku problem, showing only some numbers on the basis of the level of difficulty
    }
}
