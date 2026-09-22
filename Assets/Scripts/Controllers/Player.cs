using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public float bombTrailSpacing;
    public int numberOfTrailBombs;


    void Start()
    {
        Debug.Log(NormalizeVector(new Vector2(3, 4)));
        Debug.Log(NormalizeVector(new Vector2(-3, 2)));
        Debug.Log(NormalizeVector(new Vector2(1.5f, -3.5f)));
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(Vector3.up);

        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            spawnBombTrail(bombTrailSpacing, numberOfTrailBombs);

        }

    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        Instantiate(bombPrefab, transform.position + inOffset, Quaternion.identity);
    }

    Vector2 NormalizeVector(Vector2 inVector)
    {
        float magnitude = inVector.magnitude;

        Vector2 outVector = new Vector2(inVector.x / magnitude, inVector.y / magnitude);

        return outVector;
    }

    void spawnBombTrail(float bombTrailSpacing, int numberOfTrailBombs)
    {

        Vector2 trailBombOffset = new Vector2();

        for (int i = 1; i <= numberOfTrailBombs; i++)
        {
            trailBombOffset = Vector2.down * bombTrailSpacing * i;

            SpawnBombAtOffset(trailBombOffset);
        }

    }

}
