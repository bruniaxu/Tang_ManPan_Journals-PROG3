using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 1f;

    //final assignemnt 
    public float LightningStrength = 2f;
    public float LightningSpeed = 3f;
    private float lightningTimer = 0f;

    private void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction = direction.normalized;
        Vector3 sidewaysDirection = new Vector3(-direction.y, direction.x, 0f);
        lightningTimer += Time.deltaTime;
        float Lightning = Mathf.Sin(lightningTimer * LightningSpeed);
        Vector3 newDirection = direction + sidewaysDirection * Lightning * LightningStrength;
        transform.position += newDirection.normalized * moveSpeed * Time.deltaTime;
    }


}
