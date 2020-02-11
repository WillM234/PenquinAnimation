using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;//stores reference for the player game object

    private Vector3 offset;//stores offset between player and camera

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        //calculates and stores offset value. gets position distance between player and camera
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        //Sets position of the camera as the players, but offset by the calculated offset distance
    }
}
