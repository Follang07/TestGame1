using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAndArrowLogic : MonoBehaviour
{
    private GameObject arrow;
    private SpriteRenderer arrowSprite;
    private GameObject player;
    private SpriteRenderer playerSprite;
    private GameObject[] enemies;

    public Transform shotPoint;
    public float launchForce = 12;
    public float spawnRate = 1;

    //private int stopper = 0;
    private bool shootingStarted = false;

    Vector2 direction;
    void Start()
    {
        arrow = Resources.Load<GameObject>("Prefabs/Arrow");
        arrowSprite = arrow.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }

    void Update()
    {
        if(!shootingStarted)
        {
            StartCoroutine(Shoot());
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Weapon.isLongBowEquipped)
        {
            if (playerSprite.flipX)
            {
                //Vector3 diffrence = player.transform.position - shotPoint.position;
                shotPoint.position = new Vector3(this.gameObject.transform.position.x - 2.19f, this.gameObject.transform.position.y, shotPoint.position.z);

                arrowSprite.flipX = true;
                if(launchForce > 0) {  launchForce = -launchForce; }
                

                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                direction = transform.right;
            }
            else
            {
                //Vector3 diffrence = player.transform.position - shotPoint.position;
                shotPoint.position = new Vector3(this.gameObject.transform.position.x + 2.19f, this.gameObject.transform.position.y, shotPoint.position.z);

                arrowSprite.flipX = false;
                if(launchForce < 0) { launchForce = -launchForce; }
                
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                direction = transform.right;
            }

        }
    }
    IEnumerator Shoot()
    {
        shootingStarted = true;
        if (enemies.Length > 0 && Weapon.isLongBowEquipped)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = direction * launchForce;
            newArrow.name = "Arrow";
            yield return StartCoroutine(Shoot());
        }
        else
        {
            yield return new WaitForSeconds(1);                
            yield return StartCoroutine(Shoot());           
        }
    }
}
