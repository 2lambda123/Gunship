using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AGC.mod;
using AGC.Tools;

public class GuiAdd : MonoBehaviour {
	public GameObject Game_object;

	float min = 0;
	float max = 1;

	// Use this for initialization
	IEnumerator Start ()
	{
		string[] AllTextures = AGCMod.IndexFileNames();
		AGCTools.log("IndexFiles ");
		//float x = 0;
		for(int i = 0;i < AllTextures.Length;i++)
		{
			GameObject clone = Instantiate(Game_object,new Vector3(i*1.5f,0,0), Quaternion.identity) as GameObject;
			clone.name = AllTextures[i];
			WWW www = new WWW(AGCMod.FindTexture(AllTextures[i]));
			yield return www;
			Renderer r = clone.GetComponent<Renderer>();
			r.material.mainTexture = www.texture;
			max = i+5;
			AGCTools.log(i+" "+AllTextures[i]);
		}
	}
	void Update()
	{
		float x = this.transform.position.x + Input.GetAxisRaw("Mouse ScrollWheel")*5;
		this.transform.position = new Vector3( Mathf.Clamp(x,min,max),0,-5);
	}

}
