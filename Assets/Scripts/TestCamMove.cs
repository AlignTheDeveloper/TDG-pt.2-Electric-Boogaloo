using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamMove : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private int currentRoomIndex = 0;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float time = 2f;
    private float timer;
    


    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, rooms[currentRoomIndex].transform.position, Time.deltaTime * speed);
        
        if(currentRoomIndex == 0)
        {
            timer = 999;
        }

        if (Input.mousePosition.x > Screen.width / 2f)
        {
            if (timer >= time)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    NextRoom();
                    Debug.Log("Next " + currentRoomIndex);
                    timer = 0;
                }
            }
        }
        else
        {
            if (timer >= time)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PreviousRoom();
                    Debug.Log("Back " + currentRoomIndex);
                    timer = 0;
                }
            }
        }
    }


    public void NextRoom()
    {
        currentRoomIndex++;
        if (currentRoomIndex >= rooms.Length)
        {
            currentRoomIndex = 0;
        }
    }

    public void PreviousRoom()
    {
        currentRoomIndex--;
        if (currentRoomIndex <= 0)
        {
            currentRoomIndex = 0;
        }
    }
}
