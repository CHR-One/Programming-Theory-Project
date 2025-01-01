using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public Sudoku sudoku;
    private int timeBonus = 0;
    private int bonus = 1;
    private int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize objects
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        sudoku = GameObject.Find("Sudoku").GetComponent<Sudoku>();
        // Register player name to save pass it to the highscores

        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitGame()
    {
        // Initialize necessary gameobjects

        // Register player name to save it in the highscores

        // Read the level value to launch the right sudoku level of difficulty

        // Generate the sudoku grid

        // Hide the boxes on the basis of the level of difficulty and activate the number boxes

        // Prepare the timer and start when the first number is inserted in the grid
    }

    private void Win()
    {
        // If all the boxes are filled with right numbers, the player wins the game
        // Stop the timer
        //Show the win screen
        //Save player name, score, time and level of difficulty in the highscores file
        //Update statistics file
    }

    private void Lose()
    {
        // If player commits 3 mistakes, the player loses the game
        // Stop the timer
        // Show the lose screen
        // Update statistics file
        //Ask the player to play again: if so, start again the same problem
    }

    private void StartAgain()
    {

    }

    private void SaveHighScores()
    {

    }

    private void UpdateStatistics()
    {

    }

    private void ShowWinScreen()
    {

    }

    private void ShowLoseScreen()
    {

    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void PauseGame()
    {

    }

    private void ResumeGame()
    {

    }

    private void Error()
    {

    }

    private void SaveGame()
    {

    }

    private void LoadGame()
    {

    }
}
