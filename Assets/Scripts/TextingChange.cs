 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextingChange : MonoBehaviour
{
    public bool move = false;
    [SerializeField] public GameObject response;
    [SerializeField] GameObject pulse;
    private TestCamMove testCamMove;

    // Start is called before the first frame update
    void Start()
    {
        response.SetActive(false);
        testCamMove = FindObjectOfType<TestCamMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (testCamMove.currentRoomIndex == 9)
        {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            int layerMask = LayerMask.GetMask("Text");
            Collider2D target = Physics2D.OverlapPoint(worldPoint, layerMask);

            if (target)
            {
               response.SetActive(!response.activeSelf);
               move = true;    
               pulse.SetActive(false);
            }
        }
        }
    }

} 
