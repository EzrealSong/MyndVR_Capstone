using UnityEngine;

public class RigidbodyVelocityController : MonoBehaviour
{
    public Rigidbody rb; // get rigidbody of ball
    public float newVelocity = 10.0f; // Velocity

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Vector3 newRigidbodyVelocity = Vector3.forward * newVelocity; 
            rb.velocity = newRigidbodyVelocity; 
        }
    }
}
