using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class Sudoku : MonoBehaviour
{
    public GameObject[] squares = new GameObject[9];
    public List<int>[] columns = new List<int>[9];
    private List<int> remainingNumbers = new List<int>();
    private List<int> possibleNumbers = new List<int>();
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
        remainingNumbers.AddRange(Numbers);
        Debug.Log("remainingNumbers: { " + string.Join(", ", remainingNumbers) + " }");
        square1.ShuffleList(remainingNumbers);
        Debug.Log("remainingNumbers shuffled: { " + string.Join(", ", remainingNumbers) + " }");
        for (int k = 0; k < 3; k++)
        {
            square1.row1[k] = remainingNumbers[k];
            columns[k].Add(square1.row1[k]);
            square1.row2[k] = remainingNumbers[k + 3];
            columns[k].Add(square1.row2[k]);
            square1.row3[k] = remainingNumbers[k + 6];
            columns[k].Add(square1.row3[k]);
        }

        //square1.FillBoxes();
        Debug.Log("square1.row1: { " + string.Join(", ", square1.row1) + " }");
        Debug.Log("square1.row2: { " + string.Join(", ", square1.row2) + " }");
        Debug.Log("square1.row3: { " + string.Join(", ", square1.row3) + " }");
        Debug.Log("columns[0]: { " + string.Join(", ", columns[0]) + " }");
        Debug.Log("columns[1]: { " + string.Join(", ", columns[1]) + " }");
        Debug.Log("columns[2]: { " + string.Join(", ", columns[2]) + " }");
        remainingNumbers.Clear();
        Debug.Log("remainingNumbers cleared: { " + string.Join(", ", remainingNumbers) + " }");

        // if index = 3
        InitialSquare square4 = squares[3].GetComponent<InitialSquare>();
        remainingNumbers.AddRange(Numbers);

        // For each row, find the right numbers to fill the boxes
        // For each box, assign the right number in the rows
        for (int j = 0; j < 3; j++)
        {
            // Find the possible numbers that can be assigned to the box
            possibleNumbers = remainingNumbers.Except(columns[j]).ToList();
            Debug.Log("possibleNumbers: { " + string.Join(", ", possibleNumbers) + " }");
            square4.ShuffleList(possibleNumbers);
            Debug.Log("possibleNumbers shuffled: { " + string.Join(", ", possibleNumbers) + " }");
            square4.row1.Add(possibleNumbers[0]);
            columns[j].Add(possibleNumbers[0]);
            remainingNumbers.Remove(square4.row1[j]);
            Debug.Log("remainingNumbers: { " + string.Join(", ", remainingNumbers) + " }");
        }




        for (int k = 0; k < 3; k++)
        {
            square4.row1[k] = remainingNumbers[k];
            columns[k].Add(square4.row1[k]);
            square4.row2[k] = remainingNumbers[k + 3];
            columns[k].Add(square4.row2[k]);
            square4.row3[k] = remainingNumbers[k + 6];
            columns[k].Add(square4.row3[k]);
        }
        //square1.FillBoxes();
        Debug.Log("square4.row1: { " + string.Join(", ", square1.row1) + " }");
        Debug.Log("square4.row2: { " + string.Join(", ", square1.row2) + " }");
        Debug.Log("square4.row3: { " + string.Join(", ", square1.row3) + " }");
        Debug.Log("columns[0]: { " + string.Join(", ", columns[0]) + " }");
        Debug.Log("columns[1]: { " + string.Join(", ", columns[1]) + " }");
        Debug.Log("columns[2]: { " + string.Join(", ", columns[2]) + " }");
        remainingNumbers.Clear();
        Debug.Log("remainingNumbers cleared: { " + string.Join(", ", remainingNumbers) + " }");
    }

    public void GenerateProblem()
    {
        // Generate a sudoku problem, showing only some numbers on the basis of the level of difficulty
    }
}
