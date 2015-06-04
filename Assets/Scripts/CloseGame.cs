using UnityEngine;
using System.Collections;

public class CloseGame : MonoBehaviour
{
    public bool exit = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!exit)
                Application.LoadLevel(1);
            else
                Application.Quit();
        }
    }
}
