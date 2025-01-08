using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;

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
        
        for (int k = 0; k < 3; k++)
        {
            for (int j = 0; j < 3; j++)
            {                
                Debug.Log($"STARTING cycle [{k}, {j}]");
                Debug.Log("remainingNumbers: { " + string.Join(", ", remainingNumbers) + " }");
                possibleNumbers = remainingNumbers.Except(sudoku.columns[j]).ToList();                

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
}
