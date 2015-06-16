using UnityEngine;
using System.Collections;

public class Folow : MonoBehaviour
{

    public GameObject folow;

    // Update is called once per frame 
    void Update()
    {
        if (folow != null)
            this.transform.position = folow.transform.position;
    }
}
