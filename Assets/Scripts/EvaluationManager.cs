using TMPro;
using UnityEngine;

public class EvaluationManager : MonoBehaviour
{
    public QuizManager quizManager;

    public TMP_Text resultText;

    public GameObject penutup;
    public GameObject textObject;
    public GameObject BackButton;
    public GameObject quizButton;

    private void OnEnable()
    {
        ShowResult();
    }

    void ShowResult()
    {
        if (quizManager == null)
        {
            Debug.LogError("QuizManager belum diassign!");
            return;
        }

        if (quizManager.quizData == null)
        {
            Debug.LogError("QuizData kosong!");
            return;
        }

        string result = "";

        var quizData = quizManager.quizData;

        var selectedAnswers =
            quizManager.GetSelectedAnswers();

        for (int i = 0; i < quizData.questions.Count; i++)
        {
            QuestionData q = quizData.questions[i];

            int selected =
                quizManager.GetSelectedAnswers()[i];

            bool isCorrect =
                selected == q.correctAnswerIndex;

            string playerAnswerColor =
                isCorrect ?
                "#00FF00" :     // Hijau
                "#FF0000";      // Merah

            result +=
                "<b><color=#FFD700>Pertanyaan :</color></b> "
                + q.question +
                "\n";

            result +=
                "<b>Jawaban Anda :</b> "
                + "<color=" + playerAnswerColor + ">"
                + q.answers[selected]
                + "</color>\n";

            result +=
                "<b>Jawaban Benar :</b> "
                + "<color=#00FF00>"
                + q.answers[q.correctAnswerIndex]
                + "</color>\n\n";
        }

        resultText.text = result;

        Debug.Log(result);
    }
    public void Next()
    {
        gameObject.SetActive(false);

        penutup.SetActive(true);
        BackButton.SetActive(false);
        textObject.SetActive(false);
        quizButton.SetActive(false);
    }
}