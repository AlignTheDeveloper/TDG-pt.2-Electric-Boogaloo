using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour
{
    public Character characterPrefab;
    public Transform charSpawnPosition;
    public Vector2 startPosition = new Vector2(-2.15f, 3.62f);
    public List<Character> characterList;

    private Vector2 offset = new Vector2(1.5f, 1.52f);

    // Start is called before the first frame update
    void Start()
    {
        SpawnCharMesh(4, 4, startPosition, offset, false);
        MoveChar(4, 4, startPosition, offset);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnCharMesh(int rows, int columns, Vector2 pos, Vector2 offset, bool scaleDown)
    {
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var tempChar = Instantiate(characterPrefab, new Vector3(pos.x + (offset.x * row), pos.y - (offset.y * col), 0f), Quaternion.identity);
                tempChar.name = tempChar.name + "c" + col + "r" + row;
                characterList.Add(tempChar);
            }
        }
    }

    private void MoveChar(int rows, int columns, Vector2 pos, Vector2 offset)
    {
        var index = 0;
        for (var col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                var targetPos = new Vector3(pos.x + (offset.x * row), pos.y - (offset.y * col), 0f);
                StartCoroutine(MoveToPosition(targetPos, characterList[index]));
                index++;
            }
        }
    }

    private IEnumerator MoveToPosition(Vector3 target, Character obj)
    {
        var randomDis = 7f;

        while (Vector3.Distance(obj.transform.position, target) > 0.05f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, randomDis * Time.deltaTime);
            yield return null;
        }
    }
}
