using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemy : MonoBehaviour
{
    //List of enemies grouped into their respective rooms
    public List <Enemy> LSR1, LSR2, RSR1, RSR2;

    //Audio for enemies death
    public AudioClip death;
    //Reference to the audiosource
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnEnable()
    {
        //Event to check if an enemy has been damaged and check their health to remove if below 1
        Enemy.onDamage += CheckHealth;
    }

    void CheckHealth()
    {
        //For loop to check if any enemies from the list have been killed
        for(int i = 0; i < LSR1.Count; i++)
        {
            //Check if any enemies have 0 health
            if(LSR1[i].health < 1)
            {
                //Remove from list if dead
                LSR1.RemoveAt(i);
                Debug.Log("Removed from list");
                //Play death audio
                audioSource.PlayOneShot(death);
            }
        }
        //Last 3 For loops do the same as above to all lists of enemies 
        for(int i = 0; i < LSR2.Count; i++)
        {
            if(LSR2[i].health < 1)
            {
                LSR2.RemoveAt(i);
                Debug.Log("Removed from list");
            }
        }
        for(int i = 0; i < RSR1.Count; i++)
        {
            if(RSR1[i].health < 1)
            {
                RSR1.RemoveAt(i);
                Debug.Log("Removed from list");
            }
        }
        for(int i = 0; i < RSR2.Count; i++)
        {
            if(RSR2[i].health < 1)
            {
                RSR2.RemoveAt(i);
                Debug.Log("Removed from list");
            }
        }
    }
}
