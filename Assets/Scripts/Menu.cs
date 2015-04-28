using UnityEngine;
using System.Collections;
using AGC.mod;
using AGC.Tools;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string[] n = AGCModLoader.IndexFiles();
		foreach(string s in n)
		{
			AGCTools.log(s);
		}
	}

}