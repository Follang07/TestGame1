using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Sprite hearthSprite;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private static Image[] hearths;
    [SerializeField] public static int health = 3;



    
    private int oldHealth = health;
    public bool playerAlive = true;

    PlayerStats _playerStats;

    
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        hearths = FindObjectsByType<Image>(FindObjectsSortMode.InstanceID);
        for (int i = 0; i < hearths.Length; i++)
        {
            if(i < health) 
            {
                hearths[i].enabled = true;
                hearths[i].sprite = hearthSprite;
            }
            else
            {
                hearths[i].enabled = false;
            }


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
           health--;
            if (health <= 0)
            {
                Die();
                playerAlive = false;
            }
        }
    }
    private void Die()
    {
        anim.SetTrigger("death");
        sprite.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        Weapon.isWizardBookEquipped = false;
        PlayerStats.vigor = _playerStats.oldVigor;
        health = oldHealth;
        SceneManager.LoadScene(0);
    }
}
