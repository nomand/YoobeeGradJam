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
    private Vector3[] PuzzleStarInitialPositions;

    public void AssignStarsToLayers()
    {
        PuzzleStarInitialPositions = new Vector3[PuzzleStars.Length];

        for (int i = 0; i < PuzzleStars.Length; i++)
        {
            PuzzleStarInitialPositions[i] = PuzzleStars[i].FeatureStar.transform.position;
            PuzzleStars[i].FeatureStar.transform.parent = solarSystemManager.OrbitInstances[PuzzleStars[i].layer].transform;
        }
    }

    public void ScrambleOrbits()
    {
        foreach(GameObject orbit in solarSystemManager.OrbitInstances)
        {
            orbit.transform.Rotate(orbit.transform.up, UnityEngine.Random.Range(0, 360));
        }
    }
}