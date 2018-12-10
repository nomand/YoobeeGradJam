// bob an object up and down smoothly

using UnityEngine;
using System.Collections;

public class Motion_Bobbing : MonoBehaviour {

    private float waveAngle = 0.0f;
    private float initialY;

    public float amplitude = 0.25f;
    public float frequency = 0.4f;

    void Start()
    {
        initialY = transform.position.y;
    }
    
	void Update ()
    {
        idleBob();
	}

    void idleBob()
    {
        waveAngle += Time.deltaTime * frequency;

        float x = transform.position.x;
        float y = initialY + amplitude * Mathf.Cos(waveAngle + frequency);
        float z = transform.position.z;

        transform.localPosition = new Vector3(x, y, z);
    }
}