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

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            SpawnBombOnRandomCorner(2f);
        }
 
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            WarpPlayer(enemyTransform, 1f);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            DetectAsteroids(10f, asteroidTransforms);
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

    void SpawnBombOnRandomCorner(float inDistance)
    {
        int randomCorner = Random.Range(0, 4);
        Vector3 cornerDirection = Vector3.zero;

        if (randomCorner == 0)
        {
            cornerDirection = Vector3.up + Vector3.right;
        }else if (randomCorner == 1)
        {
            cornerDirection = Vector3.up + Vector3.left;
        }else if (randomCorner == 2)
        {
            cornerDirection = Vector3.down + Vector3.right;
        }else if (randomCorner == 3)
        {
            cornerDirection = Vector3.down + Vector3.left;
        }

        cornerDirection = cornerDirection.normalized;
        Vector3 bombOffset = cornerDirection * inDistance;
        SpawnBombAtOffset(bombOffset);

        Debug.Log(cornerDirection);
    }

    void WarpPlayer(Transform target, float ratio)
    {
        transform.position = Vector3.Lerp(transform.position, target.position, ratio);
    }
    void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroid in asteroidTransforms)
        {
            float distance = Vector3.Distance(transform.position, asteroid.position);
            if (distance <= inMaxRange)
            {
                Vector3 direction = asteroid.position - transform.position;
                direction = direction.normalized;
                // Make the direction 2.5 units long
                Vector3 lineDirection = direction * 2.5f;
                Vector3 lineEnd = transform.position + lineDirection;
                Debug.DrawLine(transform.position, lineEnd, Color.green, 1f);
            }
        }
        
    }
}
