using UnityEngine;

// Matches own rotation to a target object with given offsets

public class Motion_MatchPosition : MonoBehaviour {

	public Transform target;
	public float offsetX = 0f;
	public float offsetY = 0f;
	public float offsetZ = 10f;

	private Vector3 pos;
	
	void Update ()
	{
		if(target != null)
		{
			pos = target.position;
			transform.position = new Vector3(pos.x + offsetX, pos.y + offsetY, pos.z + offsetZ);
		}
		else
		Debug.Log("<color=yellow>" + this + "</color>" + " target not assigned", gameObject);
	}
}