﻿using UnityEngine;
using System.Collections;
using System.IO;
using AGC.Tools;
using AGC.mod;

public class Skin : MonoBehaviour {
	Renderer r;
    /*
	IEnumerator Start() {
		r = GetComponent<Renderer>();
		string t = AGCMod.FindTexture("Player.png");
		if(t != null)
		{
			WWW www = new WWW(t);
			yield return www;
			r.material.mainTexture = www.texture;
		}
		string[] test = AGCMod.IndexFilesPaths();
		foreach(string s in test)
		{
			AGCTools.log(s);
		}
	}
     * */
}

