using System;
using UnityEngine;

[System.Serializable]
public class Star
{
    public GameObject FeatureStar;
    public int layer;
    public bool inPosition;
}

public class StarManager : MonoBehaviour
{
    public ConstellationManager constellationManager;
    public SolarSystemManager solarSystemManager;

    public Star[] PuzzleStars;
    private Vector3[] PuzzleStarInitialPositions;

    private void Update()
    {
        CheckStarPositions();
    }

    public void AssignStarsToLayers()
    {
        PuzzleStarInitialPositions = new Vector3[PuzzleStars.Length];

        for (int i = 0; i < PuzzleStars.Length; i++)
        {
            PuzzleStarInitialPositions[i] = PuzzleStars[i].FeatureStar.transform.position;
            PuzzleStars[i].FeatureStar.transform.parent = solarSystemManager.OrbitInstances[PuzzleStars[i].layer].transform;
        }
    }

    private void CheckStarPositions()
    {
        for (int i = 0; i < PuzzleStars.Length; i++)
        {
            var currentStarPosition = PuzzleStars[i].FeatureStar.transform.TransformPoint(PuzzleStars[i].FeatureStar.transform.position);

            if (Vector3.Distance(currentStarPosition, PuzzleStarInitialPositions[i]) < 2f)
            {
                PuzzleStars[i].FeatureStar.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green * 2);
                PuzzleStars[i].inPosition = true;
            }
            else
            {
                PuzzleStars[i].FeatureStar.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(2.1f, 1.5f, 0));
                PuzzleStars[i].inPosition = false;
            }
        }
    }
}