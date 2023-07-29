using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TargetFollower : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float speed = 10f;


    private float pos;
    private float oldPos;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //distance = Vector3.Distance(target.position, transform.position);
        if (target) 
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }

        pos = transform.position.x;
        if (pos - oldPos > 0)
        {
            sprite.flipX = true;
        }
        else if(pos - oldPos < 0) 
        {
            sprite.flipX = false;
        }
        oldPos = pos;       
    }
}
