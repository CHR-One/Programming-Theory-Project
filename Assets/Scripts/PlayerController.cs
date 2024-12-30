using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public string playerName;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void InsertNumber(int number)
    {
        // If the box is selected, the number is entered into the box through the mouse left click
        // If the box is not selected, the number is entered into the box after it is selected and when the box is selected with mouse left click
    }

    public void SelectBox()
    {
        // The box is selected when the mouse left click is pressed on it
    }

    public int SelectNumber()
    {
        // The number is selected when the mouse left click is pressed on it
        return 0;
    }
}
