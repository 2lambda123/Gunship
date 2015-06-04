using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AGC.mod;
using AGC.Tools;

public class GuiAdd : MonoBehaviour {
	public GameObject Game_object;

    public float min = 0;
    public float max = 1;

	// Use this for initialization
	void Start ()
	{
		List<string> AllTextures = new List<string>(AGCMod.IndexFileNames(".jpg"));
        AllTextures.AddRange(AGCMod.IndexFileNames(".png"));
		AGCTools.log("IndexFiles ");
		//float x = 0;
		foreach(string s in AllTextures)
		{
			GameObject clone = Instantiate(Game_object,new Vector3(max,0,0), Quaternion.identity) as GameObject;
			clone.name = s;
			Renderer r = clone.GetComponent<Renderer>();
            r.material.mainTexture = AGCMod.LoadTexture(s,512);
			max += 1.1f;
			AGCTools.log(""+s);
		}
	}
	void Update()
	{
		float x = this.transform.position.x + Input.GetAxisRaw("Mouse ScrollWheel")*5;
		this.transform.position = new Vector3( Mathf.Clamp(x,min,max),0,-5);
	}

}
