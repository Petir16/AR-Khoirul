using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HoeSkillCheck : MonoBehaviour
{
    [Header("UI References")]
    public RectTransform pointer;
    public RectTransform successZone;

    public Button hoeButton;
    public GameObject quizButton;
    public GameObject quizPanel;

    public TMP_Text resultText;

    [Header("Movement")]
    public float moveSpeed = 250f;

    public float minX = -150f;
    public float maxX = 150f;

    [Header("Settings")]
    public float failDelay = 1.5f;

    private bool moving;
    private bool finished;

    private float direction = 1f;

    public System.Action OnSuccess;

    public PlantGrowth plantGrowth;
    public GameObject Bar;
    public GameObject penjelasan;

    public CharacterAnimation characterAnim;
    public PlantInformation plantInfoUI;

    public QuizManager quizManager;


    private void Awake()
    {
        Debug.Log("Mini Games Awake");
    }
    private void Start()
    {
        Debug.Log("Mini Games Start");
        hoeButton.onClick.AddListener(PressHoe);

        quizButton.SetActive(false);

        plantGrowth.OnPlantMature += ShowQuizButton;

        hoeButton.gameObject.SetActive(false);
        Bar.SetActive(false);
        resultText.gameObject.SetActive(false);

        //StartMiniGame();
    }

    private void Update()
    {
        if (!moving || finished)
            return;

        MovePointer();
    }

    private void MovePointer()
    {
        Vector2 pos = pointer.anchoredPosition;

        pos.x += direction * moveSpeed * Time.deltaTime;

        if (pos.x >= maxX)
        {
            pos.x = maxX;
            direction = -1f;
        }

        if (pos.x <= minX)
        {
            pos.x = minX;
            direction = 1f;
        }

        pointer.anchoredPosition = pos;
    }

    public void StartMiniGame()
    {
        resultText.text = "";

        pointer.anchoredPosition = new Vector2(
            minX,
            pointer.anchoredPosition.y);

        direction = 1f;

        moving = true;
        finished = false;
    }

    public void PressHoe()
    {
        if (finished)
            return;

        moving = false;

        CheckResult();
    }

    private void CheckResult()
    {
        Rect pointerRect = GetWorldRect(pointer);
        Rect successRect = GetWorldRect(successZone);

        bool success = pointerRect.Overlaps(successRect);

        Debug.Log("Pointer Rect : " + pointerRect);
        Debug.Log("Success Rect : " + successRect);
        Debug.Log("Result : " + success);

        if (success)
        {
            Success();
        }
        else
        {
            Fail();
        }
    }

    private Rect GetWorldRect(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];

        rectTransform.GetWorldCorners(corners);

        return new Rect(
            corners[0].x,
            corners[0].y,
            corners[2].x - corners[0].x,
            corners[2].y - corners[0].y
        );
    }

    private void Success()
    {
        finished = true;

        resultText.text = "Berhasil mencangkul!";

        //characterAnim.PlayHoeAnimation();
        PlantData currentPlant = PlantManager.Instance.currentPlant;

        if (currentPlant == null)
        {
            Debug.LogError("Current Plant is NULL!");
            return;
        }

        string plantName = currentPlant.plantName;
        characterAnim.PlayPlantingAnimation(plantName);

        plantGrowth.SpawnSeed();

        hoeButton.gameObject.SetActive(false);
        Bar.SetActive(false);
        //penjelasan.SetActive(true);
        plantInfoUI.ShowPlantInfo(PlantManager.Instance.currentPlant);

        OnSuccess?.Invoke();
    }

    private void Fail()
    {
        finished = true;

        resultText.text = "Gagal! Coba lagi.";

        Debug.Log("FAIL");

        Invoke(nameof(RestartMiniGame), failDelay);
    }

    private void RestartMiniGame()
    {
        StartMiniGame();
    }
    private void ShowQuizButton()
    {
        quizButton.SetActive(true);

        resultText.text = "Tanaman berhasil tumbuh!";
    }
    public void OpenQuiz()
    {
        plantInfoUI.HidePlantInfo();
        quizButton.SetActive(false);

        quizManager.quizData =
        PlantManager.Instance.currentPlant.quizData;

        quizManager.StartQuiz();

        quizPanel.SetActive(true);

    }
    public void ShowGameplayUI()
    {
        hoeButton.gameObject.SetActive(true);
        Bar.SetActive(true);
        resultText.gameObject.SetActive(true);

        StartMiniGame();
    }
}