using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using UnityEditor.Rendering;

public class InitialSquare : Square
{
    public Sudoku sudoku;
    private Square square;
    // Start is called before the first frame update
    void Start()
    {
        sudoku = GameObject.Find("Sudoku").GetComponent<Sudoku>();
        square = gameObject.GetComponent<Square>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void FillBoxes()
    {
        remainingNumbers.AddRange(Numbers);

        //Fill the square rows
        for (int k = 0; k < 3; k++)
        {
            for (int j = 0; j < 3; j++)
            {
                
                    Debug.Log($"STARTING cycle [{k}, {j}]");
                    Debug.Log("remainingNumbers: { " + string.Join(", ", remainingNumbers) + " }");
                    possibleNumbers = remainingNumbers.Except(sudoku.columns[j]).ToList();
                

                if (possibleNumbers.Count > 0)
                {
                    Debug.Log("possibleNumbers: { " + string.Join(", ", possibleNumbers) + " }");

                    if (possibleNumbers.Count != 1)
                        ShuffleList(possibleNumbers);

                    Debug.Log("possibleNumbers shuffled: { " + string.Join(", ", possibleNumbers) + " }");
                    square.grid[k, j] = possibleNumbers.First();
                    Debug.Log($"grid[{k}, {j}]: {grid[k, j]}");
                    sudoku.columns[j].Add(square.grid[k, j]);
                    Debug.Log($"columns[{j}]: {{ {string.Join(", ", sudoku.columns[j])} }}");
                    remainingNumbers.Remove(square.grid[k, j]);
                    boxes[j + 3 * k].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[k, j].ToString();
                    Debug.Log("remainingNumbers: { " + string.Join(", ", remainingNumbers) + " }");
                    Debug.Log($"End of cycle [{k}, {j}]");
                    Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }

        /*
        if (sudoku.columns[0].Count == 8)
        {
            for (int i = 0; i < 3; i++)
            {
                Debug.Log($"STARTING cycle [2, {i}]");
                Debug.Log("remainingNumbers: { " + string.Join(", ", remainingNumbers) + " }");
                Debug.Log($"columns[{i}]: {{ {string.Join(", ", sudoku.columns[i])} }}");
                possibleNumbers = remainingNumbers.Except(sudoku.columns[i]).ToList();
                Debug.Log("possibleNumbers: { " + string.Join(", ", possibleNumbers) + " }");
                square.grid[2, i] = possibleNumbers.First();
                Debug.Log($"grid[{2}, {i}]: {grid[2, i]}");
                sudoku.columns[i].Add(square.grid[2, i]);
                Debug.Log($"columns[{i}]: {{ {string.Join(", ", sudoku.columns[i])} }}");
                boxes[i + 6].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, i].ToString();
                Debug.Log($"End of cycle [2, {i}]");
                Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
        }

        // Filling now last row for each square with a specialized algorythm
        // Three possibilities to check
        // Column 0 may have 2 elements of remainingNumbers, so in the first cell we must put the only value not present
        if (sudoku.columns[0].Intersect(remainingNumbers).Count() == 2 && sudoku.columns[0].Count != 8)
        {
            Debug.Log($"C[0] has 2 elements of R");
            possibleNumbers = remainingNumbers.Except(sudoku.columns[0]).ToList();
            square.grid[2, 0] = possibleNumbers.First();
            sudoku.columns[0].Add(square.grid[2, 0]);
            remainingNumbers.Remove(possibleNumbers[0]);
            boxes[6].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, 0].ToString();

            if (sudoku.columns[1].Contains(remainingNumbers[0]))
            {
                square.grid[2, 1] = remainingNumbers[1];
                square.grid[2, 2] = remainingNumbers[0];
            }
            else
            {
                square.grid[2, 1] = remainingNumbers[0];
                square.grid[2, 2] = remainingNumbers[1];
            }
            sudoku.columns[1].Add(square.grid[2, 1]);
            sudoku.columns[2].Add(square.grid[2, 2]);
            boxes[7].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, 1].ToString();
            boxes[8].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, 2].ToString();
        }

        // Column 0 may contain only 1 item of remaining numbers, so we need to check other columns
        if (sudoku.columns[0].Intersect(remainingNumbers).Count() == 1 && sudoku.columns[0].Count != 8)
        {
            Debug.Log($"C[0] has 1 element of R");
            Debug.Log($"remainingNumbers: {{ {string.Join(", ", remainingNumbers)} }}");
            possibleNumbers = remainingNumbers.Except(sudoku.columns[0]).ToList();
            ShuffleList(possibleNumbers);
            square.grid[2, 0] = possibleNumbers[0];
            sudoku.columns[0].Add(square.grid[2, 0]);
            remainingNumbers.Remove(square.grid[2, 0]);
            boxes[6].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, 0].ToString();

            if (sudoku.columns[1].Contains(remainingNumbers[0]))
            {
                Debug.Log($"remainingNumbers: {{ {string.Join(", ", remainingNumbers)} }}");
                possibleNumbers = remainingNumbers.Except(sudoku.columns[1]).ToList();
                square.grid[2, 1] = possibleNumbers[0];
                square.grid[2, 2] = remainingNumbers[0];
                sudoku.columns[1].Add(square.grid[2, 1]);
                sudoku.columns[2].Add(square.grid[2, 2]);
            }
            else
            {
                square.grid[2, 1] = remainingNumbers[0];
                square.grid[2, 2] = remainingNumbers[1];
                sudoku.columns[1].Add(square.grid[2, 1]);
                sudoku.columns[2].Add(square.grid[2, 1]);
            }

            boxes[7].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, 1].ToString();
            boxes[8].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, 2].ToString();
        }

        //Final case, Column 0 may have none of the elements of remainingNumbers
        //It means the a column between 1 and 2 has 2 elements and the other only one
        if (sudoku.columns[0].Intersect(remainingNumbers).Count() == 0 && sudoku.columns[0].Count >= 2 && sudoku.columns[0].Count != 8)
        {
            if (sudoku.columns[0].Count == 2)
            {
                ShuffleList(remainingNumbers);

                for (int z = 0; z < 3; z++)
                {
                    square.grid[2, z] = remainingNumbers[z];
                    boxes[z + 6].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, z].ToString();
                    sudoku.columns[z].Add(square.grid[2, z]);
                    Debug.Log($"columns[{z}]: {{ {string.Join(", ", sudoku.columns[z])} }}");
                }
            }

            //Assign cells in case column 1 has two elements of remainingNumbers
            if (sudoku.columns[1].Intersect(remainingNumbers).Count() == 2)
            {
                possibleNumbers = remainingNumbers.Except(sudoku.columns[1]).ToList();
                square.grid[2, 1] = possibleNumbers[0];
                sudoku.columns[1].Add(square.grid[2, 1]);
                remainingNumbers.Remove(possibleNumbers[0]);
                possibleNumbers = remainingNumbers.Except(sudoku.columns[2]).ToList();
                square.grid[2, 2] = possibleNumbers[0];
                sudoku.columns[2].Add(square.grid[2, 2]);
                remainingNumbers.Remove(possibleNumbers[0]);
                square.grid[2, 0] = remainingNumbers[0];
                sudoku.columns[0].Add(square.grid[2, 0]);
            }

            //Assign cells in case of column 2 with two elements of remainingNumbers
            if (sudoku.columns[2].Intersect(remainingNumbers).Count() == 2)
            {
                possibleNumbers = remainingNumbers.Except(sudoku.columns[2]).ToList();
                square.grid[2, 2] = possibleNumbers[0];
                sudoku.columns[2].Add(square.grid[2, 2]);
                remainingNumbers.Remove(possibleNumbers[0]);
                possibleNumbers = remainingNumbers.Except(sudoku.columns[1]).ToList();
                square.grid[2, 1] = possibleNumbers[0];
                sudoku.columns[1].Add(square.grid[2, 1]);
                remainingNumbers.Remove(possibleNumbers[0]);
                square.grid[2, 0] = remainingNumbers[0];
                sudoku.columns[0].Add(square.grid[2, 0]);
            }

            for (int i = 0; i < 3; i++)
            {
                boxes[i + 6].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[2, i].ToString();
            }
        }
        */

    }
}
