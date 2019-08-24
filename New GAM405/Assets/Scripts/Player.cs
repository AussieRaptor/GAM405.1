using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Set players max possible health
    public int maxHealth = 100;
    //Players current health while playing
    public int currentHealth;
    //Players movement speed
    public float speed = 10f;


    //Reference to the enemy
    public Enemy enemy;

    //Reference to the weapon script
    public Weapon weapon;
    //Reference to the health pick up item
    public Health healthUp;
    //Reference to the ammo pick up item
    public Ammo ammoUp;
    //Reference the arrow gameobject
    public Arrow arrow;



    public CharacterController controller;

    //Event which broadcasts the players death
    public delegate void OnDeath();
    public static event OnDeath onDeath;

    //Reference to the player rigidbody
    Rigidbody rb;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        rb = GetComponent<Rigidbody>();

        //Set the current health to the max health on start
        currentHealth = maxHealth;
    }

    void Update()
    {
        //Character movement using character controller
        Vector3 move = new Vector3 (Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        controller.Move(move * Time.deltaTime * speed);

        //Makes sure the players current health cannot go past the maximum health
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        //Check if the player is dead
        Death();
    }

    void FixedUpdate()
    {
         // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //Collision with the health pick up item
        if(collider.gameObject.tag == "Health")
        {
            //Add health pick ups value to players health
            currentHealth += healthUp.healthAdded;
            //Destroy the health pick up item
            Destroy(collider.gameObject);
        }

        //Collision with the ammo pick up item
        if(collider.gameObject.tag == "Ammo")
        {
            //Add ammo pick ups value to players ammo count
            weapon.currentAmmo += ammoUp.ammoAdded;
            //Destroy the ammo pick up item
            Destroy(collider.gameObject);
        }

        //Collision with an enemies bullet
        if(collider.gameObject.tag == "EnemyBullet")
        {
            //Remove damage amount from player health
            currentHealth -= enemy.damage;
        }

        //Collision with the traps arrow object
        if(collider.gameObject.tag == "Arrow")
        {
            //Remove damage amount from player health
            currentHealth -= arrow.damage;
        }
    }

    //Check if the player is dead
    void Death()
    {
        //If the current health is 0 or less, the player is dead
        if(currentHealth < 1)
        {
            //Destroys the player gameobject
            Destroy(gameObject);

            //check if anyone is listening to the players death
            if(onDeath != null)
            {
                onDeath();
            }
        }
    }
}
 