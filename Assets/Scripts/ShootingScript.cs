using UnityEngine;
using System.Collections;
using AGC;

public class ShootingScript : MonoBehaviour {
	
	public float Damage = 1.0f;
	public float FireRate = 1.0f;
	public float Error = 1f;
	public GameObject Bullet;
	private float t = 0f;
	private Tools agc;

	void Start()
	{		
		agc = new Tools();
		agc.log ("ShootingScript loaded");
	}
	// Update is called once per frame
	void Update () 
	{
		if(t > 0)
			t-= Time.deltaTime;
		if(Input.GetButton("Fire1") && t <= 0){
			t = FireRate;
			Vector2 RiUC  = Random.insideUnitCircle * Error;
			RaycastHit hit;
			GameObject clone = Instantiate(Bullet, this.transform.position, Quaternion.identity) as GameObject;
			Vector3 v = transform.TransformDirection(RiUC.x,RiUC.y, 500);
			clone.GetComponent<Rigidbody>().velocity = v;
			clone.GetComponent<Rigidbody>().mass = 1000;
			Destroy(clone, 5);
			if (Physics.Raycast (this.transform.position,v, out hit, 20000)){
				if(hit.collider.tag == "ApplyDamage")
					hit.collider.SendMessage ("ApplyDamage", Damage);
			}
			Debug.DrawLine (this.transform.position,hit.point, Color.red);
		}
	}
}
