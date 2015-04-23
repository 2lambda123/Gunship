using UnityEngine;
using System.Collections;
using AGC;

public class splashscreen : MonoBehaviour {
	
 	public Material mat;
	
	public float fadeTime = 1.0f;
	public int nextscene = 1;
	private Tools agc;
	
	enum Fade {
		In, Out
	}

	IEnumerator Start()
	{		
		agc = new Tools();
		agc.Start(Application.productName);

		agc.log("dataPath: " + Application.dataPath);
		agc.log("platform: " + Application.platform);
		agc.log("systemLanguage: " + Application.systemLanguage);
		agc.log("installMode: " + Application.installMode);
		agc.log("temporaryCachePath: " + Application.temporaryCachePath);
		agc.log("Version of the runtime: " + Application.unityVersion);

		//mat.color.a = 0;
		mat.color = new Color(1, 1, 1,0); 
		yield return new  WaitForSeconds(0.5f);
		yield return StartCoroutine(Fademat(mat, fadeTime, Fade.In));
		yield return new  WaitForSeconds(0.25f);
		yield return StartCoroutine(Fademat(mat, fadeTime, Fade.Out));
		yield return new  WaitForSeconds(0.5f);
		Application.LoadLevel(nextscene);
	}

	IEnumerator Fademat(Material curentmat ,float timer,Fade fadeType) 
	{
		float start = fadeType == Fade.In ? 0.0f : 1.0f;
		float end = fadeType == Fade.In ? 1.0f : 0.0f;
		float i = 0.0f;
		float step = 1.0f / timer;
		while (i < 1.0f) {
			i += step * Time.deltaTime;
			//curentmat.color.a = new Mathf.Lerp(start, end, i) * 1;
			curentmat.color = new Color(1, 1, 1, Mathf.Lerp(start, end, i));
			//print("" + Mathf.Lerp(start, end, i));
			yield return null;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.LoadLevel(nextscene);
	}
}
