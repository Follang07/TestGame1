using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;

public class ExitAndEndLootLogic : MonoBehaviour
{
    Dictionary<int, string> awards = new Dictionary<int, string>()
    {
        {1, "1 Vigor" },
        {2, "1 Strength" },
        {3, "1 Intelligence" }
    };

    public int rand;

    [SerializeField] private TextMeshPro awardText;
    private GameObject[] enemies;
    private GameObject cam;
    private SceneSwitcher sceneSwitcher;

    public bool isCollided = false;
    
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        sceneSwitcher = cam.GetComponent<SceneSwitcher>();
        rand = Random.Range(1, awards.Count + 1);
    }

    void Update()
    {
        //Debug.Log(rand + " " + oldRand);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0) 
        {
            awardText.text = awards[rand];
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isCollided)
        {
            isCollided = true;
            FinishAwardLogic.oldRand = rand;
            sceneSwitcher.NextScene();
            isCollided = false; 
        }   
    }
}
