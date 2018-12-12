using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI3DScaler : MonoBehaviour
{
    public GameObject ui;
    Vector3 iconsPlacement;
    new Camera camera;
    Vector2 resolution;

    void Start()
    {
        resolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        camera = GetComponent<Camera>();
        iconsPlacement = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, 3f));
        ui.transform.position = iconsPlacement;
    }

    void Update()
    {
        if(Screen.currentResolution.width != resolution.x || Screen.currentResolution.height != resolution.y)
        {
            iconsPlacement = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, 3f));
            resolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        }
    }
}