using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelector : MonoBehaviour
{
    [HideInInspector]
    public int currentSelection = 0;

    public GameObject selectorGUI;
    public GameObject[] planets;

    void Update()
    {

        var step = Input.GetAxis("Mouse ScrollWheel");

        if (step > 0)
            currentSelection++;
        else if(step < 0)
            currentSelection--;

        if (currentSelection > planets.Length -1)
            currentSelection = 0;
        else if (currentSelection < 0)
            currentSelection = planets.Length -1;

        currentSelection = Input.GetKeyDown(KeyCode.Alpha1) ? 0 :
                           Input.GetKeyDown(KeyCode.Alpha2) ? 1 :
                           Input.GetKeyDown(KeyCode.Alpha3) ? 2 :
                           Input.GetKeyDown(KeyCode.Alpha4) ? 3 :
                           Input.GetKeyDown(KeyCode.Alpha5) ? 4 :
                           currentSelection; 

        SelectPlanet(currentSelection);
    }

    private void SelectPlanet(int planet)
    {
        selectorGUI.transform.position = planets[currentSelection].transform.position;
    }
}