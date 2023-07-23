using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMenuManager : MonoBehaviour
{
    public TextMeshProUGUI gameModeText = null;   //display game mode text
    [SerializeField] private string selectedGameMode;

    public void SelectGameMode(string mode)
    {
        selectedGameMode = mode;
        gameModeText.text = mode;
    }

    // public void OnButtonClick()
    // {
    //     _title.text = "Your new text is here";
    // }

    // void Update()
    // {

    // }
}
