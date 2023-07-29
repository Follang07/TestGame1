using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CannonLogic : MonoBehaviour
{
    private GameObject player;

    private float angleCanonPlayer;
    Vector2 playerVector;
    Vector2 gameobjectVector;
    void Start()
    {
        playerVector = Vector2.zero; 
        gameobjectVector = Vector2.zero;
    }

    private void Update()
    {
        player = GameObject.Find("Player");
        playerVector = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        Quaternion rotation = Quaternion.LookRotation
            (new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 
                player.transform.position.z + 30 - transform.position.z), transform.TransformDirection(Vector3.up));

        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}