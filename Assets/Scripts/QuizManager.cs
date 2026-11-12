using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Quiz Data")]
    public QuizData quizData;

    [Header("UI")]
    public TMP_Text questionText;

    public Button[] answerButtons;

    public TMP_Text[] answerTexts;

    [Header("Panels")]
    public GameObject quizPanel;
    public GameObject evaluationPanel;

    private int currentQuestionIndex;

    //private int score;

    private List<int> selectedAnswers =
        new List<int>();

    public void StartQuiz()
    {
        currentQuestionIndex = 0;

        //score = 0;

        ShowQuestion();
    }

    void ShowQuestion()
    {
        QuestionData question =
            quizData.questions[currentQuestionIndex];

        questionText.text =
            question.question;

        for (int i = 0; i < 4; i++)
        {
            answerTexts[i].text =
                question.answers[i];

            int index = i;

            answerButtons[i].onClick.RemoveAllListeners();

            answerButtons[i].onClick.AddListener(() =>
            {
                SelectAnswer(index);
            });
        }
    }

    void SelectAnswer(int answerIndex)
    {
        QuestionData question =
            quizData.questions[currentQuestionIndex];

        selectedAnswers.Add(answerIndex);

        /*if (answerIndex ==
            question.correctAnswerIndex)
        {
            score++;
        }*/

        currentQuestionIndex++;

        if (currentQuestionIndex >=
            quizData.questions.Count)
        {
            FinishQuiz();
        }
        else
        {
            ShowQuestion();
        }
    }

    void FinishQuiz()
    {
        quizPanel.SetActive(false);

        evaluationPanel.SetActive(true);

        Debug.Log(
        "Selected Answers Count = " +
        selectedAnswers.Count);

        /*Debug.Log(
            "Quiz Finished. Score: " +
            score);*/
    }

    /*public int GetScore()
    {
        return score;
    }*/

    public List<int> GetSelectedAnswers()
    {
        return selectedAnswers;
    }
}