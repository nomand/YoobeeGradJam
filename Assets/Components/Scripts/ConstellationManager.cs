using System.Collections;
using UnityEngine;

[System.Serializable]
public class StarGroups : IEnumerator, IEnumerable
{
    public GameObject[] Stars;

    private int position = -1;
    public GameObject line;

    public IEnumerator GetEnumerator(){ return (IEnumerator)this; }
    public bool MoveNext() { position++; return (position < Stars.Length); }
    public void Reset() { position = 0; }
    public object Current { get { return Stars[position]; }}
}

public class ConstellationManager : MonoBehaviour
{
    public GameObject LinePrefab;
    public StarGroups[] StarGroups;

    private void Start()
    {
        foreach(StarGroups group in StarGroups)
        {
            var thisLine = Instantiate(LinePrefab).GetComponent<UpdateConstellationLine>();
            thisLine.gameObject.transform.parent = transform;
            group.line = thisLine.gameObject;

            thisLine.stars = new GameObject[group.Stars.Length];

            for (int i = 0; i < group.Stars.Length; i++)
            {
                thisLine.stars[i] = group.Stars[i];
            }
        }
    }
}