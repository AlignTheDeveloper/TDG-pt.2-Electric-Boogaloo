using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class wakeUp : MonoBehaviour
{
   
    private Animator anim;
    

    //getting spawner to access script
    public GameObject spawner;







    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }


    
   

    public void headSet()
    {
        anim.SetBool("headW", false);
    }

  

}
