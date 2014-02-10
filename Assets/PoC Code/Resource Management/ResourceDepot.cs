using UnityEngine;
using System.Collections;

public class ResourceDepot : MonoBehaviour {
	
	int storedResource; 
	
	// Use this for initialization
	void Start () {
		storedResource = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Receive resources and put them in the inventory, reterning any that are abouve the capacity. 
	public int DropOff(int resourceAmount)
	{
		storedResource += resourceAmount;
		
		return 0;
	}
}
