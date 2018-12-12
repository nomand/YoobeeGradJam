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

    void Start()
    {
        UIPlanetSelector = FindObjectOfType<PlanetSelector>();

        PopulateUI();
        PopulateOrbits();
    }

    private void PopulateOrbits()
    {

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
        }

        var selector = Instantiate(UISelector, UIPlanetPositions[0], Quaternion.identity, UIContainer.transform);
        UIPlanetSelector.selectorGUI = selector;
    }
}