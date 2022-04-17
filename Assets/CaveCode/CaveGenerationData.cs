using UnityEngine;

[CreateAssetMenu(fileName = "CaveGenerationData.asset", menuName = "CaveGenerationData/Cave Data")]
public class CaveGenerationData : ScriptableObject
{
    public int numberofCrawlers;
    public int iterationMin;
    public int iterationMax; 
}
