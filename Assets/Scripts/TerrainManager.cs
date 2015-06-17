using UnityEngine;
using System.Collections;
using AGC.Settings;

public class TerrainManager : MonoBehaviour
{
    public GameObject terrain;
    public GameObject plane;
    public float speed = 10f;
    public Vector3 posTerrain;
    public Vector3 posPlane;
    Vector3 pos;
    GameObject terr1;
    GameObject terr1L;
    GameObject terr1R;
    GameObject terr2;
    GameObject terr2L;
    GameObject terr2R;
    GameObject terr3;
    GameObject terr3L;
    GameObject terr3R;

    // Use this for initialization
    void Start()
    {
        bool useplane = AGCSettings.FindCFGBool("UsePlaneInsteadOfTerrain");
        if (useplane)
        {
            terr1 = Instantiate(plane) as GameObject;
            terr1L = Instantiate(plane) as GameObject;
            terr1R = Instantiate(plane) as GameObject;
            terr2 = Instantiate(plane) as GameObject;
            terr2L = Instantiate(plane) as GameObject;
            terr2R = Instantiate(plane) as GameObject;
            terr3 = Instantiate(plane) as GameObject;
            terr3L = Instantiate(plane) as GameObject;
            terr3R = Instantiate(plane) as GameObject;
            pos = posPlane;
        }
        else
        {
            terr1 = Instantiate(terrain) as GameObject;
            terr1L = Instantiate(terrain) as GameObject;
            terr1R = Instantiate(terrain) as GameObject;
            terr2 = Instantiate(terrain) as GameObject;
            terr2L = Instantiate(terrain) as GameObject;
            terr2R = Instantiate(terrain) as GameObject;
            terr3 = Instantiate(terrain) as GameObject;
            terr3L = Instantiate(terrain) as GameObject;
            terr3R = Instantiate(terrain) as GameObject;
            pos = posTerrain;
        }
        terr1.transform.position = new Vector3(0, pos.y, 0);
        terr1L.transform.position = new Vector3(0, pos.y, pos.z );
        terr1R.transform.position = new Vector3(0, pos.y, -pos.z );

        terr2.transform.position = new Vector3(-pos.x, pos.y, 0);
        terr2L.transform.position = new Vector3(-pos.x, pos.y, pos.z );
        terr2R.transform.position = new Vector3(-pos.x, pos.y, -pos.z);

        terr3.transform.position = new Vector3(-pos.x * 2, pos.y, 0);
        terr3L.transform.position = new Vector3(-pos.x * 2, pos.y, pos.z);
        terr3R.transform.position = new Vector3(-pos.x * 2, pos.y, -pos.z);

    }

    // Update is called once per frame 
    void Update()
    {
        terr1.transform.position += Vector3.right * speed;
        terr1L.transform.position += Vector3.right * speed;
        terr1R.transform.position += Vector3.right * speed;

        terr2.transform.position += Vector3.right * speed;
        terr2L.transform.position += Vector3.right * speed;
        terr2R.transform.position += Vector3.right * speed;

        terr3.transform.position += Vector3.right * speed;
        terr3L.transform.position += Vector3.right * speed;
        terr3R.transform.position += Vector3.right * speed;

        CheckPos(terr1);
        CheckPosL(terr1L);
        CheckPosR(terr1R);

        CheckPos(terr2);
        CheckPosL(terr2L);
        CheckPosR(terr2R);

        CheckPos(terr3);
        CheckPosL(terr3L);
        CheckPosR(terr3R);

    }
    void CheckPos(GameObject obj)
    {
        if (obj.transform.position.x > pos.x)
        {
            obj.transform.position = new Vector3(-pos.x * 2, pos.y, 0);
            //print("setpos");
        }

    }
    void CheckPosR(GameObject obj)
    {
        if (obj.transform.position.x > pos.x)
        {
            obj.transform.position = new Vector3(-pos.x * 2, pos.y, pos.z);
            //print("setpos");
        }

    }
    void CheckPosL(GameObject obj)
    {
        if (obj.transform.position.x > pos.x)
        {
            obj.transform.position = new Vector3(-pos.x * 2, pos.y, -pos.z);
            //print("setpos");
        }

    }
}

