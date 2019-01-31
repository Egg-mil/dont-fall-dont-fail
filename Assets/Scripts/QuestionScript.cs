using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Sets question text to a random question, sets all answers active, 
 * and changes the answers text and tells them whether they are the correct answer
 * */

public class QuestionScript : MonoBehaviour
{
    public GameObject num0;//1st question
    public GameObject num1;//2nd question
    public GameObject num2;//3rd question
    private string[] questions = new string[] {"Solve for x: 32x=16","Find the slope of this line: y=8x+30",
    "What is 0.75 as a fraction?","12/9 + 51/9=?"}; // array of questions
    string[,] answers = new string[,]{
        { "1/2", "2", "8" },
        {"30","15/4", "8" },
        {"1","3/4","1/2" },
        {"12/81","7" ,"62/9"}
    }; // array of array of answers
    private int[] correct = new int[] { 1, 3, 2, 2 }; //array of correct answers
    Text text; // the text of this quesiton

    /**
     * sets text to this text
     * sets this text to a random question
     * sets all answers active
     * changes the answers text and tells them whether they are the correct answer
     **/
    void Start()
    {
        text = GetComponent<Text>();
        int random = (int)(Random.Range(0, questions.Length - 1));
        text.text = questions[random];

        int c = correct[random];

        num0.SetActive(true);
        num1.SetActive(true);
        num2.SetActive(true);
        AnswerScript.Instance.change(answers[random, 0], c == 1);
        Answer1Script.Instance.change(answers[random, 1], c == 2);
        Answer2Script.Instance.change(answers[random, 2], c == 3);

    }

}
