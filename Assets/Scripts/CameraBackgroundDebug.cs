using UnityEngine;

public class CameraBackgroundDebug : MonoBehaviour
{
    void Start()
    {
        Camera cam = GetComponent<Camera>();

        Debug.Log("Clear Flags = " + cam.clearFlags);
        Debug.Log("Background = " + cam.backgroundColor);
    }
}