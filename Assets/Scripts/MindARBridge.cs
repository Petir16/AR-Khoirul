using UnityEngine;

public class MindARBridge : MonoBehaviour
{
    public ARGameplayManager gameplayManager;

    public void OnMarkerFound(string plantName)
    {
        Debug.Log("Marker = " + plantName);

        PlantManager.Instance
            .SetCurrentPlantByName(plantName);

        gameplayManager.OnPlantDetected();
    }
    public void TestARJagung()
    {
        OnMarkerFound("Jagung");
    }
    public void TestARPadi()
    {
        OnMarkerFound("Padi");
    }
    public void TestARTebu()
    {
        OnMarkerFound("Tebu");
    }
    public void TestARSingkong()
    {
        OnMarkerFound("Singkong");
    }
}