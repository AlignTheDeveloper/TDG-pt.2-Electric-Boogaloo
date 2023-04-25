using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableR : MonoBehaviour
{

    GameObject rightPoint;
    
    void Start()
    {

        rightPoint = GameObject.FindGameObjectWithTag("rightPointT");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rightPoint.transform.position;
    }
}
