using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class wakeUp : MonoBehaviour
{
// counter for how many times the animation has been played
    public int sleepCount = 0;
//animator for the corner
    private Animator anim;
//sprite changing stuff
    public SpriteRenderer spriteRenderer;
    public Sprite sleepingTwo;
    public Sprite sleepingThree;

    







    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    public void sleepNumber()
    {
        sleepCount++;   
    }


    //this function is set to the animation event on the animation
    //and will change the sprite to it's next sleeping state. 
    public void sleepState()
    {
        if (sleepCount == 1)
        {
            spriteRenderer.sprite = sleepingTwo;
        }
        else if (sleepCount == 2)
        {
            spriteRenderer.sprite = sleepingThree;
            StartCoroutine(changeScenes("Comic"));
        }
        /*else if (sleepCount == 3)
        {
            StartCoroutine(changeScenes("Comic"));
        }
        */
    }


    //resets the animation bool
    public void headSet()
    {
        anim.SetBool("headW", false);
    }
  

    //This method activates the animation on collision with the electrons.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider)
        {
            anim.SetBool("headW", true);
            
        }
    }
    
    IEnumerator changeScenes(string scene_name)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene_name);
    }
}
