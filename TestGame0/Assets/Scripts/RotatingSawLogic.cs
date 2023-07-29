using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSawLogic : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    private GameObject player;
    private EnemyLife _enemyLife;
    private string parentName;

    //private bool initiateRotatingSaw = false;

    [SerializeField] private float RotateSpeed = 5f;
    [SerializeField] private float Radius = 5f;
    [SerializeField] public static int damage_RotatingSaw = 10;


    private Vector2 _centre;
    private float _angle;




    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        
    }

    void Update()
    {
        try
        {
            parentName = gameObject.transform.parent.name;
        }
        catch (NullReferenceException) { }
        
        
        if (Weapon.isRotatingSawEquipped && parentName == "Weapons")
        {
            _centre = player.transform.position;

            _angle += RotateSpeed * Time.deltaTime;
            float tiltAroundZ = -_angle * RotateSpeed * Radius * 10;
            Quaternion rotation = Quaternion.Euler(0, 0, tiltAroundZ);
            transform.rotation = rotation;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre + offset;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemyLife = collision.GetComponent<EnemyLife>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyLife.ChangeHealth(damage_RotatingSaw);
        }
    }
}
