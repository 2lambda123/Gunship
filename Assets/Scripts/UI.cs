using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using AGC.mod;
using AGC.Settings;
using AGC.Tools;


public class UI : MonoBehaviour
{
    public GameObject Game_object;
    private float min = 0;
    private float max = 1;
    public Toggle UsePlaneInsteadOfTerrain;
    public Toggle UseClouds;
    public Toggle SpawnHulls;
    public Slider AmountClouds;

    // Use this for initialization
    void Start()
    {
        UsePlaneInsteadOfTerrain.isOn = AGCSettings.FindCFGBool("UsePlaneInsteadOfTerrain");
        UseClouds.isOn = AGCSettings.FindCFGBool("UseClouds");
        SpawnHulls.isOn = AGCSettings.FindCFGBool("SpawnHulls");
        AmountClouds.value = AGCSettings.FindCFGInt("AmountClouds");
        List<string> AllTextures = new List<string>(AGCMod.IndexFileNames(".jpg"));
        AllTextures.AddRange(AGCMod.IndexFileNames(".png"));
        AGCTools.log("IndexFiles " + AllTextures.Count);
        //float x = 0;
        foreach (string s in AllTextures)
        {
            GameObject clone = Instantiate(Game_object, new Vector3(max, 0, 0), Quaternion.identity) as GameObject;
            clone.name = s;
            Renderer r = clone.GetComponent<Renderer>();
            r.material.mainTexture = AGCMod.LoadTexture(s, 512);
            max += 1.1f;
            AGCTools.log("" + s);
        }
    }
    void Update()
    {
        float x = this.transform.position.x + Input.GetAxisRaw("Mouse ScrollWheel") * 5;
        this.transform.position = new Vector3(Mathf.Clamp(x, min, max), 0, -5);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel(1);

    }
    void OnDestroy()
    {
        AGCSettings.WriteCFGSetting("UsePlaneInsteadOfTerrain", UsePlaneInsteadOfTerrain.isOn);
        AGCSettings.WriteCFGSetting("UseClouds", UseClouds.isOn);
        AGCSettings.WriteCFGSetting("SpawnHulls", SpawnHulls.isOn);
        AGCSettings.WriteCFGSetting("AmountClouds", AmountClouds.value);
    }

}
