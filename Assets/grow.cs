using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class grow : MonoBehaviour
{

    // Start is called before the first frame update
    public Camera cam;
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
            Invoke("Expansion", 1.5f);
        }
    }
    void Update()
    {

        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, TargetFOV, Speed * Time.deltaTime);
    }

    void Expansion()
    {
        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
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

        if (timer > growTime)
        {
            SceneManager.LoadScene("Comic3");
        }

        isMaxSize = true;
    }



    

}