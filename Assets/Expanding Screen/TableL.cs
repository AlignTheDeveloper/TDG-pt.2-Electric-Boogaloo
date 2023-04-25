using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableL : MonoBehaviour
{
    GameObject leftPoint;
    //GameObject rightPoint;
    // Start is called before the first frame update
    void Start()
    {
        leftPoint = GameObject.FindGameObjectWithTag("leftPointT");
        //rightPoint = GameObject.FindGameObjectWithTag("rightP");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = leftPoint.transform.position;
    }
}
