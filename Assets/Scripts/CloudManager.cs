using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AGC.Settings;

public class CloudManager : MonoBehaviour
{
    //public GameObject cloud;
    public float speed = 10f;
    public int amount = 5;
    public float max;
    GameObject[] clouds;
    bool on;

    // Use this for initialization
    void Start()
    {
        on = AGCSettings.FindCFGBool("UseClouds");
        if (on)
        {
            amount = AGCSettings.FindCFGInt("AmountClouds");
            if (amount < 50)
                amount = 50;
            clouds = new GameObject[amount];
            for (int i = 0; i < amount; i++)
            {
                clouds[i] = Instantiate(Resources.Load<GameObject>("Cloud"));

            }
            foreach (GameObject c in clouds)
            {
                c.transform.position = Random.insideUnitSphere * max;
            }
        }
    }

    //* Update is called once per frame 
    void Update()
    {
        if (on)
        {
            foreach (GameObject c in clouds)
            {
                c.transform.position += Vector3.right * speed;
                if (c.transform.position.x > max)
                {
                    c.transform.position = Random.insideUnitSphere * max;
                    c.transform.position = new Vector3(c.transform.position.x - max, c.transform.position.y + max, c.transform.position.z);
                }

            }
        }
    }
}
