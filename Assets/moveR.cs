using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveR : MonoBehaviour
{
    
    GameObject rightPoint;
    // Start is called before the first frame update
    void Start()
    {
       
        rightPoint = GameObject.FindGameObjectWithTag("rightPoint");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rightPoint.transform.position;
    }
}