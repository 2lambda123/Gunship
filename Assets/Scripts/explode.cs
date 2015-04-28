using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {
	public GameObject particlesystemAAA;
	public float delayTime = 5.0f;

	private float startTime;


	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (Time.time - startTime >= delayTime) {
			if(particlesystemAAA.GetComponent<AudioSource>().isPlaying){
				particlesystemAAA.GetComponent<AudioSource>().Stop();
			}
			particlesystemAAA.GetComponent<ParticleSystem> ().Play ();
			particlesystemAAA.GetComponent<AudioSource> ().Play ();
			startTime = Time.time;
		}

	}

}

