using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTicker : MonoBehaviour
{
    public int TicksPer360 = 180;

    private int tickSpacing;
    private int currentTick = 0;
    private float tickCounter = 0;

    Vector3 initialRotation;
    Vector3 previousRotation;
    Vector3 currentRotation;

    void Start()
    {
        tickSpacing = 360 / TicksPer360;
        initialRotation = transform.rotation.eulerAngles;
        currentRotation = initialRotation;
        previousRotation = initialRotation;
    }

    void Update()
    {
        currentRotation = transform.rotation.eulerAngles;

        if (currentRotation.y != previousRotation.y)
        {
            tickCounter += previousRotation.y - currentRotation.y;
            currentTick = (Mathf.RoundToInt(tickCounter * 100) / 100) / tickSpacing;
        }

        previousRotation = currentRotation;
    }

    void DoTick(int direction)
    {
        Debug.Log(currentTick);
    }
}
