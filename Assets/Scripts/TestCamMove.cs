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
    //private Camera camera;

    [SerializeField] GameObject next;
    [SerializeField] GameObject back;
    private bool coolRoom;

    void Start()
    {
        //camera = Camera.main;
        //next = GameObject.Find("Next");
        //back = GameObject.Find("Back");
        coolRoom = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, rooms[currentRoomIndex].transform.position, Time.deltaTime * speed);
        
        if(currentRoomIndex == 0)
        {
            timer = 999;
        }

        if (timer >= time)
        {
            DetectObjectWithRaycast();
            if(coolRoom)
            {
                StartCoroutine(Reactivate());
            }
        }

        //if (Input.mousePosition.x > Screen.width / 2f)
        //{
        //    if (timer >= time)
        //    {
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            NextRoom();
        //            Debug.Log("Next " + currentRoomIndex);
        //            timer = 0;
        //        }
        //    }
        //}
        //else
        //{
        //    if (timer >= time)
        //    {
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            PreviousRoom();
        //            Debug.Log("Back " + currentRoomIndex);
        //            timer = 0;
        //        }
        //    }
        //}
    }

    public void DetectObjectWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            int layerMask = LayerMask.GetMask("ButtonLayer");
            Collider2D target = Physics2D.OverlapPoint(worldPoint, layerMask);

            if (target)
            {

                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);
                if (hit.collider.name == "Next")
                {
                    NextRoom();
                    timer = 0;
                    next.SetActive(false);
                    back.SetActive(false);
                }
                if (hit.collider.name == "Back")
                {
                    PreviousRoom();
                    timer = 0;
                    next.SetActive(false);
                    back.SetActive(false);
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

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(time);
        next.SetActive(true);
        back.SetActive(true);
    }
}
