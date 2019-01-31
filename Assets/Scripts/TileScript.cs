using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * manages interactions between the player and tiles
 * and spawns additional tiles as player passes through each tile
 * 
 * */
public class TileScript : MonoBehaviour
{
    public GameObject player;

    /**
     * another tile is spawned if player is in front of tile
     * */
    void Update()
    {
        if (player != null)
            if (player.transform.position.z > transform.position.z)
                TileManager.Instance.SpawnTile();
    }

    /**
     * spawns more tiles when the player touches another tile
     * 
     * param other of type Collider
     * */
    void OnTriggerExit(Collider other) //do when something goes through the trigger, the collision box
    {

        if (other.tag == "Player")//set player tag to player
        {
            TileManager.Instance.SpawnTile();

        }
    }

}
