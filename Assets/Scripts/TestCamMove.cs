using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestCamMove : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private int currentRoomIndex = 0;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float time = 2f;
    private float timer;
    //private Camera camera;

    [SerializeField] GameObject next;
    [SerializeField] GameObject back;
    [SerializeField] GameObject theVoid;
    private bool coolRoom;
    bool isChanging;
    public float maxAlpha = 255;

    public void Start()
    {
        //camera = Camera.main;
        //next = GameObject.Find("Next");
        //back = GameObject.Find("Back");
        coolRoom = true;
        theVoid.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, rooms[currentRoomIndex].transform.position, Time.deltaTime * speed);
        
        if(currentRoomIndex == 0)
        {
            timer = 999;
        }

        if (timer >= time)
        {
            DetectObjectWithRaycast();
            if(coolRoom)
            {
                StartCoroutine(Reactivate());
            }
        }

        if (currentRoomIndex == 18)
        {
            StartCoroutine(VoidTimer());
        }
    }

    public void DetectObjectWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            int layerMask = LayerMask.GetMask("ButtonLayer");
            Collider2D target = Physics2D.OverlapPoint(worldPoint, layerMask);

            if (target)
            {

                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);
                if (hit.collider.name == "Next")
                {
                    NextRoom();
                    timer = 0;
                    next.SetActive(false);
                    back.SetActive(false);
                }
                if (hit.collider.name == "Back")
                {
                    PreviousRoom();
                    timer = 0;
                    next.SetActive(false);
                    back.SetActive(false);
                }

            }
        }
    }

    public void NextRoom()
    {
        currentRoomIndex++;
        if (currentRoomIndex >= rooms.Length)
        {
            currentRoomIndex = 0;
        }
    }

    public void PreviousRoom()
    {
        currentRoomIndex--;
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

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(time);
        next.SetActive(true);
        back.SetActive(true);
    }

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
