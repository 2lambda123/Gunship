using UnityEngine;
using System.Collections;

public class turretSwitch_script : MonoBehaviour 
{
	public Transform gunseat;
	public GameObject player;


	public Camera TurretCamera;
	public Camera PlayerCamera;


	// Use this for initialization
	void Start () 
	{
		TurretCamera.enabled = false;
		PlayerCamera.enabled = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			TurretCamera.enabled  = !TurretCamera.enabled;
			PlayerCamera.enabled = !PlayerCamera.enabled;
			player.GetComponent<CharacterController>().enabled = !player.GetComponent<CharacterController>().enabled;
		}
	
	}

}