using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    private Vector3 randomPoint;

    // Start is called before the first frame update
    void Start()
    {
       chooseRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        Vector3 direction = randomPoint - transform.position;
        direction = direction.normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, randomPoint);
        if (distance <= arrivalDistance)
        {
            chooseRandomPoint();
        }
    }

    void chooseRandomPoint()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        randomDirection = randomDirection.normalized;
        randomPoint = transform.position + randomDirection * maxFloatDistance;
    }
}
