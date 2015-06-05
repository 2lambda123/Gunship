using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour
{
    public GameObject terrain;
    public float speed = 10f;
    public Vector3 pos;
    GameObject terr1;
    GameObject terr2;
    GameObject terr3;

    // Use this for initialization
    void Start()
    {
        terr1 = Instantiate(terrain) as GameObject;
        terr2 = Instantiate(terrain) as GameObject;
        terr3 = Instantiate(terrain) as GameObject;
        terr1.transform.position = new Vector3(0, pos.y, pos.z);
        terr2.transform.position = new Vector3(-pos.x, pos.y, pos.z);
        terr3.transform.position = new Vector3(-pos.x * 2, pos.y, pos.z);

    }

    // Update is called once per frame 
    void Update()
    {
        terr1.transform.position += Vector3.right * speed;
        terr2.transform.position += Vector3.right * speed;
        terr3.transform.position += Vector3.right * speed;
        CheckPos(terr1);
        CheckPos(terr2);
        CheckPos(terr3);

    }
    void CheckPos(GameObject obj)
    {
        if (obj.transform.position.x > pos.x)
        {
            obj.transform.position = new Vector3(-pos.x * 2, pos.y, pos.z);
            //print("setpos");
        }
            
    }
}
