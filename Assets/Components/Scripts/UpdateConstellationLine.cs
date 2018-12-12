using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateConstellationLine : MonoBehaviour
{
    LineRenderer line;

    public GameObject[] stars;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (stars.Length == 0)
            return;

        for (int i = 0; i < stars.Length; i++)
        {
            line.SetPosition(i, stars[i].transform.position);
        }
    }
}