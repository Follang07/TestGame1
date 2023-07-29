using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    private GameObject[] enemies;

    private string[] nextscene = { "MAIN SAVE 1", "MAIN SAVE 2", "MAIN SAVE 3", "MAIN SAVE 4", "MAIN SAVE 5"
                                                                , "MAIN SAVE 6", "MAIN SAVE 7", "MAIN SAVE 8", "MAIN SAVE 9" };
    public GameObject player;
    private UnityEngine.SceneManagement.Scene currentScene;

    private static bool nextScene = false;

    private static int sceneCounter = 0;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void NextScene()
    {
        //Debug.Log("0.5");
        if (enemies.Length == 0 && !nextScene)
        {
            nextScene = true;
            //Debug.Log("1");
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        //Debug.Log("2");
        //yield return new WaitForSeconds(1);
        currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextscene[sceneCounter], LoadSceneMode.Additive);
        //Debug.Log("3");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(nextscene[sceneCounter]));
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(nextscene[sceneCounter]));
        sceneCounter++;
        player.transform.position = new Vector2(-35f, 1.5f);
        SceneManager.UnloadSceneAsync(currentScene);
        //Debug.Log("4");
        nextScene = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
