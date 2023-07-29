using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class WizardFire : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fireball;
    [SerializeField] private float fireRadius = 15f;

    private float distance;
       
    private float spawnRate = 3;
    public int fireballCount = 0;

    private enum MovementState { idle, firing }

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(ShootFireball());
    }
    private void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
    }
    
    IEnumerator ShootFireball()
    {
        MovementState state;
        if (distance < fireRadius && fireballCount <= 5)
        {
            state = MovementState.firing;
            anim.SetInteger("state", (int)state);
            yield return new WaitForSeconds(spawnRate);

            GameObject prefab = Instantiate(fireball, new Vector3(transform.position.x - 2, transform.position.y, 0), transform.rotation);
            prefab.transform.parent = transform;
            prefab.name = "Fireball";
            fireballCount++;

            yield return StartCoroutine(ShootFireball());
        }
        else 
        {
            state = MovementState.idle;
            anim.SetInteger("state", (int)state);
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(ShootFireball()); 
        }
    }

    
}
