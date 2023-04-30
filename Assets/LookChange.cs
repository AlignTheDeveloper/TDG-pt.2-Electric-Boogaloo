using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookChange : MonoBehaviour
{
    [SerializeField] GameObject lookNext;
    // Start is called before the first frame update
    void Start()
    {
        lookNext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            int layerMask = LayerMask.GetMask("Look");
            Collider2D target = Physics2D.OverlapPoint(worldPoint, layerMask);

            if (target)
            {
                lookNext.SetActive(true);
            }
        }
    }
}
