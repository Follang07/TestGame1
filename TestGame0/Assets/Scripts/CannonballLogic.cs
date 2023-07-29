using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CannonballLogic : MonoBehaviour
{
    private GameObject player;
    private Vector2 playerPos;
    private bool playerPosTaken;
    private float step;

    public float speed = 15f;
    

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        step = speed * Time.deltaTime;

        if (!playerPosTaken)
        {
            PosOfPlayer();
        }
        if (CannonballShoot.cannonballSpawned)
        {
            playerPosTaken = true;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, step);
        }
        if(Mathf.Approximately(transform.position.x, playerPos.x) && Mathf.Approximately(transform.position.y,playerPos.y))
        {
            CannonballShoot.cannonballSpawned = false;
            Destroy(gameObject);
        }
    }

    private void PosOfPlayer()
    {
        playerPos = player.transform.position;       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CannonballShoot.cannonballSpawned = false;
            playerPosTaken = false;
            Destroy(gameObject);
        }
    }
}
