using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateConstellationLine : MonoBehaviour
{
    private LineRenderer line;
    public GameObject[] stars;

    PuzzleStar[] puzzleStars;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        puzzleStars = new PuzzleStar[stars.Length];

        puzzleStars[0] = stars[0].GetComponent<PuzzleStar>();
        puzzleStars[1] = stars[1].GetComponent<PuzzleStar>();
    }

    private void Update()
    {
        if (stars.Length == 0)
            return;

        for (int i = 0; i < stars.Length; i++)
        {
            line.SetPosition(i, stars[i].transform.position);
        }

        if(puzzleStars[0].InPosition && puzzleStars[1].InPosition)
        {
            line.material.SetColor("_TintColor", new Color(1, 1, 1, 0.06f));
            //StartCoroutine(DoFade(new Color(1, 1, 1, 0.06f), new Color(1, 1, 1, 1), 0.5f));
        }
        else
        {
            line.material.SetColor("_TintColor", new Color(1, 1, 1, 0));
            //StartCoroutine(DoFade(new Color(1, 1, 1, 0.06f), new Color(1, 1, 1, 1), 0.5f));
        }
    }

    private IEnumerator DoFade(Color from, Color to, float time)
    {
        for (float t = 0.0f; t < time; t += Time.deltaTime)
        {
            var newColor = Color.Lerp(from, to, t);
            line.material.SetColor("_TintColor", newColor);
            yield return null;
        }
    }
}