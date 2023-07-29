using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower2 : MonoBehaviour
{
    Transform target;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float speed = 10f;

    [SerializeField] GameObject[] enemys;

    Transform[] enemiesTransform;
    private float pos;
    private float oldPos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesTransform = new Transform[enemys.Length];
        for (int i = 0; i < enemys.Length; i++)
        {
            enemiesTransform[i] = enemys[i].transform;
        }
        target = GetClosestEnemy(enemiesTransform);

        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        pos = transform.position.x;
        if (pos - oldPos > 0)
        {
            sprite.flipX = true;
        }
        else if (pos - oldPos < 0)
        {
            sprite.flipX = false;
        }
        oldPos = pos;
    }

    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}
