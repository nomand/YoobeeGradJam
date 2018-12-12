using System;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour
{
    public GameObject[] Planets;
    public GameObject UI;
    public GameObject[] Orbits;

    private Vector3[] UIPlanetPositions;

    void Start()
    {
        PopulateUI();
        PopulateOrbits();
    }

    private void PopulateOrbits()
    {
        for (int i = 0; i < Planets.Length; i++)
        {

        }
    }

    private void PopulateUI()
    {

    }

    void Update()
    {

    }
}