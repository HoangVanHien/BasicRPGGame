using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    public int mana = 20;
    public int maxMana = 20;

    private float lastManaUp = 0;
    private float manaUpDuration = 0.5f;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");//-1 left, 0 nothing, 1 right
        float y = Input.GetAxisRaw("Vertical");
        UpdateMotor(new Vector3(x, y, 0));
        UpdateMana();
    }

    private void UpdateMana()
    {
        if (Time.time - lastManaUp >= manaUpDuration)
        {
            if (mana < maxMana)
            {
                mana += 1;
                lastManaUp = Time.time;
            }
        }
    }

    //public void SwapSprite(int skinID)
    //{
    //   spriteRenderer.sprite = GameManager.instance.playerSprites[skinID];
    //}

    public void OnLevelUp()
    {
        maxHealthpoint += 20;
        healthpoint = maxHealthpoint;
        maxMana += 10;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }
}
