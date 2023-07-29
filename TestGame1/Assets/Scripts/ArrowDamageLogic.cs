using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamageLogic : MonoBehaviour
{
    public static int damage_Arrow = 10;

    private EnemyLife _enemyLife;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TESTETST");
        _enemyLife = collision.GetComponent<EnemyLife>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyLife.ChangeHealth(damage_Arrow);
            Destroy(this.gameObject);
        }
    }
}
