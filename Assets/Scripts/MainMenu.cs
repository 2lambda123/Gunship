using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Button1 () 
	{
		Application.LoadLevel("Game");
	}
	void Button2 () 
	{
		Application.LoadLevel("Settings");
	}

}
