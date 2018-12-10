using UnityEngine;

// Aligns itself in a direction of the target object.

public class Motion_PointAt : MonoBehaviour {

	public Transform target;
	public float dampen = 0.8f;

	private Vector3 offset;

	void Update ()
	{
		var pos = new Vector3();

		if(target != null)
		{
			pos = target.transform.position;
			var rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampen);
		}
		else
			Debug.Log("<color=yellow>" + this + "</color>" + " aim target not assigned", gameObject);
	}
}