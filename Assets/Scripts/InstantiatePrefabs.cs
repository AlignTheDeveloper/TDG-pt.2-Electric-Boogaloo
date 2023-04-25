using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] locations;

    private GameObject firstObjectClicked; // Hold reference to first clicked object
    private GameObject secondObjectClicked; // Hold reference to second clicked object

    public string checkTag; //container for tag to check

    void Start()
    {
        // Shuffle the locations array to randomize the order
        Shuffle(locations);

        for (int i = 0; i < prefabs.Length; i++)
        {
            // Instantiate the prefab at a random location from the locations array
            int index = Random.Range(0, locations.Length);
            Instantiate(prefabs[i], locations[index].position, Quaternion.identity);

            // Remove the chosen location from the locations array to avoid duplicates
            locations[index] = locations[locations.Length - 1];
            locations[locations.Length - 1] = null;
            System.Array.Resize(ref locations, locations.Length - 1);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            int layerMask = LayerMask.GetMask("Characters");
            Collider2D target = Physics2D.OverlapPoint(worldPoint, layerMask);

            if (target)
            {
                checkTag = hit.collider.gameObject.tag;
                Debug.Log(checkTag);

                if (firstObjectClicked == null)
                {
                    firstObjectClicked = hit.collider.gameObject;
                }
                else
                {
                    secondObjectClicked = hit.collider.gameObject;

                    if (firstObjectClicked.CompareTag(checkTag))
                    {
                        firstObjectClicked.SetActive(false);
                        secondObjectClicked.SetActive(false);
                    }

                    firstObjectClicked = null;
                    secondObjectClicked = null;
                }
            }
        }
    }
    // Shuffle the elements of an array using the Fisher-Yates algorithm
    void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}