using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform[] locations;

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
