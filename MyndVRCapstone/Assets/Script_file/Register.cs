﻿using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEditor;
using TMPro;

[System.Serializable]
public class UserCredentials
{
    public string username;
    public string password;
    public string name;
    public string height;
    public string gender;
    public bool toggleState;
 


}

public class Register : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField nameInput;
    public TMP_InputField heightInput;
    public TMP_InputField GenderInput;
    public Toggle toggleInput;
    public Button registerButton;
    public Button goToLoginButton;
    bool anyInputEmpty = true;
    public TMP_Text errorText;
    public TMP_InputField[] inputFields;

    // The list to store all user credentials
    List<UserCredentials> allCredentials;
    ArrayList credentials;

    void Start()
    {
        

        registerButton.onClick.AddListener(WriteStuffToFile);
        goToLoginButton.onClick.AddListener(GoToLoginScene);

        if (File.Exists("Assets/Script_file/credentials.json"))
        {
            string json = File.ReadAllText("Assets/Script_file/credentials.json");
            allCredentials = JsonUtility.FromJson<List<UserCredentials>>(json);
        }
        else
        {
            allCredentials = new List<UserCredentials>();
        }

        if (File.Exists("Assets/Script_file/credentials.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines("Assets/Script_file/credentials.txt"));
        }
        else
        {
            File.WriteAllText("Assets/Script_file/credentials.txt", "");
        }

        OpenKeyboard();
    }



    public void GoToLoginScene()
    {
        SceneManager.LoadScene("Login");

    }


    public void WriteStuffToFile()
    {
        bool isExists = false;
        //if(anyInputEmpty == true)
        //{
        //    OnInputChange();
        //}

        credentials = new ArrayList(File.ReadAllLines("Assets/Script_file/credentials.txt"));
        foreach (var line in credentials)
        {
            string[] parts = line.ToString().Split(':');
            if (parts.Length == 3 && parts[0] == usernameInput.text)  // Change to nameInput.text
            {
                isExists = true;
                errorText.text = "User already exists in credentials.txt";
                return;
            }
        }

        if (string.IsNullOrEmpty(nameInput.text))
        {
            // Display an error message for empty name
            errorText.text = "Information cannot be empty";
            return;
        }

        if (isExists)
        {
            errorText.text = "User already exists";
           
            return;
        }
        else
        {
            string toggleState = toggleInput.isOn ? "true" : "false";
            string name = nameInput.text;
            string height = heightInput.text;
            string gender = GenderInput.text;

            credentials.Add($"{usernameInput.text}:{passwordInput.text}:{name}:{height}:{gender}:{toggleState}");
            File.WriteAllLines("Assets/Script_file/credentials.txt", (string[])credentials.ToArray(typeof(string)));
            errorText.text = "Data Registered";
            SceneManager.LoadScene("Login");
        }

        foreach (var cred in allCredentials)
        {
            if (cred.username == usernameInput.text)
            {
                isExists = true;
                errorText.text = "Data already exists. Removing existing data.";
                // Optionally, you can update the existing user data here if needed.
                break;
            }
        }

        // Create a UserCredentials object
        UserCredentials userCredentials = new UserCredentials
        {
            username = usernameInput.text,
            password = passwordInput.text,
            name = nameInput.text,
            height = heightInput.text,
            gender = GenderInput.text,
            toggleState = toggleInput.isOn
        };

        if (!isExists)
        {
            // Add the new UserCredentials to the list
            allCredentials.Add(userCredentials);

            // Serialize the updated list to JSON
            string allCredentialsJson = JsonUtility.ToJson(allCredentials);

            // Write the updated JSON to the credentials.json file
            File.WriteAllText("Assets/Script_file/credentials.json", allCredentialsJson);

            // Optionally, write the user-specific JSON file
            string userJson = JsonUtility.ToJson(userCredentials);
            File.WriteAllText($"Assets/Script_file/User_Data/{usernameInput.text}.json", userJson);

            Debug.Log("Data Registered");
        }
        else
        {
            // Optionally, handle the case when the username already exists.
            //ShowErrorDialog($"Username '{usernameInput.text}' already exists. Data not registered.");
            Debug.Log($"Username '{usernameInput.text}' already exists. Data not registered.");
        }


    }

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("");
    }

}