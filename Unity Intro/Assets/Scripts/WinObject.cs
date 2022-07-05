using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObject : Collectable
{
    protected override void OnCollect()
    {
        base.OnCollect();
        GameManager.instance.endGame.WinGame();
    }
}
