using UnityEngine;
using System.Collections;

public class SteepnessChecker : MonoBehaviour {

	public bool tooSteep;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		tooSteep = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		tooSteep = false;
	}
}
