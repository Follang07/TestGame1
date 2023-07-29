using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimationState(Collider2D gm)
    {
        anim.SetTrigger("pickUp");
    }
    private void ObjectDestroy()
    {
        Destroy(this.gameObject);
    }
}
