using System;
using System.Collections;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public float growthTime = 3f;

    public Transform plantSpawnPoint;

    private GameObject currentPlant;

    public Action OnPlantMature;

    public void SpawnSeed()
    {
        ClearPlant();

        currentPlant = Instantiate(
            PlantManager.Instance.currentPlant.seed,
            plantSpawnPoint);

        StartCoroutine(GrowAfterDelay());
    }

    IEnumerator GrowAfterDelay()
    {
        yield return new WaitForSeconds(growthTime);

        GrowToMature();
    }

    public void GrowToMature()
    {
        ClearPlant();

        currentPlant = Instantiate(
            PlantManager.Instance.currentPlant.maturePlant,
            plantSpawnPoint.position,
            Quaternion.identity,
            plantSpawnPoint);

        OnPlantMature?.Invoke();
    }

    void ClearPlant()
    {
        if (currentPlant != null)
        {
            Destroy(currentPlant);
        }
    }
}