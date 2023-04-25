using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class SpawnerS : MonoBehaviour
{
    public int numberToSpawn;

    // these lists contain the electrons that the spawner instantiates
    public List<GameObject> spawnPool1;
    public List<GameObject> spawnPool2;
 

    //These quads are the fields that the spawner can instantiate electrons within
    public GameObject quadOne;
    public GameObject quadTwo;


    //bools to check which electron is clicked
    public bool eleOne = false;
    public bool eleTwo = false;






   
   

    //checks to see if left click is being held down
    public bool click = false;

    //This will be the bool that once true will spawn the head in the center of the game
    //public bool headCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        //starts the spawnning of electrons
        InvokeRepeating("spawnObjects", 0f, 1.5f);

   


        
    }
    void Update()
    {


        if (Input.GetMouseButton(0))
       {
            
            castRay();
       }
        if (Input.GetMouseButtonUp(0))
        {
            click = false;
            eleOne = false;
            eleTwo = false;
        }

       
    }


    public void spawnObjects()
    {
        if (click == false)
        {
            destroyObj();
            int randomItem = 0;
            GameObject toSpawn;
            MeshCollider c1 = quadOne.GetComponent<MeshCollider>();
            MeshCollider c2 = quadTwo.GetComponent<MeshCollider>();

            float screenX, screenY;
            Vector3 pos;
            //this is the section for the first electron
            for (int i = 0; i < numberToSpawn; i++)
            {
                toSpawn = spawnPool1[randomItem];

                screenX = Random.Range(c1.bounds.min.x, c1.bounds.max.x);
                screenY = Random.Range(c1.bounds.min.y, c1.bounds.max.y);
                pos = new Vector3(screenX, screenY, 0);


                Instantiate(toSpawn, pos, toSpawn.transform.rotation);

            }
            //this is for the second electron in the second quad
            for (int i = 0; i < numberToSpawn; i++)
            {
                toSpawn = spawnPool2[randomItem];

                screenX = Random.Range(c2.bounds.min.x, c2.bounds.max.x);
                screenY = Random.Range(c2.bounds.min.y, c2.bounds.max.y);
                pos = new Vector3(screenX, screenY, 0);


                Instantiate(toSpawn, pos, toSpawn.transform.rotation);

            }
        }

    }

    
    private void destroyObj()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("eleOne"))
        {
            Destroy(o);
        }
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("eleTwo"))
        {
            Destroy(o);
        }

    }

    private void castRay()
    {
        //variable to track mouse position in order to drag electron
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // if left mous button is held down and the ray makes contact with the collider on the electrons
        // the bool will read true and stop the electrons from continuing to spawn which will allow for the
        //movement of the electrons
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Quad1")
            {
                Debug.DrawLine(ray.origin, hit.point);
                click = true;
                eleTwo = false;
                eleOne = true;
                
            }
            else if (hit.transform.tag == "Quad2")
            {
                Debug.DrawLine(ray.origin, hit.point);
                click = true;
                eleTwo = true;
                eleOne = false;
                
            }
        }
          
        }

    }

    
