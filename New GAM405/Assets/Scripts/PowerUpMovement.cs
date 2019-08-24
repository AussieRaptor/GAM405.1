using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    //Values to set the movement behaviour of the pickup items
    private float powerUpSpeed = 3.6f;
    //Rotation speed for the pick up
    private float rotateSpeed = 90.0f;
    //Set how far the object moves up and down
    public float amplitude = 0.2f;
    //Set how quickly the object reaches each point
    public float frequency = 0.6f;

    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();

    void Start()
    {
        posOffset = transform.position;
    }
    
    void Update()
    {
        //How fast is the item moving up and down
        transform.Translate(0f, 0f, powerUpSpeed * Time.deltaTime);

        //How fast the item is rotating
        transform.Rotate(new Vector3(0.0f, Time.deltaTime * rotateSpeed));

        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
    }
}
