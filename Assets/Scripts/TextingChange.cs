using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextingChange : MonoBehaviour
{
    [SerializeField] GameObject Responce;
    // Start is called before the first frame update
    void Start()
    {
        Responce.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            int layerMask = LayerMask.GetMask("Text");
            Collider2D target = Physics2D.OverlapPoint(worldPoint, layerMask);

            if (target)
            {
                Responce.SetActive(true);
            }
        }
    }

}
