using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4.2f;
    Transform player;

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

            transform.position += direction * (moveSpeed * Time.deltaTime);
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