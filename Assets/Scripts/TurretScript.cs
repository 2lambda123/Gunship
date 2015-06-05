using UnityEngine;
using System.Collections;
using AGC.Tools;

public class TurretScript : MonoBehaviour
{
    public float Damage = 1.0f;
    public float FireRate = 1.0f;
    public float Error = 1f;
    public float enterDistace = 2f;
    public turret_types TurretType = turret_types.Normal;
    public Texture2D AimTex;
    public GameObject Bullet;
    public Transform[] TurretBarrels;
    public GameObject BulletCase;
    public Transform[] BulletExit;
    public Camera TurretCam;
    public AudioClip audio_clip;
    public GameObject player;
    public GameObject BlisterHull;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;

    private int shoot_from = 0;
    private float rotationY = 0F;
    private float rotationX = 0F;
    private float t = 0f;
    private AudioSource audio_source;
    private Camera player_cam;
    private Camera turret_cam;
    private CharacterController car_control;
    private bool can_shoot;
    private Vector3 org;
    private Vector3 blisterorg;

    public enum turret_types { Normal, Blister };


    void Start()
    {
        AGCTools.log("turretShooting_script loaded on: " + this.gameObject.name + " type: " + TurretType);
        audio_source = this.gameObject.AddComponent<AudioSource>();
        turret_cam = TurretCam;
        car_control = player.GetComponent<CharacterController>();
        player_cam = player.GetComponentInChildren<Camera>();
        can_shoot = false;
        turret_cam.enabled = false;
        player_cam.enabled = true;
        car_control.enabled = true;
        org = this.transform.localEulerAngles;
        if (BlisterHull != null) blisterorg = BlisterHull.transform.localEulerAngles;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float dist = Vector3.Distance(player.transform.position, this.transform.position);
            if (dist < enterDistace)
            {
                can_shoot = !can_shoot;
                turret_cam.enabled = !turret_cam.enabled;
                player_cam.enabled = !player_cam.enabled;
                car_control.enabled = !car_control.enabled;
            }
        }
        if (can_shoot)
        {
            if (TurretType == turret_types.Normal) UpdateNormal(); else UpdateBlister();

            if (t > 0)
                t -= Time.deltaTime;
            if (Input.GetButton("Fire1") && t <= 0)
            {
                //AGCTools.log("Fire1");
                audio_source.clip = audio_clip;
                audio_source.Play();
                t = FireRate;
                Vector2 RiUC = Random.insideUnitCircle * Error;
                RaycastHit hit;
                GameObject clone = Instantiate(Bullet, TurretBarrels[shoot_from].position, TurretBarrels[shoot_from].rotation) as GameObject;
                if (BulletCase != null)
                {
                    GameObject case_clone = Instantiate(BulletCase, BulletExit[shoot_from].position, BulletExit[shoot_from].rotation) as GameObject;
                    Vector3 vc = BulletExit[shoot_from].transform.TransformDirection(0, 0, 2);
                    case_clone.GetComponent<Rigidbody>().velocity = vc;
                    case_clone.GetComponent<Rigidbody>().mass = 0.01f;
                    Destroy(case_clone, 5);
                }
                Vector3 v = TurretBarrels[shoot_from].transform.TransformDirection(RiUC.x, RiUC.y, 1000);
                clone.GetComponent<Rigidbody>().velocity = v;
                clone.GetComponent<Rigidbody>().mass = 1000;
                Destroy(clone, 5);
                if (Physics.Raycast(this.transform.position, v, out hit, 20000))
                {
                    try
                    {
                        hit.collider.SendMessage("ApplyDamage", Damage);
                    }
                    catch
                    {
                    }
                }
                shoot_from++;
                if (shoot_from >= TurretBarrels.Length)
                    shoot_from = 0;

                Debug.DrawLine(this.transform.position, hit.point, Color.red);
            }
        }
    }

    void UpdateBlister()
    {

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        this.transform.localEulerAngles = new Vector3(0, rotationX, 0) + org;
        BlisterHull.transform.localEulerAngles = new Vector3(-rotationY, 0, 0) + blisterorg;
    }
    void UpdateNormal()
    {

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        this.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0) + org;

    }
    void OnGUI()
    {
        if (can_shoot && AimTex != null)
            GUI.Label(new Rect(Screen.width / 2 - AimTex.width / 2, Screen.height / 2 - AimTex.height / 2, AimTex.width, AimTex.height), AimTex);
    }
}
