using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    private Vector3 currentPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private int startStar = 0;

    private void Start()
    {
        startPosition = starTransforms[startStar].position;
        endPosition = starTransforms[startStar+ 1].position;
        currentPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    private void DrawConstellation()
    {

        for (int i = 0; i < startStar; i++)
        {
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.yellow);
        }

        float distance = Vector3.Distance(startPosition, endPosition);
        float drawingSpeed = distance / drawingTime;

        Vector3 direction = endPosition - currentPosition;
        direction = direction.normalized;
        currentPosition += direction * drawingSpeed * Time.deltaTime;
        float distanceToEnd = Vector3.Distance(currentPosition, endPosition);
        if (distanceToEnd <= 0.1f)
        {
            currentPosition = endPosition;
            startStar++;
            if(startStar >= starTransforms.Count - 1)
            {
                startStar = 0;
            }

            startPosition = starTransforms[startStar].position;
            endPosition = starTransforms[startStar + 1].position;
            currentPosition = startPosition;
        }

        Debug.DrawLine(startPosition, currentPosition, Color.yellow);
    }
}
