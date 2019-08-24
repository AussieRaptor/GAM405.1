using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Weapon weapon;

    public Text playerHealth;
    public Text weaponAmmo;

    public GameObject blueKey;
    public GameObject greenKey;
    public GameObject lightning;

    void Update()
    {
        if(weaponAmmo != null)
        {
            weaponAmmo.text = weapon.currentAmmo.ToString();
        }

        if(playerHealth != null)
        {
            playerHealth.text = player.currentHealth.ToString();
        }



        if(PlayerProgress.hasBlue == true)
        {
            blueKey.gameObject.SetActive(true);
        }

        if(PlayerProgress.hasGreen == true)
        {
            greenKey.gameObject.SetActive(true);
        }

        if(PlayerProgress.hasPower == true)
        {
            lightning.gameObject.SetActive(true);
        }

    }

}
