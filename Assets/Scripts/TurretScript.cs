using UnityEngine;
using System.Collections;
using AGC.Tools;

public class TurretScript : MonoBehaviour {

	public float Damage = 1.0f;
	public float FireRate = 1.0f;
	public float Error = 1f;
	public GameObject Bullet;
	public AudioClip audio_clip;
	public GameObject player;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;	
	public float minimumX = -360F;
	public float maximumX = 360F;	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	private float rotationY = 0F;
	private float t = 0f;
	private AudioSource audio_source;
	private Camera player_cam;
	private Camera turret_cam;
	private CharacterController car_control;
	private bool can_shoot;

	
	void Start()
	{		
		AGCTools.log ("turretShooting_script loaded");
		audio_source = this.gameObject.AddComponent<AudioSource>();
		turret_cam = this.gameObject.AddComponent<Camera>();
		car_control = player.GetComponent<CharacterController>();
		player_cam = player.GetComponentInChildren<Camera>();
		can_shoot = false;
		turret_cam.enabled  = false;
		player_cam.enabled = true;
		car_control.enabled = true;
	}


	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			float dist = Vector3.Distance(player.transform.position, this.transform.position);
			if (dist < 1.5)
			{
				can_shoot = !can_shoot;
				turret_cam.enabled  = !turret_cam.enabled;
				player_cam.enabled = !player_cam.enabled;
				car_control.enabled = !car_control.enabled;
			}
		}
		if (can_shoot)
		{
			if(t > 0)
				t-= Time.deltaTime;
			if(Input.GetButton("Fire1") && t <= 0)
			{
				//AGCTools.log("Fire1");
				audio_source.clip = audio_clip;
				audio_source.Play();
				t = FireRate;
				Vector2 RiUC  = Random.insideUnitCircle * Error;
				RaycastHit hit;
				GameObject clone = Instantiate(Bullet, this.transform.position, Quaternion.identity) as GameObject;
				Vector3 v = transform.TransformDirection(RiUC.x,RiUC.y, 1000);
				clone.GetComponent<Rigidbody>().velocity = v;
				clone.GetComponent<Rigidbody>().mass = 1000;
				Destroy(clone, 5);
				if (Physics.Raycast (this.transform.position,v, out hit, 20000))
				{
					if(hit.collider.tag == "ApplyDamage")
						hit.collider.SendMessage ("ApplyDamage", Damage);
				}
				Debug.DrawLine (this.transform.position,hit.point, Color.red);
			}
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);	
		}
	}
}
