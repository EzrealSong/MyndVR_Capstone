using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitMode : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitBtn()
    {
        SceneManager.LoadScene("Game Menu");
    }
}
