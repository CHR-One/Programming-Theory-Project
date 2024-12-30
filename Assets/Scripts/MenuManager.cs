using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ChangeSettings()
    {
        SceneManager.LoadScene(4);
    }

    public void ShowScores()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {

    }

    public void ShowStats()
    {
        SceneManager.LoadScene(3);
    }
}
