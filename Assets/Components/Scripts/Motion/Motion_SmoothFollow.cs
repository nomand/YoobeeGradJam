using UnityEngine;

// Smooth match position to target object

public class Motion_SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
	{
        if(target != null)
        {
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        Debug.Log("<color=yellow>" + this + "</color>" + " target not assigned", gameObject);
    }
}