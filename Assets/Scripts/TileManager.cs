using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
    *  allows tiles to spawn infinitely and at random, either to the front, left, or right of the previous tile
    *  50 tiles are spawned at the beginning 
    *  Also spawns coins at random throughout the game
    *  Also resets the game if the play dies
    **/

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public GameObject currentTile;
    private static TileManager instance;
    private int randomIndex;
    private int spawnPickup;


    public static TileManager Instance //sets instance equal to the game object that uses TileManager
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }


    }

    // Use this for initialization
    /**
     * generates 50 tiles at the start of the game
     * **/
    void Start()
    {

        for (int i = 0; i < 50; i++)
        {
            SpawnTile();

        }
    }

    /**
     * randomly spawns tiles and pickups (coins)  for each tile
     * */
    public void SpawnTile() //creates tiles
    {
        //generating random number between 0 and 1
        randomIndex = Random.Range(0, 3); //upper limit is not included in range

        currentTile = (GameObject)Instantiate(tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position, Quaternion.identity);
        //spawns tiles in random positions (either in front, to the left, or to the right of the previous one)

        spawnPickup = Random.Range(0, 15);

        if (spawnPickup == 0)//coins will spawn randomly, 1 in 14 chance
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true); //activiates coins
        }
    }

    /**
     *   game starts over
     **/
    public void ResetGame()
    {
        Application.LoadLevel(0);

    }


}
