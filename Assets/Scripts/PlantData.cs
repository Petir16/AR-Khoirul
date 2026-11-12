using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class PlantData : ScriptableObject
{
    public string plantName;

    public List<PlantInfoPage> infoPages;

    public GameObject seed;

    //public GameObject stem;

    public GameObject maturePlant;

    public QuizData quizData;

}