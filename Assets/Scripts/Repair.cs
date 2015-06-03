using UnityEngine;
using System.Collections;

public class Repair : MonoBehaviour
{
    private float repairProgress = 0f;
    private float repairModifier = 0.5f;

    private float progressBarWidth = 10f;

    private bool showRepairProgressGui = false;
    private bool showProgressBarWidthGui = true;

    private float maxProgress = 300.0f;

    public Transform player;
    public GameObject destroyable;


    public void OnGUI()
    {
        if (player != null)
        {
            float dist = Vector3.Distance(player.position, this.transform.position);
            if (dist < 2.5)
            {
                if (showRepairProgressGui == true)
                {
                    GUI.Box(new Rect(Screen.width / 2 - 75,		//X
                                     Screen.height / 2 - 25,	//Y
                                     progressBarWidth,			//Width
                                     25),						//Height
                                "Repairing...");				//Display Value
                }

                if (showProgressBarWidthGui == true)
                {
                    GUI.Box(new Rect(Screen.width / 2 - 75,		//X
                                     Screen.height / 2 - 25,	//Y
                                     200,						//Width
                                     25),						//Height
                            "Press and hold F to repair");		//Display Value
                }

                if (Input.GetKey(KeyCode.F))
                {
                    showRepairProgressGui = true;
                    showProgressBarWidthGui = false;
                    repairProgress += repairModifier;
                    progressBarWidth += repairModifier;
                }

                if (Input.GetKeyUp(KeyCode.F))
                {
                    showRepairProgressGui = false;
                    showProgressBarWidthGui = true;
                    repairProgress = 0f;
                    progressBarWidth = 10f;
                }

                if (repairProgress > maxProgress)
                {
                    showRepairProgressGui = false;
                    showProgressBarWidthGui = false;
                    repairProgress = 0f;
                    Destroy(destroyable);

                }
            }
        }
    }
}