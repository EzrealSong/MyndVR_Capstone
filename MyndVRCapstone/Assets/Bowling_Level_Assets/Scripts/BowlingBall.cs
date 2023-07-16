using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    public float force;

    private List<Vector3> pinPositions;
    private List<Quaternion> pinRoatations;
    private Vector3 ballPosition;


    // Start is called before the first frame update
    void Start()
    {
        var pins = GameObject.FindGameObjectsWithTag("Pin");
        pinPositions = new List<Vector3>();
        pinRoatations = new List<Quaternion>();
        foreach(var pin in pins)
        {
            pinPositions.Add(pin.transform.position);
            pinRoatations.Add(pin.transform.rotation);
        }

        ballPosition = GameObject.FindGameObjectWithTag("Ball").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))                                                               //force forward
        GetComponent<Rigidbody>().AddForce(new Vector3(0,0,force));
        if(Input.GetKeyUp(KeyCode.LeftArrow))                                                           //left force
        GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0), ForceMode.Impulse);
        if(Input.GetKeyUp(KeyCode.RightArrow))                                                          //right force
        GetComponent<Rigidbody>().AddForce(new Vector3(-1,0,0), ForceMode.Impulse);
        if(Input.GetKeyUp(KeyCode.R))                                                                   //R reset
        {
            var pins = GameObject.FindGameObjectsWithTag("Pin");

            for(int i = 0; i < pins.Length; i++)
            {  
                var pinPhysics = pins[i].GetComponent<Rigidbody>();
                pinPhysics.velocity = Vector3.zero;
                pinPhysics.position = pinPositions[i];
                pinPhysics.rotation = pinRoatations[i];
                pinPhysics.velocity = Vector3.zero;
                pinPhysics.angularVelocity = Vector3.zero;

                var ball = GameObject.FindGameObjectWithTag("Ball");
                ball.transform.position = ballPosition;
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
        if(Input.GetKeyUp(KeyCode.B))                                                                          //B reset ball
        {
             var ball = GameObject.FindGameObjectWithTag("Ball");
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                ball.transform.position = ballPosition;
        }
        if(Input.GetKeyUp(KeyCode.Escape))  
        {
            Application.Quit();
        }
    } 
}
