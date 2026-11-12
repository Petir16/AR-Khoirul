using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [Header("UI")]
    public Button audioButton;

    public Image iconImage;

    [Header("Icons")]
    public Sprite audioOnSprite;

    public Sprite audioOffSprite;

    private void Start()
    {
        audioButton.onClick.AddListener(OnAudioClicked);

        RefreshIcon();
    }

    public void OnAudioClicked()
    {
        if (AudioManager.Instance == null)
            return;

        AudioManager.Instance.ToggleAudio();

        RefreshIcon();
    }

    private void RefreshIcon()
    {
        if (AudioManager.Instance == null)
            return;

        bool muted =
            AudioManager.Instance.IsMuted();

        iconImage.sprite =
            muted ?
            audioOffSprite :
            audioOnSprite;
    }

    private void OnEnable()
    {
        RefreshIcon();
    }
}