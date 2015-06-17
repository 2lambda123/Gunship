using UnityEngine;
using System.Collections;
using AGC.Tools;

public class AIAirplanes : MonoBehaviour
{
    public Vector3 max = new Vector3(1, 1, 1);
    public Vector3 min = new Vector3(-1, -1, -1);
    public float Health = 10f;
    public float speed = 1;

    void Update()
    {
        Vector3 v = this.transform.position;
        this.transform.Translate(Vector3.left * speed);
        if (v.x > max.x || v.x < min.x)
            Reset();
        if (v.y > max.y || v.y < min.y)
            Reset();
        if (v.z > max.z || v.z < min.z)
            Reset();
    }
    void Reset()
    {
        Vector3 v  = this.transform.eulerAngles;
        this.transform.eulerAngles = new Vector3(Random.Range(-25, 25), Random.Range(v.y + 150, v.y + 210), Random.Range(-20, 20));
        this.transform.position = this.transform.position / 1.1f;
    }
    public void ApplyDamage(float d)
    {
        Health -= d;
        if (Health <= 0)
            Destroy(this.gameObject);
    }

}