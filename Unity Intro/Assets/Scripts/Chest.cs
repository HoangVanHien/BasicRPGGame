using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int goldAmount = 5;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;//switch the current renderer with the emptyChest
            GameManager.instance.gold += goldAmount;
            GameManager.instance.ShowText("+" + goldAmount + " gold!", 25, Color.yellow, transform.position, new Vector3(0, 50, 0), 1.0f);
        }
    }
}
