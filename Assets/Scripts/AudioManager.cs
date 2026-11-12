using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    public AudioSource musicSource;

    private bool isMuted;

    private const string AUDIO_PREF_KEY = "AudioMuted";

    private void Awake()
    {
        Debug.Log("Audio Awake");
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Debug.Log("Audio Start");
        isMuted =
            PlayerPrefs.GetInt(AUDIO_PREF_KEY, 0) == 1;

        musicSource.mute = isMuted;

        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void ToggleAudio()
    {
        isMuted = !isMuted;

        musicSource.mute = isMuted;

        PlayerPrefs.SetInt(
            AUDIO_PREF_KEY,
            isMuted ? 1 : 0);

        PlayerPrefs.Save();
    }

    public bool IsMuted()
    {
        return isMuted;
    }

    public void SetMute(bool value)
    {
        isMuted = value;

        musicSource.mute = value;

        PlayerPrefs.SetInt(
            AUDIO_PREF_KEY,
            value ? 1 : 0);

        PlayerPrefs.Save();
    }
}