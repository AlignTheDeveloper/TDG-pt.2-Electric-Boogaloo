using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableGROW : MonoBehaviour
{
    public float timer = 0f;
    public float growTime = 10f;
    public float maxSizeX = 10f;
    public float maxSizeY = 0f;

    public bool isMaxSize = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (isMaxSize == false)
            {
                StartCoroutine(GrowTable());
            }
        }
    }
    private IEnumerator GrowTable()
    {


        Vector2 startScale = transform.localScale;
        Vector2 endScale = new Vector2(maxSizeX, maxSizeY);

        do
        {
            transform.localScale = Vector2.Lerp(startScale, endScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        isMaxSize = true;
    }
}
