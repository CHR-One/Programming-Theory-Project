using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku : MonoBehaviour
{
    public GameObject[] squares;

    private void Start()
    {
        squares = new GameObject[9];
    }

    public void GenerateGrid()
    {
        // At every square box is associated a number and hidden
    }

    public void GenerateProblem()
    {
        // Generate a sudoku problem, showing only some numbers on the basis of the level of difficulty
    }

    public void FillBox()
    {
        // Fill the right number in the specific box
        // It depends on the square where the box is placed
    }
}
