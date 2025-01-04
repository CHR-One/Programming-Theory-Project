using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

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
                possibleNumbers = remainingNumbers.Except(sudoku.columns[j]).ToList();               
                ShuffleList(possibleNumbers);
                square.grid[k, j] = possibleNumbers.First();                
                sudoku.columns[j].Add(square.grid[k, j]);
                remainingNumbers.Remove(square.grid[k, j]);
                boxes[j + 3 * k].GetComponentInChildren<TextMeshProUGUI>().text = square.grid[k, j].ToString();
            }
        }
        remainingNumbers.Clear();
    }
}
