using System.Collections;
using UnityEngine;

public class UpdateConstellationLine : MonoBehaviour
{
    public GameObject[] stars;

    private const string fadeProperty = "_TintColor";

    private LineRenderer line;
    private PuzzleStar[] puzzleStars;
    private IEnumerator currentFade;

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
            line.material.SetColor(fadeProperty, new Color(1, 1, 1, 0.06f));
        }
        else
        {
            line.material.SetColor(fadeProperty, new Color(1, 1, 1, 0));
        }
    }
}