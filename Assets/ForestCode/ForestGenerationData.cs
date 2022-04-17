using UnityEngine;

[CreateAssetMenu(fileName = "ForestGenerationData.asset", menuName = "ForestGenerationData/Forest Data")]
public class ForestGenerationData : ScriptableObject
{
    public int numberofCrawlers;
    public int iterationMin;
    public int iterationMax; 
}
