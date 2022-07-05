using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public string[] senceNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //Teleport
            //GameManager.instance.SaveState();
            string senceName = senceNames[Random.Range(0, senceNames.Length)];
            SceneManager.LoadScene(senceName);
        }
    }
}
