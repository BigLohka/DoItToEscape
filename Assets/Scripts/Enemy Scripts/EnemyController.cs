using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{

    private Rigidbody2D physic;

    [Header("Parametrs")]
    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private float enemySpeed;
    [SerializeField]
    private float agroDistance;
    [SerializeField]
    private float health;

void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition.position);
        
        if(distanceToPlayer < agroDistance)
        {
            Atack();
        }
        else
        {
            StopAttack();
        }

        if(health <=0)
        {
            Destroy(gameObject);
        }
    }

    private void Atack()
    {
        if (playerPosition.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-enemySpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 00, 0);
        }
        else if (playerPosition.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(enemySpeed, 0);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void StopAttack()
    {
        physic.velocity = new Vector2(0, 0);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
