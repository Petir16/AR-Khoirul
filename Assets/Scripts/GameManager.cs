using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Questionnaire URL")]
    public string questionnaireURL = " ";

    private void Awake()
    {
        Instance = this;
        Debug.Log("Game Manager Awake");
    }
    private void Start()
    {
        Debug.Log("Game Manager Start");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Kuisioner()
    {
        Application.OpenURL(questionnaireURL);
        Debug.Log("Menuju URL");
    }
}