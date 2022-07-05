using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text message;

    public void WinGame()
    {
        message.text = "You have won!!!";
        gameObject.SetActive(true);
    }

    public void LoseGame()
    {
        message.text = "You lose T^T";
        gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MySceneManager.instance.ReturnToMainMenu();
    }
}
