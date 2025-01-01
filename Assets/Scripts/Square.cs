using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    public GameObject box1, box2, box3, box4, box5, box6, box7, box8, box9;
    private readonly int[] Numbers = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[] row1 = new int[3];
    public int[] row2 = new int[3];
    public int[] row3 = new int[3];
    private List<int> remainingNumbers = new List<int>();
    private List<int> possibleNumbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillBox()
    {
        Debug.Log("FillBox");
    }
}
