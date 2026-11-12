using UnityEngine;

public class CameraReporter : MonoBehaviour
{
    void Start()
    {
        Camera[] cams =
            FindObjectsOfType<Camera>(true);

        Debug.Log(
            "CAMERA COUNT = " +
            cams.Length
        );

        foreach (var cam in cams)
        {
            Debug.Log(
                cam.name +
                " | enabled=" +
                cam.enabled +
                " | clearFlags=" +
                cam.clearFlags +
                " | depth=" +
                cam.depth
            );
        }
    }
}