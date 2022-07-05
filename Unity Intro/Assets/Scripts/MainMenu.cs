using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void NewGame(int difficulty)
    {
        MySceneManager.instance.NewGame(difficulty);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
