using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;

    public List<PlantData> allPlants;

    public PlantData currentPlant;

    private void Awake()
    {
        Instance = this;
        Debug.Log("Plant Manager Awake");
    }
    private void Start()
    {
        Debug.Log("Plant Manager Start");
    }

    public void SetCurrentPlantByName(
        string plantName)
    {
        foreach (var plant in allPlants)
        {
            if (plant.plantName == plantName)
            {
                currentPlant = plant;

                Debug.Log(
                    "Current Plant = "
                    + plant.plantName);

                return;
            }
        }

        Debug.LogWarning(
            "Plant tidak ditemukan: "
            + plantName);
    }
    public void TestAR()
    {
        SetCurrentPlantByName("Singkong");
    }
    public void TestAR2()
    {
        SetCurrentPlantByName("Tebu");
    }
    public void TestAR3()
    {
        SetCurrentPlantByName("Padi");
    }
    public void TestAR4()
    {
        SetCurrentPlantByName("Jagung");
    }
}