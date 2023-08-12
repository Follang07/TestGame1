using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int health = 5;


    void Start()
    {
        switch (gameObject.name)
        {
            case "Ghoul":
                health = 100;
                break;
            case "Wizard":
                health = 40;
                break;
            case "Fireball":
                health = 20;
                break;
            case "Cannon":
                health = 50;
                break;
            case "Cannonball":
                health = 25;
                break;
            default:
                Debug.Log("Error while assigning the proper enemy");
                break;
        }        
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void ChangeHealth(int damage)
    {

        switch (gameObject.name)
        {
            case "Ghoul":
                health -= damage;
                break;
            case "Wizard":
                health -= damage;
                break;
            case "Fireball":
                health -= damage;
                break;
            case "Cannon":
                health -= damage;
                break;
            case "Cannonball":
                health -= damage;
                break;
            default:
                Debug.Log("Error while changing the enemy health");
                break;
        }
        //Debug.Log(health);
    }
}
