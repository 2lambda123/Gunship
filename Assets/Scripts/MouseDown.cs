using UnityEngine;
using System.Collections;
using AGC.Settings;

public class MouseDown : MonoBehaviour {

	// Use this for initialization
	void OnMouseDown () 
	{
		AGCSettings.WriteCFGSetting("Logo",this.gameObject.name);
		Application.LoadLevel(0);
	}

}
