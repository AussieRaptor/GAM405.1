using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    //Enemies health value
    public int health = 100;
    
    //Enemies damage value
    public int damage = 6;
    //Enemies shooting time inbetween projectiles 
    public float fireRate, nextTimeToFire;

    //Event to check if an enemy has been damaged
    public delegate void OnDamagedReceived();
    public static event OnDamagedReceived onDamage;

    //Reference to the player
    public Transform player;
    //Reference to the players weapons
    public Weapon machinegun, rocket;

    //Audio to play when a projectile is shot
    public AudioClip gunshot;
    //Reference to the audiosource
    AudioSource audioSource;

    //Values to deal with the enemy targeting and shooting the player
    public float targetDistance, enemyLookDistance, attackDistance, enemySpeed, damping;
    //Reference to the projectiles rigidbody
    public Rigidbody projectile;
    //Reference to the enemies renderer
    Renderer renderer;

    //Using these values you can adjust how consistent each shot is
    public int minProjectileSpeed, maxProjectileSpeed;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        //How far away is the player?
        targetDistance = Vector3.Distance(player.position, transform.position);

        //If the player is within the enemies look distance it will look at the player
        if(targetDistance < enemyLookDistance)
        {
            //When the enemy sees the player it turns yellow
            renderer.material.color = Color.yellow;
            lookAtPlayer();
            Debug.Log("Looking at player");
        }
        //If the player falls within the enemies attacking range and they are able to fire another shot they will attack
        if(targetDistance < attackDistance && Time.time >= nextTimeToFire)
        {     
            //When attacking the enemy will turn red
            renderer.material.color = Color.red;
            nextTimeToFire = Time.time + 1f / fireRate;
            projectileFire();
            Debug.Log("Enemy attacking!");
        }
    }

    //Method that handles the instantiation and firing of a projectile 
    void projectileFire()
    {
        //Before each shot the speed of the projectile is determined
        int projectileSpeed = Random.Range(minProjectileSpeed, maxProjectileSpeed);

        //Reference the projectile
        Rigidbody projectileClone;
        //Places the instantiated projectile in the scene
        projectileClone = Instantiate(projectile, transform.position, transform.rotation);

        //Give the projectile a velocity to propel forward
        projectileClone.velocity = transform.TransformDirection(Vector3.forward * projectileSpeed);

        //Audio plays for each gun shot
        audioSource.PlayOneShot(gunshot, 0.7f);
    }

    //Method for the enemy to look at the player
    void lookAtPlayer()
    {
        //Rotate enemy to look at the player
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        //Creates smooth rotation for the enemy
        transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
    }

    //
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "MGBullet")
        {
            //Remove enemy health to the amount of the player machine gun weapon
            health -= machinegun.damage;

            //Check if any scripts are listening to an enemy taking damage
            if(onDamage != null)
            {
                onDamage();
            }
            //Destroy projectile when it collides with the enemy
            Destroy(collider.gameObject);
        }

        if(collider.gameObject.tag == "RocketAmmo")
        {
            //Remove enemy health to the amount of the player machine gun weapon
            health -= rocket.damage;

            //Check if any scripts are listening to an enemy taking damage
            if(onDamage != null)
            {
                onDamage();
            }
            //Destroy projectile when it collides with the enemy
            Destroy(collider.gameObject);
        }
    }

    public void Update()
    {
        //Destroy enemy if their health is 0
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }
}
