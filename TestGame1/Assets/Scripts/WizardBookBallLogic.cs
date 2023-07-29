using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBookBallLogic : MonoBehaviour
{
    [SerializeField] public static int damage_WizardBook = 20;

    private EnemyLife _enemyLife;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enemyLife = collision.GetComponent<EnemyLife>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemyLife.ChangeHealth(damage_WizardBook);
            Destroy(this.gameObject);
        }
    }
}
