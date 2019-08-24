using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{
    //Set how long until a projectile is destroyed
    public float timeToDeath = 2.0f;
    
    private void Start()
    {
        //Destroy projectile after an amount of time
        Destroy(gameObject, timeToDeath);
    }
}
