using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleCollision : MonoBehaviour
{
  
    GameObject head;


    SpawnerS script;




    // Start is called before the first frame update
    void Start()
    {
        script = FindObjectOfType<SpawnerS>();
        head = GameObject.FindGameObjectWithTag("headOne");
        
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if head detects collision with electron 1, the animation plays
        if (collision.gameObject.CompareTag("headOne"))
        {
            Destroy(GameObject.FindGameObjectWithTag("eleOne"));
            Destroy(GameObject.FindGameObjectWithTag("eleTwo"));
            script.spawnObjects();
            Debug.Log("hit");
        }
    



    }
}
