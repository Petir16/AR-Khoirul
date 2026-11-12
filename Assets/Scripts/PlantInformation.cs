using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantInformation : MonoBehaviour
{
    [Header("Panel")]
    public GameObject panel;

    [Header("UI")]
    public TMP_Text plantNameText;

    public TMP_Text descriptionText;

    //public TMP_Text pageText;

    //public Image infoImage;

    public Button nextButton;

    public Button backButton;

    private PlantData currentPlant;

    private int currentPage;

    private void Start()
    {
        nextButton.onClick.AddListener(NextPage);
        backButton.onClick.AddListener(PreviousPage);

        panel.SetActive(false);
    }

    public void ShowPlantInfo(PlantData plant)
    {
        currentPlant = plant;

        currentPage = 0;

        panel.SetActive(true);

        RefreshUI();
    }

    public void HidePlantInfo()
    {
        panel.SetActive(false);
    }

    private void RefreshUI()
    {
        if (currentPlant == null)
            return;

        plantNameText.text =
            currentPlant.plantName;

        PlantInfoPage page =
            currentPlant.infoPages[currentPage];

        descriptionText.text =
            page.description;

        /*infoImage.sprite =
            page.image;*/

        /*pageText.text =
            (currentPage + 1) +
            " / " +
            currentPlant.infoPages.Count;*/

        backButton.interactable =
            currentPage > 0;

        nextButton.interactable =
            currentPage <
            currentPlant.infoPages.Count - 1;
    }

    private void NextPage()
    {
        if (currentPage >=
            currentPlant.infoPages.Count - 1)
            return;

        currentPage++;

        RefreshUI();
    }

    private void PreviousPage()
    {
        if (currentPage <= 0)
            return;

        currentPage--;

        RefreshUI();
    }
}