using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;

    [Header("Character Position")]
    public Transform characterRoot;

    [Header("Animation Offset")]
    //public Vector3 hoeOffset;
    public Vector3 seedOffset;
    public Vector3 plantOffset;
    public Vector3 throwOffset;

    [Header("Animation Rotation")]
    public Vector3 seedRotation;
    public Vector3 plantRotation;
    public Vector3 throwRotation;

    private void ApplyCharacterTransform(Vector3 position, Vector3 rotation)
    {
        characterRoot.localPosition = position;
        characterRoot.localRotation = Quaternion.Euler(rotation);
    }

    public void PlayHoeAnimation()
    {
        animator.SetTrigger("HoeTrigger");
    }
    public void PlaySeedAnimation()
    {
        ApplyCharacterTransform(seedOffset, seedRotation);
        animator.SetTrigger("SeedTrigger");
    }
    public void PlayPlantAnimation()
    {
        ApplyCharacterTransform(plantOffset, plantRotation);
        animator.SetTrigger("PlantTrigger");
    }
    public void PlayThrowAnimation()
    {
        ApplyCharacterTransform(throwOffset, throwRotation);
        animator.SetTrigger("ThrowTrigger");
    }
    public void PlayPlantingAnimation(string plantName)
    {
        if (string.IsNullOrEmpty(plantName))
        {
            Debug.LogWarning("Plant name is empty.");
            return;
        }

        switch (plantName)
        {
            case "Tebu":
                Debug.Log("Playing HOE animation for Tebu");
                PlayHoeAnimation();
                break;

            case "Jagung":
                Debug.Log("Playing THROW animation for Jagung");
                PlayThrowAnimation();
                break;

            case "Padi":
                Debug.Log("Playing SEED animation for Padi");
                PlaySeedAnimation();
                break;

            case "Singkong":
                Debug.Log("Playing PLANT animation for Singkong");
                PlayPlantAnimation();
                break;

            default:
                Debug.LogWarning(
                    "No planting animation configured for plant: "
                    + plantName
                );
                break;
        }
    }
}