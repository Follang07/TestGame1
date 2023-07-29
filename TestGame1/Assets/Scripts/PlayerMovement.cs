using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 5;

    private float dirX = 0f;
    private float dirY = 0f;

    private enum MovementState { idle, walking }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(-35f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimationState();
    }

    private void Movement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        if (dirX != 0f && dirY != 0f)
        {
            rb.velocity = new Vector2(moveSpeed * dirX / Mathf.Sqrt(2), moveSpeed * dirY / Mathf.Sqrt(2));
        }
        else
        {
            rb.velocity = new Vector2(moveSpeed * dirX, moveSpeed * dirY);

        }
        if (dirX < 0f) { sprite.flipX = true; }
        else { sprite.flipX = false; }
    }

    private void AnimationState()
    {
        
        MovementState state;
        if(dirX == 0 && dirY == 0)
        {
            state = MovementState.idle;
        }
        else
        {
            state = MovementState.walking;
        }
        anim.SetInteger("state", (int)state);
    }
}
