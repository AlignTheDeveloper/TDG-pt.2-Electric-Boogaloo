using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestCamMove : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] public int currentRoomIndex = 0;
    [SerializeField] private float speed = 2f;

    [SerializeField] private float timeToWait = 2f;
    private float timer;
    private TextingChange textingChange;
    private WalkingChange walkingChange;
    private LookChange lookChange;


    //private Camera camera;

    [SerializeField] Button next;
    [SerializeField] Button back;
    [SerializeField] GameObject theVoid;
    bool isChanging;
    public float maxAlpha = 255;

    public void Start()
    {
        textingChange = FindObjectOfType<TextingChange>();
        walkingChange = FindObjectOfType<WalkingChange>();
        //camera = Camera.main;
        //next = GameObject.Find("Next");
        //back = GameObject.Find("Back");
        theVoid.SetActive(false);
    }

    void Update()
    {
        // timer += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, rooms[currentRoomIndex].transform.position, Time.deltaTime * speed);
        
        // if(currentRoomIndex == 0)
        // {
        //     timer = 999;
        // }

        // if (timer >= time)
        // {
        //     DetectObjectWithRaycast();
        //     StartCoroutine(Reactivate());
        // }

        if (currentRoomIndex == 18)
        {
            StartCoroutine(VoidTimer());
        }

        else if (currentRoomIndex == 9)
        {
            if (textingChange.move == false)
            {
                next.interactable = false;
                back.interactable = false;
            }
            else
            {
                next.interactable = true;
                back.interactable = true;
            }
        }
        else if (currentRoomIndex == 10)
        {
            // if (walkingChange.move == false)
            // {
            //     next.interactable = false;
            //     back.interactable = false;
            // }
            // else
            // {
            //     next.interactable = true;
            //     back.interactable = true;
        }
        else if (currentRoomIndex == 12)
        {
            GameObject parentNext = next.transform.parent.gameObject;
            GameObject parentBack = next.transform.parent.gameObject;

            parentNext.SetActive(false);
            parentBack.SetActive(false);
        }
        // else if (currentRoomIndex == 13)
        // {
        //     if (lookChange.move == false)
        //     {
        //         next.interactable = false;
        //         back.interactable = false;
        //     }
        //     else
        //     {
        //         next.interactable = true;
        //         back.interactable = true;
            
        //     }
        // }
        else if (currentRoomIndex == 17)
        {
            GameObject parentNext = next.transform.parent.gameObject;
            GameObject parentBack = next.transform.parent.gameObject;

            parentNext.SetActive(false);
            parentBack.SetActive(false);
        }
        
    }

    // public void DetectObjectWithRaycast()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
    //         int layerMask = LayerMask.GetMask("ButtonLayer");
    //         Collider2D target = Physics2D.OverlapPoint(worldPoint, layerMask);

    //         if (target)
    //         {

    //             Debug.Log($"{hit.collider.name} Detected",
    //                 hit.collider.gameObject);
    //             if (hit.collider.name == "Next")
    //             {
    //                 NextRoom();
    //                 timer = 0;
    //                 next.interactable = false;
    //                 back.interactable = false;
    //             }
    //             if (hit.collider.name == "Back")
    //             {
    //                 PreviousRoom();
    //                 timer = 0;
    //                 next.interactable = false;
    //                 back.interactable = false;
    //             }

    //         }
    //     }
    // }

    public void NextRoom()
    { 
        currentRoomIndex++;
        StartCoroutine(ChangingRoom());
        if (currentRoomIndex >= rooms.Length)
        {
            currentRoomIndex = 0;
        }
    }

    IEnumerator ChangingRoom()
    {
        next.interactable = false;
        back.interactable = false;
        yield return new WaitForSeconds(timeToWait);
        next.interactable = true;
        back.interactable = true;
    }

    public void PreviousRoom()
    {
        currentRoomIndex--;
        StartCoroutine(ChangingRoom());
        if (currentRoomIndex <= 0)
        {
            currentRoomIndex = 0;
        }
    }

     public void EnterTheVoid()
    {
        SpriteRenderer spriteRenderer = theVoid.GetComponent<SpriteRenderer>();
        Color tmp = spriteRenderer.color;
        float alpha = tmp.a;
        alpha = 0;
        theVoid.SetActive(true);
        StartCoroutine(ChangeAlphaOverTime(spriteRenderer, maxAlpha, 2));
    }

    // IEnumerator Reactivate()
    // {
    //     yield return new WaitForSeconds(time);
    //     next.interactable = true;
    //     back.interactable = true;
    // }

    IEnumerator ChangeAlphaOverTime(SpriteRenderer spriteRenderer, float toAlpha, float duration)
    {
        if (isChanging)
        {
            yield break;
        }
        isChanging = true;

        float counter = 0.0f;
        float alphaMin = spriteRenderer.color.a;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float newAlpha = Mathf.Lerp(alphaMin, toAlpha / 255f, counter / duration);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);

            yield return null;
        }
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, toAlpha);
        isChanging = false;
        SceneManager.LoadScene("Ending");
    }
    IEnumerator VoidTimer()
    {
        yield return new WaitForSeconds(10);
        EnterTheVoid();
    }
}
