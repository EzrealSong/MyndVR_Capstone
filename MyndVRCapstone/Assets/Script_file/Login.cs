using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public Button goToRegisterButton;
    public TMP_Text errorText;



    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        errorText.text = "";
        loginButton.onClick.AddListener(LoginUser);
        goToRegisterButton.onClick.AddListener(MoveToRegister);
        

        if (File.Exists("Assets/Script_file/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines("Assets/Script_file/credentials.txt"));
        }

        OpenKeyboard();

    }


    public void LoginUser()
    {
        bool isExists = false;

        foreach (var i in credentials)
        {
            string line = i.ToString();
            string[] parts = line.Split(':');
            if (parts.Length == 6 && parts[0].Equals(usernameInput.text) && parts[1].Equals(passwordInput.text))
            {
                isExists = true;
                bool toggleState = bool.Parse(parts[5]); // Parse the toggle state from the stored data
                LoadSceneBasedOnToggle(toggleState);
                break;
            }
        }

        if (!isExists)
        {
            errorText.text = "Incorrect credentials";
        }
    }

    void LoadSceneBasedOnToggle(bool toggleState)
    {
        if (toggleState)
        {
            // for admin page
            Debug.Log("Loading scene based on toggle: Scene A");
            SceneManager.LoadScene("Game Menu"); // Change to the correct scene name for the admin page
        }
        else
        {
            // for user page
            Debug.Log("Loading scene based on toggle: Scene B");
            SceneManager.LoadScene("Game Menu"); // Change to the correct scene name for the user page
        }
    }

    public void MoveToRegister()
    {
        SceneManager.LoadScene("Register");
    }

    public void SkipBtn()
    {
        SceneManager.LoadScene("Game Menu");
    }

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("");
    }
}