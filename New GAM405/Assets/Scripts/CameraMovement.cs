using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Reference to the player
    public Transform player;

    //Generate smoother camera movement
    public float smoothSpeed = 0.125f;
    //Set where the camera will be positioned in 3D space
    public Vector3 offset;

    void LateUpdate()
    {
        //Finds the players position and adds the camera offset amount
        transform.position = player.position + offset;
    }

}
