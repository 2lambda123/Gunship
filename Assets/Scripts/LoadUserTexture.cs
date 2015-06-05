using UnityEngine;
using System.Collections;
using AGC.mod;
using AGC.Tools;
using AGC.Settings;

public class LoadUserTexture : MonoBehaviour
{

    public string TextureName;
    public Material material;

    void Start()
    {
        string n = AGCSettings.FindCFGSetting(TextureName);
        AGCTools.log("TextureName name: " + n);
        if (n == null)
            n = "Logo.png";
        Texture2D t = AGCMod.LoadTexture(n, 512);
        if (t != null)
        {
            material.mainTexture = t;
        }
    }

}
