using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject weapons;
    private SpriteRenderer spriterend;
    private GameObject player;
    private Transform textTransform;

    public static bool isWizardBookEquipped = false;
    public static bool isRotatingSawEquipped = false;
    public static bool isLongBowEquipped = false;
    public static bool isSharpySpikesEquipped = false;

    private TextMeshPro infoText;

    void Start()
    {
        spriterend = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        weapons = GameObject.Find("Weapons");
        textTransform = gameObject.transform.GetChild(0);
    }


    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            infoText = gameObject.GetComponentInChildren<TextMeshPro>();
            infoText.enabled = true;         
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                textTransform.gameObject.SetActive(false);

                transform.parent = weapons.transform;
                transform.position = player.transform.position;

                switch (gameObject.name)
                {
                    case "Wizard Book":
                        if (!isWizardBookEquipped) 
                        {
                            isWizardBookEquipped = true;
                            spriterend.enabled = false;
                        }                       
                        break;
                    case "RotatingSaw":
                        if (!isRotatingSawEquipped) 
                        { 
                            isRotatingSawEquipped = true;               
                        }        
                        break;
                    case "Long Bow":
                        if (!isLongBowEquipped)
                        {
                            isLongBowEquipped = true;         
                            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        }
                        break;
                    case "Sharpy Spikes":
                        if(!isSharpySpikesEquipped)
                        {
                            isSharpySpikesEquipped = true;
                        }
                        break;

                    default:
                        Debug.Log("Error while item equipping");
                        break;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(textTransform.gameObject.activeSelf)
            {
                infoText = gameObject.GetComponentInChildren<TextMeshPro>();
                infoText.enabled = false;
            }           
        }     
    }
}
