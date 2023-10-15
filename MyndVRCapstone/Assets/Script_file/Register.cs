using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml;

public class Register : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Toggle isAdminToggle; // Add a toggle for admin access
    public Button registerButton;
    public Button loginButton;

    private string credentialsPath;
    private XmlDocument xmlDoc;

    private void Start()
    {
        registerButton.onClick.AddListener(WriteStuffToXML);
        loginButton.onClick.AddListener(GoToLoginScene);

        credentialsPath = Application.dataPath + "/credentials.xml";

        if (File.Exists(credentialsPath))
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(credentialsPath);
        }
        else
        {
            xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclaration);

            XmlNode root = xmlDoc.CreateElement("Credentials");
            xmlDoc.AppendChild(root);

            xmlDoc.Save(credentialsPath);
        }
    }

    private void GoToLoginScene()
    {
        SceneManager.LoadScene("Login");
    }

    private void WriteStuffToXML()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        string role = isAdminToggle.isOn ? "admin" : "user";

        if (IsUsernameExists(username))
        {
            Debug.Log($"Username '{username}' already exists");
        }
        else
        {
            XmlNode credentialsNode = xmlDoc.SelectSingleNode("Credentials");
            XmlNode userNode = xmlDoc.CreateElement("User");

            XmlNode usernameNode = xmlDoc.CreateElement("Username");
            usernameNode.InnerText = username;

            XmlNode passwordNode = xmlDoc.CreateElement("Password");
            passwordNode.InnerText = password;

            XmlNode roleNode = xmlDoc.CreateElement("Role");
            roleNode.InnerText = role;

            userNode.AppendChild(usernameNode);
            userNode.AppendChild(passwordNode);
            userNode.AppendChild(roleNode);

            credentialsNode.AppendChild(userNode);

            xmlDoc.Save(credentialsPath);
            Debug.Log("Account Registered");
        }
    }

    private bool IsUsernameExists(string username)
    {
        XmlNodeList userNodes = xmlDoc.SelectNodes("//User/Username");
        foreach (XmlNode node in userNodes)
        {
            if (node.InnerText == username)
            {
                return true;
            }
        }
        return false;
    }
}
