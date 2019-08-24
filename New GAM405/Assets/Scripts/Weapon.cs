using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public Rigidbody projectile;
    public int damage;
    public float fireRate, nextTimeToFire;

    public int currentAmmo, maxAmmo;

    public int minProjectileSpeed, maxProjectileSpeed;

    public AudioClip gunshot;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        currentAmmo = maxAmmo;
    }

    void projectileFire()
    {
        int projectileSpeed = Random.Range(minProjectileSpeed, maxProjectileSpeed);

        Rigidbody projectileClone;
        projectileClone = Instantiate(projectile, transform.position, transform.rotation);

        // Give the cloned object an initial velocity along the current
        // object's Z axis
        projectileClone.velocity = transform.TransformDirection(Vector3.forward * projectileSpeed);

        audioSource.PlayOneShot(gunshot, 0.7f);

        currentAmmo--;
    }
    
    void Update()
    {
        if(Input.GetButton("Fire1") && currentAmmo > 0 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            projectileFire();
        }
    }
}
