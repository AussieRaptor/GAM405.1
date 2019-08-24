using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    //Does the player have the key?
    public static bool hasBlue, hasGreen = false;

    //Reference to the main door gameobject
    public GameObject blueDoor, greenDoor;

    //Does the player have the power box
    public static bool hasPower;

    public bool hasRocket;

    public GameObject rocketPower, powerLight;

    void OnTriggerEnter(Collider collider)
    {
        //If the player collects a key from the chest
        if(collider.gameObject.tag == "Key1" && hasBlue == false)
        {
            //Set the bool to true to show that the player has the key
            hasBlue = true;
            Debug.Log("You have the first key!");
        }
        else if(collider.gameObject.tag == "Key2" && hasGreen == false && hasPower == false)
        {
            hasGreen = true;
            hasPower = true;
            Debug.Log("You have the second key!");
        }

        //If the player enters the trigger for the main doors and has the key
        if(collider.gameObject.tag == "MainDoorTrigger" && hasBlue == true)
        {
            //Deactivate object
            blueDoor.gameObject.SetActive(false);
            Debug.Log("Blue door has been deactivated");
        }

        if(collider.gameObject.tag == "MainDoorTrigger" && hasGreen == true)
        {
            greenDoor.gameObject.SetActive(false);
            Debug.Log("Green door has been deactivated");
        }

        //Collision with the rocket booth and player has the power source
        if(collider.gameObject.tag == "RocketBooth" && hasPower == true)
        {
            //Player has rocket
            hasRocket = true;
            //Set rocket to active weapon
            rocketPower.gameObject.SetActive(true);
            //Set the rocket booths power light to green
            powerLight.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
