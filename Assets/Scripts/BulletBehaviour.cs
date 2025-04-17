using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRB;
    [SerializeField] int bulletSpeed = 15;
    [SerializeField] float travelDistance = 6;
    private Transform _player;
    public int damage = 1;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //movimento tiro
        transform.position += transform.up * (bulletSpeed * Time.deltaTime);

        //remove objeto fora da tela

        if (bulletRB.transform.position.y > _player.transform.position.y + travelDistance + 1||
            bulletRB.transform.position.x > _player.transform.position.x + travelDistance + 5)
        {
            Destroy(gameObject);
        }

        if (bulletRB.transform.position.y < _player.transform.position.y - travelDistance - 1||
            bulletRB.transform.position.x < _player.transform.position.x - travelDistance - 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyBehaviour>().EnemyTakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}