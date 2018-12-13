using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStar : MonoBehaviour
{
    public bool InPosition { get; private set; }

    private Vector3 InitialPosition;
    private Material material;

    void Start()
    {
        InitialPosition = transform.TransformPoint(Vector3.zero);
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        CheckStarPositions();
    }

    private void CheckStarPositions()
    {
        var currentStarPosition = transform.TransformPoint(Vector3.zero);

        if (Vector3.SqrMagnitude(transform.TransformPoint(Vector3.zero) - InitialPosition) / 2 < 1f)
        {
            material.SetColor("_EmissionColor", Color.green * 2);
            InPosition = true;
        }
        else
        {
            material.SetColor("_EmissionColor", new Color(2.1f, 1.5f, 0));
            InPosition = false;
        }
    }
}