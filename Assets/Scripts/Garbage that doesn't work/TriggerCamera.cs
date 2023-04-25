using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    private Com.LuisPedroFonseca.ProCamera2D.ProCamera2DRooms proCam;
    private int activeRoom = 0;
    private Camera mc;
    

    // Start is called before the first frame update
    void Start()
    {
        mc = FindObjectOfType<Camera>();
        proCam.EnterRoom(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            activeRoom++;
            Debug.Log(activeRoom);
            proCam.EnterRoom(activeRoom);
        }
    }
}
