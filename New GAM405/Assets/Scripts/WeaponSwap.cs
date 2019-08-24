using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    //Which weapon ID is currently active
    public int selectedWeapon = 0;
    //Max amount of weapons the player can hold
    public int maxWeapon = 1;

    //Reference to the player progress script
    public PlayerProgress playerProgress;

    //Reference to the weapons
    public Transform rocket, machinegun;

    //Does the player have access to the rocket weapon?
    private bool rocketAccess;


    void Update()
    {
        //If you press the E key and the player has access to the rocket
        if(Input.GetKeyDown(KeyCode.E) && rocketAccess == true)
        {
            //Change the weapon ID to the next (rocket)
            selectedWeapon++;

            //If the selected weapon ID becomes greater than the max, set the weapon ID back to 0
            if(selectedWeapon > maxWeapon)
            {
                selectedWeapon = 0;
            }

            //If the selected weapon is 0, deactivate rocket and activate machine gun
            if(selectedWeapon == 0)
            {
                machinegun.gameObject.SetActive(true);
                rocket.gameObject.SetActive(false);
            }
            //If the selected weapon is 1, activate rocket and deactivate machine gun
            else
            {
                machinegun.gameObject.SetActive(false);
                rocket.gameObject.SetActive(true);
            }
        }

        if(playerProgress.hasRocket == true)
        {
            //If player has rocket, weapon ID becomes 1 (rocket)
            selectedWeapon = 1;

            //Activate rocket and deactivate machine gun
            rocket.gameObject.SetActive(true);
            machinegun.gameObject.SetActive(false);

            //Set hasRocket to false so the script only runs once
            playerProgress.hasRocket = false;
            //Player now has access to the rocket weapon
            rocketAccess = true;
        }
    }
}
