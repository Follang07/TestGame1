using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class FinishAwardLogic : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject award;

    private bool IsAwardSpawned = false;
    private bool IsAssigned = false;

    public static int oldRand = 0;

    public GameObject prefab;


    void Start()
    {
        
    }

    void Update()
    {
        if(!(IsAssigned) && award == null)
        {
            switch (oldRand)
            {
                case 1:
                    award = Resources.Load<GameObject>("Prefabs/Vigor");
                    //Debug.Log("Vigor");
                    break;
                case 2:
                    award = Resources.Load<GameObject>("Prefabs/Strength");
                    //Debug.Log("Strength");
                    break;
                case 3:
                    award = Resources.Load<GameObject>("Prefabs/Intelligence");
                    //Debug.Log("Intelligence");
                    break;
                default:
                    //Debug.Log("Error while referencing gameobject");
                    break;
            }
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0 && !(IsAwardSpawned))
        {
            //Debug.Log("Tring to spawn"); 
            SpawnAward();
        }
        //Debug.Log("oldRand: " + oldRand);
    }

    private void SpawnAward()
    {
        if(award == null)
        {
            //Debug.Log("null");
        }
        if( award != null )
        {
            if(SceneSwitcher.sceneCounter != 0 || SceneSwitcher.sceneCounter % 3 != 0)
            {
                //Debug.Log("Spawned");
                prefab = Instantiate(award, new Vector3(transform.position.x, transform.position.y,
                                                                                   transform.position.z), transform.rotation);
                prefab.name = award.name;
            }
            
            IsAwardSpawned = !(IsAwardSpawned);
        }
    }
}
