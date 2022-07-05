using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;
    public int difficulty;

    // Start is called before the first frame update
    private void Awake()
    {
        if (MySceneManager.instance != null)//if there is already a GameManager
        {
            Destroy(gameObject);//Destroy the new GameManager that being duplicated
            return;
        }
        instance = this;//To make all the instance being call become this
        DontDestroyOnLoad(gameObject);//prevent this gameObject (GameManager) from being deleted when load a new scene
    }

    public void NewGame(int difficulty)
    {
        SceneManager.LoadScene("Main");
        this.difficulty = difficulty;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
