using UnityEngine;
using UnityEngine.Analytics;
using System;
using System.Collections;
using System.Collections.Generic;
using AGC.Tools;
using AGC.Settings;

public class SplashScreen : MonoBehaviour
{

    public Material[] Logos;

    public float fadeTime = 1.0f;
    public int nextscene = 1;

    enum Fade
    {
        In, Out
    }
    IEnumerator Start()
    {
        Analytics.SetUserId(Environment.UserName);
        foreach (Material m in Logos)
            m.color = new Color(1, 1, 1, 0);
        if (!AGCSettings.FindCFG())
        {
            AGCSettings.WriteCFGSetting("UsePlaneInsteadOfTerrain", false);
            AGCSettings.WriteCFGSetting("UseClouds", true);
            AGCSettings.WriteCFGSetting("SpawnHulls", true);
            AGCSettings.WriteCFGSetting("SpawnParticles", true);
            AGCSettings.WriteCFGSetting("AmountClouds", 500);
        }
        AGCTools.log("dataPath: " + Application.dataPath);
        AGCTools.log("platform: " + Application.platform);
        AGCTools.log("systemLanguage: " + Application.systemLanguage);
        AGCTools.log("installMode: " + Application.installMode);
        AGCTools.log("temporaryCachePath: " + Application.temporaryCachePath);
        AGCTools.log("Version of the runtime: " + Application.unityVersion);
        AGCTools.log("UserName: " + Environment.UserName);
        AGCTools.log("MachineName: " + Environment.MachineName);
        AGCSettings.WriteCFGSetting("UserName", Environment.UserName);

        foreach (Material m in Logos)
        {
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(Fademat(m, fadeTime, Fade.In));
            yield return new WaitForSeconds(0.25f);
            yield return StartCoroutine(Fademat(m, fadeTime, Fade.Out));
            yield return new WaitForSeconds(0.5f);
        }
#if UNITY_EDITOR
        foreach (Material m in Logos)
            m.color = new Color(1, 1, 1, 1);
#endif//UNITY_EDITOR
        Application.LoadLevel(nextscene);
    }

    IEnumerator Fademat(Material curentmat, float timer, Fade fadeType)
    {
        float start = fadeType == Fade.In ? 0.0f : 1.0f;
        float end = fadeType == Fade.In ? 1.0f : 0.0f;
        float i = 0.0f;
        float step = 1.0f / timer;
        while (i < 1.0f)
        {
            i += step * Time.deltaTime;
            //curentmat.color.a = new Mathf.Lerp(start, end, i) * 1;
            curentmat.color = new Color(1, 1, 1, Mathf.Lerp(start, end, i));
            //print("" + Mathf.Lerp(start, end, i));
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            Application.LoadLevel(nextscene);
    }
}
