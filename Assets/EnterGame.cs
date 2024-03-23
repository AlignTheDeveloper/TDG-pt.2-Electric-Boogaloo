using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    [SerializeField] GameObject gameStarter;
    private TestCamMove testCamMove;
    // Start is called before the first frame update
    void Start()
    {
        testCamMove = FindObjectOfType<TestCamMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (testCamMove.currentRoomIndex == 12)
        {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            int layerMask = LayerMask.GetMask("GameStarter");
            Collider2D target = Physics2D.OverlapPoint(worldPoint, layerMask);

            if (target)
            {
                SceneManager.LoadScene("Game_Matching");
            }
        }
        }
    }
}
