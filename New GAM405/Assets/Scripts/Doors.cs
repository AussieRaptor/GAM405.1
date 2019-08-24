using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    //Reference to the enemy holder script
    public AllEnemy enemyScript;

    //Audio for the door unlocking
    public AudioClip doorBlip;
    //Reference the audiosource
    AudioSource audioSource;


    //References to each door in the game
    public GameObject LSD1, LSD2, LSD3, RSD1, RSD2, RSD3;
    //Reference the main pad in the hub room
    public GameObject pad;
    //Reference to the power box gameobject
    public GameObject powerBox;

    //Bool to 
    private bool count1, count2, count3, count4 = false;

    void Start()
    {
        SetColours();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        EnemyDead();
    }

    void EnemyDead()
    {
        //Check if all the enemies in the list have been removed
        if(enemyScript.LSR1.Count == 0 && count1 == false)
        {
            Debug.Log("All LSR1 enemies are dead");
            //Make sure this code doesn't run again
            count1 = true;
            //Make the associated door disappear
            LSD1.gameObject.SetActive(false);
            LSD2.gameObject.SetActive(false);
            //Play door unlock sound
            audioSource.PlayOneShot(doorBlip, 0.7f);
        }
        //Following scripts do the same as above for all enemy lists
        if(enemyScript.LSR2.Count == 0 && count2 == false)
        {
            Debug.Log("All LSR2 enemies are dead");

            count2 = true;

            LSD3.gameObject.SetActive(false);
            RSD1.gameObject.SetActive(false);

            audioSource.PlayOneShot(doorBlip, 0.7f);
        }
        if(enemyScript.RSR1.Count == 0 && count3 == false)
        {
            Debug.Log("All RSR1 enemies are dead");

            count3 = true;
            RSD3.gameObject.SetActive(false);

            audioSource.PlayOneShot(doorBlip, 0.7f);
        }
        if(enemyScript.RSR2.Count == 0 && count4 == false)
        {
            Debug.Log("All RSR2 enemies are dead");

            count4 = true;

            RSD2.gameObject.SetActive(false);

            audioSource.PlayOneShot(doorBlip, 0.7f);
        }


    }

    void SetColours()
    {
        //Set all doors material to red
        LSD1.GetComponent<Renderer>().material.color = Color.red;
        LSD2.GetComponent<Renderer>().material.color = Color.red;
        LSD3.GetComponent<Renderer>().material.color = Color.red;

        RSD1.GetComponent<Renderer>().material.color = Color.red;
        RSD2.GetComponent<Renderer>().material.color = Color.red;
        RSD3.GetComponent<Renderer>().material.color = Color.red;

        pad.GetComponent<Renderer>().material.color = Color.red;
    }
}
