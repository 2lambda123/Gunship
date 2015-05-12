using UnityEngine;
using System.Collections;
using AGC.mod;
using AGC.Tools;
using AGC.Settings;

public class LoadUserTexture : MonoBehaviour 
{

	public string TextureName;
	public Material material;
	
	IEnumerator Start() 
	{
		string n = AGCSettings.FindCFGSetting(TextureName);
		AGCTools.log("TextureName name: " + n);
		if(n == null)
			n = "Logo.png";
		string t = AGCMod.FindTexture(n);
		if(t != null)
		{
			WWW www = new WWW(t);
			yield return www;
			material.mainTexture = www.texture;
		}
	}

}
