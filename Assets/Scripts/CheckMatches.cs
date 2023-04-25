using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatches : MonoBehaviour
{
    public GameObject[] gameObjects;
    public string targetTag;

    private List<GameObject> clickedObjects = new List<GameObject>();

    int counter = 0;

    private void Start()
    {

    }

    private void Update()
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        GameObject clickedObject = gameObject;
        clickedObjects.Add(clickedObject);

        if (clickedObjects.Count == 2)
        {
            GameObject object1 = clickedObjects[0];
            GameObject object2 = clickedObjects[1];

            if (object1.CompareTag(object2.tag) && object1 != object2)
            {
                Destroy(object1);
                Destroy(object2);
            }
            clickedObjects.Clear();
        }
    }
}
