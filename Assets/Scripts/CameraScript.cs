using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**makes the camera follow the player around, but not turn when the player turns
 * */
public class CameraScript : MonoBehaviour
{
    public GameObject player; //the player
    private Vector3 offset; //the amount of distance from the player

    /**
     * sets offset to distance from player
    **/
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    /**
     * sets this position to distance from player in beginning + player position
     **/
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
