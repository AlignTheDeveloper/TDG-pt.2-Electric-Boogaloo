using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    //public InstantiatePrefabs gameManager;
    bool isScaling = false;
    Vector3 maxScale;

    public GameObject button;
     //public GameObject galaxy;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = FindObjectOfType<InstantiatePrefabs>();
        button.SetActive(false);
        gameObject.SetActive(false);
        maxScale = new Vector3(5,5,5);
    }

    // Update is called once per frame
    void Update()
    {
        /* if(gameManager.score == 9)
        {
            gameObject.SetActive(true);
            scaleOverTime(gameObject.transform, maxScale, 2);
        } */

        

    }

    public void test()
    {
        Debug.Log("test running");
        gameObject.SetActive(true);
        StartCoroutine(scaleOverTime(gameObject.transform, maxScale, 2));
        button.SetActive(true);
    }  

    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 minScale = objectToScale.transform.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(minScale, toScale, counter / duration);
            yield return null;
        }

        isScaling = false;
    }
}
