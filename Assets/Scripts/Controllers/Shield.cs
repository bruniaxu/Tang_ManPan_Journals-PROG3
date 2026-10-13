using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 360f;
    public float radius = 1f;
    private float currentAngle = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += rotationSpeed * Time.deltaTime;
        float angleInRadians = currentAngle * Mathf.Deg2Rad;
        float xPosition = Mathf.Cos(angleInRadians) * radius;
        float yPosition = Mathf.Sin(angleInRadians) * radius;
        Vector3 shieldPosition = new Vector3(xPosition, yPosition, 0f);
        transform.position = playerTransform.position + shieldPosition;
    }
}
