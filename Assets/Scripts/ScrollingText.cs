using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    public GameObject text;
     public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrollDEEZ();
    }

    void scrollDEEZ()
    {
        text.transform.position = Vector2.up * speed;
    }
        
}
