using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpySpikesLogic : MonoBehaviour
{
    private Animator anim;
    private GameObject[] enemies;
    private EnemyLife _enemyLife;

    public static int damage_SharpySpikes = 10;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(Weapon.isSharpySpikesEquipped && enemies.Length > 0)
        {
            anim.SetBool("rotate", true);
        }
        else
        {
            anim.SetBool("rotate", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemyLife = collision.GetComponent<EnemyLife>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyLife.ChangeHealth(damage_SharpySpikes);
        }
    }
}
