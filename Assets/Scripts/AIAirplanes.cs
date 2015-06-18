using UnityEngine;
using System.Collections;
using AGC.Tools;

public class AIAirplanes : MonoBehaviour
{
    public Vector3 max = new Vector3(1, 1, 1);
    public Vector3 min = new Vector3(-1, -1, -1);
    public float Health = 10f;
    public float speed = 1;
    private bool kill;
    public bool spawn_particles;

    void Update()
    {
        Vector3 v = this.transform.position;
        if (!kill)
        {
            
            this.transform.Translate(Vector3.left * speed);
            if (v.x > max.x || v.x < min.x)
                Reset();
            if (v.y > max.y || v.y < min.y)
                Reset();
            if (v.z > max.z || v.z < min.z)
                Reset();
        }
        else
        {
            if (v.y < -8000)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void Reset()
    {
        Vector3 v  = this.transform.eulerAngles;
        this.transform.eulerAngles = new Vector3(Random.Range(-25, 25), Random.Range(v.y + 150, v.y + 210), Random.Range(-20, 20));
        this.transform.position = this.transform.position / 1.1f;
    }
    void OnCollisionEnter()
    {
        ApplyDamage(9999999f);
    }
    public void ApplyDamage(float d)
    {
        Health -= d;
        if (Health <= 0 && !kill)
        {
            if (spawn_particles)
            {
                GameObject trail = Instantiate(Resources.Load<GameObject>("Trail"), this.transform.position, Quaternion.identity) as GameObject;
                trail.transform.parent = this.transform;
                GameObject explosion = Instantiate(Resources.Load<GameObject>("Explosion"), this.transform.position, Quaternion.identity) as GameObject;
                Destroy(explosion, 5f);
            }
            this.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddTorque(Random.onUnitSphere * 1000); 
            rb.AddRelativeForce(Vector3.left * 7500);
            kill = true;
        }   
    }
    /*
     * Vector3 pos = this.transform.position;
     *  pos += Random.onUnitSphere * 5;
     * rb.AddExplosionForce(1000, pos, 50f);
     */
}