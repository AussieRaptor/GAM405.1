using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedDoor : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        //Collision with the rocket projectile
        if(collider.gameObject.tag == "RocketAmmo")
        {
            //Destroy the Door when rocket hits
            Destroy(gameObject);
        }
    }
}
