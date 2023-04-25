using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorObject : MonoBehaviour
{
    //spawner to get script
    private GameObject spawner;

    // transforms for electrons
    public Transform ObjA;
    public Transform ObjB;

    //reference to the electrons so you get an accurate gameobject with each instantiation
    public GameObject electronTwo;
    public GameObject electronOne;

    public GameObject mirror;
    public Transform MirrorPoint;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("spawner");

        mirror = GameObject.FindGameObjectWithTag("mirror");
        MirrorPoint = mirror.transform;

    }

    private void Update()
    {
        //getting electtron info with each instantiation
        electronOne = GameObject.FindGameObjectWithTag("eleOne");
        ObjA = electronOne.transform;
        electronTwo = GameObject.FindGameObjectWithTag("eleTwo");
        ObjB = electronTwo.transform;


        if (spawner.GetComponent<SpawnerS>().eleOne == true)
        {
            ObjB.position = Vector3.LerpUnclamped(ObjA.position, MirrorPoint.position, 2);
        }
        else if (spawner.GetComponent<SpawnerS>().eleTwo == true )
        {
            ObjA.position = Vector3.LerpUnclamped(ObjB.position, MirrorPoint.position, 2);
        }
    }
}



