using UnityEngine;

public class turret1 : MonoBehaviour
{
    public float angularSpeed;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position , transform.position + transform.up, Color.blue);
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        transform.Rotate(0, 0, angularSpeed * Time.deltaTime);

        float dot = Vector3.Dot(transform.up, directionToTarget);

        if (dot >= 0)
        {
            Debug.Log("In Front");
        }
        else
        {
            Debug.Log("Behind");
        }
    }
}
