using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[][] questionsAndAnswers;
    public string[][] matchedQuestionsAndAnswers;

    public TMP_Text reviewerQuestion;

    public ButtonController[] buttonsData;

    public CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        initializeQuestionsAndAnswers();
    }

    void initializeQuestionsAndAnswers()
    {
        // initalizes the questions and answers
        questionsAndAnswers = new string[][] { new string[] {"If 3x + 2 = 14 3x+2=14 what is the value of x?", "3","4","5","6"}};

        for (int i = 0; i < questionsAndAnswers.Length; i++)
        {
            reviewerQuestion.text = questionsAndAnswers[i][0].ToString();
            for (int j = 1; j < questionsAndAnswers[i].Length; j++)
            {
                buttonsData[j - 1].answerDataText.text = questionsAndAnswers[i][j].ToString();
            }
        }


        matchedQuestionsAndAnswers = new string[][] { new string[] {"If 3𝑥 + 2 = 14 3x+2=14 what is the value of 𝑥?", "4"}};
    }


    public void checkAnswer(string answer)
    {
        for (int i = 0; i < matchedQuestionsAndAnswers.Length; i++)
        {
            if (answer == matchedQuestionsAndAnswers[i][1])
            {
                characterController.showGameOverScreen(true);
            }
            else
            {
                characterController.showGameOverScreen(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
