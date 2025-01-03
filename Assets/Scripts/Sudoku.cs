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
        //Cycle for every row
        for (int k = 0; k < 3; k++)
        {
            //Cycle for every cell in the row
            for (int j = 0; j < 3; j++)
            {
                square1.grid[k, j] = remainingNumbers[j + 3*k];
                columns[j].Add(square1.grid[k, j]);
                square1.boxes[j + 3 * k].GetComponentInChildren<TextMeshProUGUI>().text = square1.grid[k, j].ToString();
            }            
        }
        remainingNumbers.Clear();
        
        // if index = 3
        InitialSquare square4 = squares[3].GetComponent<InitialSquare>();
        remainingNumbers.AddRange(Numbers);

        // For each row, find the right numbers to fill the boxes
        // For each box, assign the right number in the rows
        for (int k = 0; k < 3; k++)
        {
            for (int j = 0; j < 3; j++)
            {
                possibleNumbers = remainingNumbers.Except(columns[j]).ToList();                
                square4.ShuffleList(possibleNumbers);
                square4.grid[k, j] = possibleNumbers[0];
                columns[j].Add(square4.grid[k, j]);
                remainingNumbers.Remove(square4.grid[k, j]);
                square4.boxes[j + 3 * k].GetComponentInChildren<TextMeshProUGUI>().text = square4.grid[k, j].ToString();
            }
        }

        remainingNumbers.Clear();

        // if index = 6
        InitialSquare square7 = squares[6].GetComponent<InitialSquare>();

    }

    public void GenerateProblem()
    {
        // Generate a sudoku problem, showing only some numbers on the basis of the level of difficulty
    }
}
