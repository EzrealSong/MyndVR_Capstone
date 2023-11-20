using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControler : MonoBehaviour
{
    public int count = 0;
    bool pin1 = false;
    bool pin2 = false;
    bool pin3 = false;
    bool pin4 = false;
    bool pin5 = false;
    bool pin6 = false;
    bool pin7 = false;
    bool pin8 = false;
    bool pin9 = false;
    bool pin10 = false;
    bool pin11 = false;
    bool pin12 = false;

    public TMP_Text PinCount;
    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        PinCount.text = "Count: " + count.ToString();
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pin1")
        {
            pin1 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin2")
        {
            pin2 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin3")
        {
            pin3 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin4")
        {
            pin4 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin5")
        {
            pin5 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin6")
        {
            pin6 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin7")
        {
            pin7 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin8")
        {
            pin8 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin9")
        {
            pin9 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin10")
        {
            pin10 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin11")
        {
            pin11 = true;
            count++;
        }
        if(collision.gameObject.tag == "Pin12")
        {
            pin12 = true;
            count++;
        }

    }

}
