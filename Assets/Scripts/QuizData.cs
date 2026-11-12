using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/Quiz Data")]
public class QuizData : ScriptableObject
{
    public List<QuestionData> questions;
}