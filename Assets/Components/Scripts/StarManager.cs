using System;
using UnityEngine;

[System.Serializable]
public class Star
{
    public GameObject FeatureStar;
    public int layer;
}

public class StarManager : MonoBehaviour
{
    public ConstellationManager constellationManager;
    public SolarSystemManager solarSystemManager;

    public Star[] PuzzleStars;

    public void AssignStarsToLayers()
    {
        for (int i = 0; i < PuzzleStars.Length; i++)
        {
            PuzzleStars[i].FeatureStar.transform.parent = solarSystemManager.OrbitInstances[PuzzleStars[i].layer].transform;
        }
    }
}