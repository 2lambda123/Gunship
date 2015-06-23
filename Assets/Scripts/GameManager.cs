using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public float gametimer = 300;//300
    public GameObject FinalCam;
    public GameObject spawnpointsroot;

    private GameObject player;
    private Transform[] spawnpoints;
    private float timer = 0;
    private int damagetimer = 1;
    private GameObject damage;
    private GameObject lookat;
    private GameObject[] bombs;
    private bool isdropt = false;
    private List<GameObject> damages;
    private int repairs = 0;
    private int GodModeProgress = 0;
    private float CheatDelay = 0f;
    private bool GodMode = false;



    // Use this for initialization
    void Start()
    {
        spawnpoints = spawnpointsroot.GetComponentsInChildren<Transform>();
        FinalCam.SetActive(false);
        player = GameObject.FindWithTag("Player");
        damages = new List<GameObject>(0);
        bombs = GameObject.FindGameObjectsWithTag("Bom");
        damage = Resources.Load("damage") as GameObject;
        lookat = bombs[Random.Range(0, bombs.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Analytics.CustomEvent("ExitGame", new Dictionary<string, object> {
            { "Airplaines", GameObject.FindGameObjectsWithTag("ApplyDamage").Length },
            { "Win", "didnt win" },
            { "repairs", repairs }});
            Application.LoadLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            foreach (Transform t in spawnpoints)
            {
                GameObject g = Instantiate(damage, t.position, Random.rotation) as GameObject;
                g.GetComponent<Repair>().player = player;
                damages.Add(g);               
            }
            damagetimer = damages.Count + 1;
        }
        UpdateCheats();
        if (isdropt)
            FinalCam.transform.LookAt(lookat.transform);

        if (isdropt)
            gametimer -= Time.deltaTime;
        else
            gametimer -= Time.deltaTime / damagetimer;

        if (gametimer < 0 && !isdropt)
        {
            isdropt = true;
            FinalCam.SetActive(true);
            player.SetActive(false);
            gametimer = 20;
            foreach (GameObject b in bombs)
            {
                b.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        if (gametimer < 0 && isdropt)
        {
            Analytics.CustomEvent("ExitGame", new Dictionary<string, object> {
            { "Airplaines", GameObject.FindGameObjectsWithTag("ApplyDamage").Length },
            { "Win", "did win" },
            { "repairs", repairs }});
            Application.LoadLevel(1);
        }

        if (timer > -1)
            timer -= Time.deltaTime;

        if (timer < 0 && !GodMode)
        {
            repairs++;
            int aair = GameObject.FindGameObjectsWithTag("ApplyDamage").Length;
            timer = Random.Range(2000, 4000) / aair;
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
        if (isdropt)
            GUI.Box(new Rect(Screen.width / 2 - 150, 25, 300, 50), "You win!");
        else
            GUI.Box(new Rect(Screen.width / 2 - 150, 10, 300, 40), "damages: " + (damagetimer - 1) + "\n Time left: " + FormatTime(gametimer));

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
            return Mathf.Floor(seconds) + " seconds";
    }
    void UpdateCheats()
    {
        if (CheatDelay > 0) { CheatDelay -= Time.deltaTime; if (CheatDelay <= 0) { CheatDelay = 0f; GodModeProgress = 0; } } if (GodModeProgress == 0 && Input.GetKeyDown(KeyCode.E))
        { GodModeProgress++; CheatDelay = 1f; }
        else if (GodModeProgress == 1 && Input.GetKeyDown(KeyCode.D)) { GodModeProgress++; CheatDelay = 1f; }
        else if (GodModeProgress == 2 && Input.GetKeyDown(KeyCode.G)) { GodModeProgress++; CheatDelay = 1f; }
        else if (GodModeProgress == 3 && Input.GetKeyDown(KeyCode.A)) { GodModeProgress++; CheatDelay = 1f; }
        else if (GodModeProgress == 4 && Input.GetKeyDown(KeyCode.R)) { GodModeProgress = 0; GodMode = !GodMode; print("GodMode On!"); }
    }

}
