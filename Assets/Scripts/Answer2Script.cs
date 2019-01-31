using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * If answer is correct, player goes back to the center of the tile fallen off from.
 *  If it's not, then the reset button shows up and the question and answers disappear
 * */
public class Answer2Script : MonoBehaviour
//almost exactly answerscript and answerscript1 but cannot extend each other/compile into 1
//because otherwise the objects will all do the same things at the same time
{
    public GameObject reset; // the reset button
    bool cor; // whether this answer is right
    private static Answer2Script instance; //the instance of the object w this script
    public GameObject question; //the question (which also created this)
    public GameObject ans1; // another answer
    public GameObject ans2;// another answer

    /**
     *  If this is the correct answer, the player goes back to the center of the tile fallen off from 
     *  If its not, then the reset button shows up and the question and answers disappear
     **/
    public void onClick()
    {
        if (cor)
            PlayerScript.Instance.goBack();
        else
            reset.SetActive(true);
        gameObject.active = false;
        question.SetActive(false);
        ans1.SetActive(false);
        ans2.SetActive(false);
    }

    /**
   *   Parameter String x: the string that this answer is and sets its text to
   *   Parameter bool t: the boolean of whether this answer is right
   *   
   *   sets cor to parameter t
   *   sets the text in the child to input string x
   **/
    public void change(string x, bool t)
    {
        cor = t;
        GetComponentInChildren<Text>().text = x;
    }

    /**
     *   sets instance equal to the game object that uses Answer1Script
     **/
    public static Answer2Script Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Answer2Script>();
            }
            return instance;
        }


    }
}