using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    private float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obitalMotion(3f, 1f, planetTransform);
    }

     void obitalMotion(float radius, float speed, Transform target)
    {
        currentAngle += speed * Time.deltaTime;

        float xPosition = Mathf.Cos(currentAngle) * radius;
        float yPosition = Mathf.Sin(currentAngle) * radius;

        Vector3 newPositionOfMoon = target.position + new Vector3(xPosition, yPosition, 0f);

        transform.position = newPositionOfMoon;
    }
}
