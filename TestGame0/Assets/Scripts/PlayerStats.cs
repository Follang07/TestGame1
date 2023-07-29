using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{


    [SerializeField] public static int vigor; //hp increase
    [SerializeField] public static int strength; // more damage on ad items
    [SerializeField] public static int intelligence; // more damage on ap items

    

    //private GameObject _vigor;
    //private GameObject _strength;
    //private GameObject _intelligence;
    
    public int oldVigor = vigor;
    //public int oldStrength = strength;
    //public int oldIntelligence = intelligence;
    
    private int vigorTemp = 0;
    private int strengthTemp = 0;
    private int intelligenceTemp = 0;

    private TextMeshPro infoText;

    private bool KeyF;

    void Start()
    {
        
        //_vigor = GameObject.Find("Vigors");
        //_strength = GameObject.Find("Strengths");
        //_intelligence = GameObject.Find("Intelligences");
    }

    void Update()
    {
        //Debug.Log("vigor:" + vigor + " strength:" + strength + " intelligence:" + intelligence);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectibles/Stats")
        {
            infoText = collision.gameObject.GetComponentInChildren<TextMeshPro>();
            infoText.enabled = true;
            //collision.GetComponent<Collider2D>().enabled = false;
            /*if (collision.gameObject.name == "Vigor")
            {
                infoText = collision.gameObject.GetComponentInChildren<TextMeshPro>();
                infoText.enabled = true;
                
            }
            if (collision.gameObject.name == "Strength")
            {
                infoText = collision.gameObject.GetComponentInChildren<TextMeshPro>();
                infoText.enabled = true;
            }
            if (collision.gameObject.name == "Intelligence")
            {
                infoText = collision.gameObject.GetComponentInChildren<TextMeshPro>();
                infoText.enabled = true;
            }*/
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectibles/Stats")
        {
            //collision.GetComponent<Collider2D>().enabled = false;
            if (collision.gameObject.name == "Vigor")
            {
                if (Input.GetButtonDown("Interact"))
                {
                    vigor++;
                    vigorTemp++;
                    if (vigorTemp == 5 && vigor <= 20)
                    {
                        PlayerLife.health++;
                        vigorTemp = 0;
                    }
                    collision.gameObject.GetComponent<StatsAnimation>().AnimationState(collision);
                }
            }
            if (collision.gameObject.name == "Strength")
            {
                if (Input.GetButtonDown("Interact"))
                {
                    strength++;
                    strengthTemp++;
                    if (strengthTemp == 5 && strength <= 20)
                    {
                        RotatingSawLogic.damage_RotatingSaw = RotatingSawLogic.damage_RotatingSaw * 11 / 10;
                        ArrowDamageLogic.damage_Arrow = ArrowDamageLogic.damage_Arrow * 11 / 10;
                        strengthTemp = 0;
                    }
                    collision.gameObject.GetComponent<StatsAnimation>().AnimationState(collision);
                }
            }
            if (collision.gameObject.name == "Intelligence")
            {
                if (Input.GetButtonDown("Interact"))
                {
                    intelligence++;
                    intelligenceTemp++;
                    if (intelligenceTemp == 5 && intelligence <= 20)
                    {
                        WizardBookBallLogic.damage_WizardBook = WizardBookBallLogic.damage_WizardBook * 11 / 10;
                        intelligenceTemp = 0;
                    }
                    collision.gameObject.GetComponent<StatsAnimation>().AnimationState(collision);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectibles/Stats")
        {
            infoText = collision.gameObject.GetComponentInChildren<TextMeshPro>();
            infoText.enabled = false;
        }
    }
}
