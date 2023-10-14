using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_verification : MonoBehaviour
{
    public InputField username;
    public InputField password;

    public GameObject[] canvas;
    // Start is called before the first frame update
    private void Start()
    {
        canvas[0].SetActive(true);
    }
    public void CheckValidation()
    {
        string uname = username.text;
        string pward = password.text;

        if(uname == "test123" && pward == "test123")
        {
            Debug.Log("Log in Successfully");
        }
        else if(uname == "" || pward == "")
        {
            Debug.Log("Please Enter correct information");

        }
        else
        {
            Debug.Log("Please enter Username and Password");
        }
    }
}
