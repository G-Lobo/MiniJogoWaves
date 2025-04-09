using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    [SerializeField] private Rigidbody2D PlayerRB;
    [SerializeField] private int speed = 5;
    [SerializeField] private float bulletsCooldown = 0.2f;
    private float _bulletsCooldownTimer;

    public Camera mainCamera;
    
    void Update()
    {
        //movimentaçao do player
        float _inputX = Input.GetAxisRaw("Horizontal");
        float _inputY = Input.GetAxisRaw("Vertical");
        PlayerRB.velocity = new Vector2(_inputX, _inputY).normalized * speed;
        
        //manter na direçao do mouse
        
        Vector2 pointerPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = pointerPosition - PlayerRB.position;
        transform.up = direction;
        
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            _bulletsCooldownTimer += Time.deltaTime;
            if (_bulletsCooldownTimer >= bulletsCooldown)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                _bulletsCooldownTimer = 0;
            }
        }
    }
    
}