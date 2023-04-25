using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomChanger : MonoBehaviour
{
    public TestCamMove cam;
    void Update()
    {
        if (Input.mousePosition.x > Screen.width /2f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cam.NextRoom();
                //Debug.Log("Next " + currentRoomIndex);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                cam.PreviousRoom();
                //Debug.Log("Back " + currentRoomIndex);
            }
        }
    }
}
