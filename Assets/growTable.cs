using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growTable : MonoBehaviour
{

    // Start is called before the first frame update
    public float timer = 0f;
    public float growTime = 10f;
    public float maxSizeX = 10f;
    public float maxSizeY = 0f;

    public float TargetFOV = 160f;
    public float Speed = .75f; //Will reach target value in 1sec.

    public bool isMaxSize = false;
    void Start()
    {
        if (isMaxSize == false)
        {
            Invoke("ExpansionTable", 3f);
        }
    }
    void Update()
    {

       
    }

    void ExpansionTable()
    {
        StartCoroutine(GrowTable());
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
