using UnityEngine;

public class ARGameplayManager : MonoBehaviour
{
    public HoeSkillCheck hoeSkillCheck;

    bool markerDetected = false;

    public void OnPlantDetected()
    {
        if (markerDetected)
            return;

        markerDetected = true;

        hoeSkillCheck.ShowGameplayUI();
    }
}