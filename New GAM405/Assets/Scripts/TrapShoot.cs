using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShoot : MonoBehaviour
{
    //Reference to the traps projectile
    public Rigidbody projectile;
    //Speed of the projectile
    public int projectileSpeed = 60;
    public int ammo;

    void OnTriggerEnter(Collider collider)
    {
        //If the player enters the trap and it still has ammo, trap shoots projectile
        if(collider.gameObject.tag == "Player" && ammo > 0)
        {
            Rigidbody projectileClone;
            projectileClone = Instantiate(projectile, transform.position, transform.rotation);

            // Give the cloned object an initial velocity along the current
            // object's Z axis
            projectileClone.velocity = transform.TransformDirection(Vector3.right * projectileSpeed);

            //Reduce the traps ammo by 1
            ammo--;
        }
    }
}
