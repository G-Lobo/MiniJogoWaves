using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 4.2f;
    Transform player;
    [SerializeField] int life;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (player)
        {
            Vector3 playerPos = player.position;
        }
    }

    void Update()
    {
        if (player)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * (_moveSpeed * Time.deltaTime);
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}