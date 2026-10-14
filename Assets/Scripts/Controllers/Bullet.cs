using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform enemyTransform;
    public float moveSpeed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();
    }

    void BulletMovement()
    {
        Vector3 direction = enemyTransform.position - transform.position;
        direction = direction.normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
