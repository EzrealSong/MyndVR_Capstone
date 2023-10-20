using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Toggle toggleInput;
    public Button registerButton;
    public Button goToLoginButton;

    ArrayList credentials;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(WriteStuffToFile);
        goToLoginButton.onClick.AddListener(GoToLoginScene);

        if (File.Exists("Assets/Script_file/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines("Assets/Script_file/credentials.txt"));
        }
        else
        {
            File.WriteAllText("Assets/Script_file/credentials.txt", "");
        }
    }

    void GoToLoginScene()
    {
        SceneManager.LoadScene("Login");
    }

    void WriteStuffToFile()
    {
        bool isExists = false;

        credentials = new ArrayList(File.ReadAllLines("Assets/Script_file/credentials.txt"));
        foreach (var line in credentials)
        {
            string[] parts = line.ToString().Split(':');
            if (parts.Length == 3 && parts[0] == usernameInput.text)
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Username '{usernameInput.text}' already exists");
        }
        else
        {
            string toggleState = toggleInput.isOn ? "true" : "false";
            credentials.Add($"{usernameInput.text}:{passwordInput.text}:{toggleState}");
            File.WriteAllLines("Assets/Script_file/credentials.txt", (string[])credentials.ToArray(typeof(string)));
            Debug.Log("Account Registered");
        }
    }
}
