using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClicks : MonoBehaviour
{
    private GameObject firstClickedObject;
    private bool isChecking;

    private void Update()
    {
        // Check for first click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (!isChecking)
                {
                    // First click
                    firstClickedObject = hit.transform.gameObject;
                    isChecking = true;
                }
                else if (hit.transform.gameObject != firstClickedObject)
                {
                    // Second click
                    if (hit.transform.CompareTag(firstClickedObject.tag))
                    {
                        // Both objects have the same tag, destroy them
                        Destroy(firstClickedObject);
                        Destroy(hit.transform.gameObject);
                    }
                    isChecking = false;
                }
            }
        }
    }
}
