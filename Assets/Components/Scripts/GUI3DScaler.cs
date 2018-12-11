using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI3DScaler : MonoBehaviour
{
    public GameObject ui;
    Vector3 icons;

    void Start()
    {
        icons = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, 1f));
        ui.transform.position = icons;
    }

    void Update()
    {

    }
}