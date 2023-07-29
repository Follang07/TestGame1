using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballShoot : MonoBehaviour
{
    private GameObject cannonball;
    private GameObject[] enemies;
    private bool firstCannonShoot = true;

    public static bool cannonballSpawned = false;
    void Start()
    {
        cannonball = Resources.Load<GameObject>("Prefabs/Cannonball");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        StartCoroutine(CannonballShooting());
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");      
    }

    IEnumerator CannonballShooting()
    {
        if(firstCannonShoot)
        {
            yield return new WaitForSeconds(3);
            firstCannonShoot = false;
        }
        if(enemies.Length > 0 && !firstCannonShoot)
        {
            if(!cannonballSpawned)
            {
                GameObject prefab = Instantiate(cannonball, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                prefab.name = "Cannonball";
                cannonballSpawned = true;
                StartCoroutine(CannonballShooting());
            }
            else
            {
                yield return new WaitForSeconds(2);
                StartCoroutine(CannonballShooting());
            }
        }
        else{ yield return null; }
    }
}
