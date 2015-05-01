using UnityEngine;
using System.Collections;

public class Turbulence : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.localEulerAngles = new Vector3(Random.Range(-0.1f,0.1f), Random.Range(-0.1f,0.1f), Random.Range(-0.1f,0.1f));
	}
}
