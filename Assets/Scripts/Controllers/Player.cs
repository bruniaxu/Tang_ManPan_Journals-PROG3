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
    public float inMaxRange;


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
            DetectAsteroids(inMaxRange, asteroidTransforms);
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
        for (int i = 0; i < inAsteroids.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, inAsteroids[i].position);

            Vector3 direction = inAsteroids[i].position - transform.position;

            Vector3 endPosition = transform.position + direction.normalized * 2.5f;

            if (distance <= inMaxRange)
            {
                Debug.DrawLine(transform.position, endPosition, Color.green);
            }

        }
    }

    void PlayerMovement()
    {

    }

}
