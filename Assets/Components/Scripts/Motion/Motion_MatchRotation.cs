using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Matches rotation to a given object

public class Motion_MatchRotation : MonoBehaviour {

	public GameObject referenceObject;
	
	void Update ()
	{
		if(referenceObject != null)
		{
			transform.rotation = Quaternion.Euler(referenceObject.transform.rotation.eulerAngles);
		}
		Debug.Log("<color=yellow>" + this + "</color>" + " rotation reference not assigned", gameObject);
	}
}