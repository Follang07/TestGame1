using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBookShooting : MonoBehaviour
{
    [SerializeField] GameObject wizardBookBall;   
    [SerializeField] float spawnRate = 0.5f;

    private GameObject player;
    private GameObject[] enemys;
    private GameObject[] totalWizardBookBalls;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        totalWizardBookBalls = GameObject.FindGameObjectsWithTag("Weapons/Projectiles");

        time += Time.deltaTime;
        if (time >= spawnRate)
        {
            ShootBall();
            time = 0;
        }
    }

    void ShootBall()
    {
        if (Weapon.isWizardBookEquipped && enemys.Length > 0 && player.GetComponent<PlayerLife>().playerAlive)
        {
            Instantiate(wizardBookBall, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
        if(enemys.Length == 0)
        {
            foreach(GameObject balls in totalWizardBookBalls)
            {
                Destroy(balls);
            }
        }
    }

    
}
