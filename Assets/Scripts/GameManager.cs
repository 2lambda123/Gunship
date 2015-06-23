using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public float gametimer = 300;//300
    public Transform[] spawnpoints;

    private GameObject player;
    private float timer = 1;
    private int damagetimer = 1;
    private GameObject damage;
    private GameObject[] bombs;
    private bool isdropt = false;
    private List<GameObject> damages;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        damages = new List<GameObject>(0);
        bombs = GameObject.FindGameObjectsWithTag("Bom");
        damage = Resources.Load("damage") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isdropt)
            gametimer -= Time.deltaTime / damagetimer;

        if (gametimer < 0 && !isdropt)
        {
            isdropt = true;
            gametimer = 0;
            foreach (GameObject b in bombs)
            {
                b.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        if (timer > -1)
            timer -= Time.deltaTime;

        if (timer < 0)
        {
            int aair = GameObject.FindGameObjectsWithTag("ApplyDamage").Length;
            timer = Random.Range(5000, 7500) / aair;
            //print(aair + " " + timer);
            Vector3 pos = spawnpoints[Random.Range(0, spawnpoints.Length)].position;
            GameObject g = Instantiate(damage, pos, Random.rotation) as GameObject;
            g.GetComponent<Repair>().player = player;
            damages.Add(g);
            damagetimer = damages.Count + 1;
            //timer = timer * damagetimer;

        }

    }
    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - 150, 10, 300, 40), "damages: " + (damagetimer - 1) + "\n Time left: " + FormatTime(gametimer));
        if (isdropt)
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 25, 300, 50), "U win!");

    }
    public void RemoveDamage(GameObject go)
    {
        damages.Remove(go);
        Destroy(go);
        damagetimer = damages.Count + 1;
    }
    string FormatTime(float seconds)
    {
        if (seconds > 60f)
            return Mathf.Floor(seconds / 60f) + " minutes and " + Mathf.Floor(seconds % 60) + " seconds";
        else
            return  Mathf.Floor(seconds) + " seconds";
    }
}
