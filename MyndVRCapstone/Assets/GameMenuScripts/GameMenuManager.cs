using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public TextMeshProUGUI gameModeText = null;   //display game mode text
    [SerializeField] private string selectedGameMode;

    public void SelectGameMode(string mode)
    {
        selectedGameMode = mode;
        gameModeText.text = mode;
    }

    
    public void StartGame() {  
        SceneManager.LoadScene(selectedGameMode);  
    }  

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    
    
}
