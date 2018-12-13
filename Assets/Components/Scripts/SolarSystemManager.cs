using System;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour
{
    public GameObject[] Planets;

    public GameObject UIContainer;
    public LayerMask UIMask;
    public GameObject UISelector;
    public float UISpacing = 1;

    private Vector3[] UIPlanetPositions;
    private PlanetSelector UIPlanetSelector;

    public GameObject OrbitContainer;
    public GameObject OrbitPrefab;
    public float OrbitSpacing = 0.2f;

    [HideInInspector]
    public GameObject[] OrbitInstances { get; private set; }

    private LayerRotationController layerRotationController;
    private StarManager starManager;

    void Start()
    {
        Initialize();
        PopulateUI();
        starManager.AssignStarsToLayers();
        ScrambleOrbits();
    }

    private void Initialize()
    {
        starManager =             FindObjectOfType<StarManager>();
        UIPlanetSelector =        FindObjectOfType<PlanetSelector>();
        layerRotationController = FindObjectOfType<LayerRotationController>();

        layerRotationController.layers = new Transform [Planets.Length];
        UIPlanetPositions =              new Vector3   [Planets.Length];
        UIPlanetSelector.planets =       new GameObject[Planets.Length];
        OrbitInstances =                 new GameObject[Planets.Length];
    }

    private void CreateOrbit(int i, GameObject planet)
    {
        float offset = 1f + (i * OrbitSpacing);

        GameObject orbit = Instantiate(OrbitPrefab, Vector3.zero, Quaternion.identity, OrbitContainer.transform);
        orbit.gameObject.name = "Layer " + i;
        orbit.transform.localScale = new Vector3(offset, offset, offset);
        OrbitInstances[i] = orbit;

        GameObject body = Instantiate(planet, orbit.GetComponent<Orbit>().planetPlacement.transform.position, Quaternion.identity);
        body.transform.parent = orbit.transform;

        RandomizeOrbitOrientation(orbit);
        layerRotationController.layers[i] = orbit.transform;
    }

    private void RandomizeOrbitOrientation(GameObject orbit)
    {
        float x = UnityEngine.Random.Range(0, 20);
        float y = UnityEngine.Random.Range(0, 360);
        float z = UnityEngine.Random.Range(0, 20);
        orbit.transform.rotation = Quaternion.Euler(new Vector3(x, y, z));
    }

    private void PopulateUI()
    {
        float width = 0;

        for (int i = 0; i < Planets.Length; i++)
        {
            width -= UISpacing;
            UIPlanetPositions[i] = UIContainer.transform.position - new Vector3(width, 0, 0);
        }

        var offset = Planets.Length + 1;

        for (int i = 0; i < Planets.Length; i++)
        {
            UIPlanetPositions[i] += new Vector3(UIPlanetPositions[i].x - offset * UISpacing, 0, 0);
            var planet = Instantiate(Planets[i], UIPlanetPositions[i], Quaternion.identity, UIContainer.transform) as GameObject;
            planet.gameObject.RunOnChildren(child => child.layer = 9);
            UIPlanetSelector.planets[i] = planet;
            CreateOrbit(i, Planets[i]);
        }

        var selector = Instantiate(UISelector, UIPlanetPositions[0], Quaternion.identity, UIContainer.transform);
        UIPlanetSelector.selectorGUI = selector;
    }

    public void ScrambleOrbits()
    {
        foreach (GameObject orbit in OrbitInstances)
        {
            orbit.transform.Rotate(orbit.transform.up, UnityEngine.Random.Range(0, 360), Space.World);
        }
    }
}