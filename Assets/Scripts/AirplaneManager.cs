using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AGC.Settings;

public class AirplaneManager : MonoBehaviour
{

    public Vector3 max = new Vector3(1, 1, 1);
    public Vector3 min = new Vector3(-1, -1, -1);
    public float speed = 1;
    public float Health = 10f;
    public int amount = 5;
    public bool spawn_particles;

    List<GameObject> airplanes = new  List<GameObject>();

    // Use this for initialization
    void Start()
    {
        spawn_particles = AGCSettings.FindCFGBool("SpawnParticles");
        for (int i = 0; i < amount; i++)
        {
            airplanes.Add ( Instantiate(Resources.Load<GameObject>("Airplane")));
        }
        foreach (GameObject a in airplanes)
        {
            a.AddComponent<AIAirplanes>().Health = Health;
            a.GetComponent<AIAirplanes>().speed = speed;
            a.GetComponent<AIAirplanes>().spawn_particles = spawn_particles;
            a.GetComponent<AIAirplanes>().max = max;
            a.GetComponent<AIAirplanes>().min = min;
            //a.transform.rotation = Random.rotation;
            a.transform.position = new Vector3(Random.Range(max.x / 2, max.x / 1.1f), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
        }
    }
  
}
