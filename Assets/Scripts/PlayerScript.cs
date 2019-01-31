using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**Moves based on the arrow keys (forward, left, right) if player is alive
 * Ball will accelerate over time and if the Player is playing, 
 * the score will go up according to the speed of the ball. 
 * If Player touches a coin, 250 points are added to the score. 
 * The Player gets 1 chance to revive if they answer a question right and can make a question active.
 * If the questions is answered incorrectly, the player must reset
 * */
public class PlayerScript : MonoBehaviour
{

    public float speed; // the speed that the player is moving
    private Vector3 dir; // the direction it is going
    private bool isDead = true; // whether the player moves in Vector3 dir
    public GameObject question;
    private Vector3 lastPos; // position to go after question is answered correctly
    private static PlayerScript instance;  //the instance of the object w this script
    public bool fell = false; //whether 1st time this has fallen
    public GameObject reset; // reset button
    Text text; // text of score
    public GameObject score; // score of the game
    double sco = 0; // score of game as a double

    /**
     *   sets up variables
     *   zeros the vector
     *   sets text = to the game object score's text
     **/
    void Start()
    {
        dir = Vector3.zero;
        text = score.GetComponent<Text>();
    }

    // Update is called once per frame
    /**
     * INSTRUCTIONS FOR GAME: 4
     * Press up arrow to go forward
     * Press left arrow to go left
     * Press right arrow to go right
     * Ball will accelerate over time
     * If the Player is playing, the score will go up according to the speed of the ball
     * 
     * Note: the ball won't automatically go forward, you need to press up arrow to make it go forward again
     * */
    void Update()
    {
        if (!isDead && !dir.Equals(new Vector3(0, 0, 0)))
        {
            sco += (double)(speed / 25);
            text.text = "Score: " + (int)sco;
        }
        if (Input.GetKey(KeyCode.UpArrow) && !isDead)
        {


            dir = Vector3.forward;


        }


        if (Input.GetKey(KeyCode.LeftArrow) && !isDead)
        {


            dir = new Vector3(-1, 0, (float).02);

        }
        if (Input.GetKey(KeyCode.RightArrow) && !isDead)
        {

            dir = new Vector3(1, 0, (float).02);

        }
        if (speed < 15)
            speed *= (float)1.0005;
        float amtMove = speed * Time.deltaTime; // multiplying by deltaTime makes sure character moves the same amt on every device
        transform.position += dir * amtMove; //transforms position of object
    }

    /**
     *   when player touches a coin, make it disappear and add 250 pts to the player's score
     *   
     *    param other of type Collider
     **/
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            sco += 250;
            text.text = "Score: " + (int)sco;
        }
    }

    /**
     * starts the game by allowing player to move since isDead is false  
     **/
    public void start()
    {
        isDead = false;
    }

    /**
     *   Goes Back to the center of the last tile
     *   and slows down player
     **/
    public void goBack()
    {
        isDead = false;
        instance.transform.position = lastPos + new Vector3(0, 30, 0);
        speed -= 2;
        if (speed < 5)
            speed = 5;
    }

    /**
    *   kill player if they are no longer above a tile
    *   if it is the 1st time the player fell, then a question will pop up
    *   otherwise, the reset button will pop up immediatly
    *   sets the last position equal to the position of the tile collided with
    *   
    *    param other of type Collider
    **/
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            lastPos = other.transform.position;
            RaycastHit hit; //player/ball constantly sends out rays, detects what it hits
            Ray downRay = new Ray(transform.position, -Vector3.up);

            if (!Physics.Raycast(downRay, out hit) && !isDead) //if rays don't hit anything
            {
                isDead = true;
                if (!fell)
                {
                    //kill player
                    question.SetActive(true);
                    dir = new Vector3(0, 0, 0);
                    fell = true;
                }
                else
                {
                    reset.SetActive(true);
                }
            }

        }
    }

    /**
     *   sets instance equal to the game object that uses PlayerScript
     **/
    public static PlayerScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerScript>();
            }
            return instance;
        }


    }


}
