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

    private LayerRotationController LayerRotationController;

    void Start()
    {
        UIPlanetSelector = FindObjectOfType<PlanetSelector>();
        LayerRotationController = FindObjectOfType<LayerRotationController>();
        LayerRotationController.layers = new Transform[Planets.Length];
        PopulateUI();
    }

    private void CreateOrbit(int i, GameObject planet)
    {
        float offset = 1f + (i * OrbitSpacing);

        var orbit = Instantiate(OrbitPrefab, Vector3.zero, Quaternion.identity, OrbitContainer.transform);
        orbit.gameObject.name = "Layer " + i;
        orbit.transform.localScale = new Vector3(offset, offset, offset);

        var body = Instantiate(planet, new Vector3(0, 0, 10 + offset), Quaternion.identity);
        body.transform.position = orbit.GetComponent<Orbit>().planetPlacement.transform.position;
        body.transform.parent = orbit.transform;

        RandomizeOrbitOrientation(orbit);

        LayerRotationController.layers[i] = orbit.transform;
    }

    private void RandomizeOrbitOrientation(GameObject orbit)
    {
        float x = UnityEngine.Random.Range(0, 40);
        float y = UnityEngine.Random.Range(0, 360);
        float z = UnityEngine.Random.Range(0, 40);
        orbit.transform.rotation = Quaternion.Euler(new Vector3(0, y, z));
    }

    private void PopulateUI()
    {
        UIPlanetPositions = new Vector3[Planets.Length];
        UIPlanetSelector.planets = new GameObject[Planets.Length];

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
}