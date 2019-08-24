using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{

    public void OnEnable()
    {
        //Adds the event when the player has died
        Player.onDeath += RestartScene;
    }

    //Listens for the player to be killed and resets the unity scene
    public void RestartScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(thisScene.name);
    }
}
