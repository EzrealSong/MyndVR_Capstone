using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSFX : MonoBehaviour
{
    public AudioSource soundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playThisSound()
    { 
        soundPlayer.Play(); 
    }
}
