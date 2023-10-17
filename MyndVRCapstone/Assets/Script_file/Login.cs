using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public Button goToRegisterButton;

    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(login);
        goToRegisterButton.onClick.AddListener(moveToRegister);

        if (File.Exists(Application.dataPath + "/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/credentials.txt"));
        }
        else
        {
            Debug.Log("Credential file doesn't exist");
        }

    }



    // Update is called once per frame
    void login()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines("Assets/Script_file/credentials.txt"));

        foreach (var i in credentials)
        {
            string line = i.ToString();
            string[] parts = line.Split(':');
            if (parts.Length == 3 && parts[0].Equals(usernameInput.text) && parts[1].Equals(passwordInput.text))
            {
                isExists = true;
                bool toggleState = bool.Parse(parts[2]); // Parse the toggle state from the stored data
                loadSceneBasedOnToggle(toggleState);
                break;
            }
        }

        if (!isExists)
        {
            Debug.Log("Incorrect credentials");
        }
    }

    void loadSceneBasedOnToggle(bool toggleState)
    {
        if (toggleState)
        {
            //for admin page
            Debug.Log("Loading scene based on toggle: Scene A");
            SceneManager.LoadScene("Drill");
        }
        else
        {
            //for user page
            Debug.Log("Loading scene based on toggle: Scene B");
            SceneManager.LoadScene("Drill");
        }
    }


    void moveToRegister()
    {
        SceneManager.LoadScene("Register");
    }

 
}