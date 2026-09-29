using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 1f;


    private void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction = direction.normalized;
        transform.position += direction *moveSpeed * Time.deltaTime;
    }


}
