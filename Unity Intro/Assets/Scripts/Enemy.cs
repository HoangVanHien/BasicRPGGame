using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int xpValue = 1;

    public float triggerLenght = 0.3f;
    public float chaseLenght = 1;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTranform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    public EnemyHitbox enemyHitbox;

    protected override void Start()
    {
        base.Start();
        playerTranform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(playerTranform.position, startingPosition) < chaseLenght)
        {
            if (Vector3.Distance(playerTranform.position, transform.position) < triggerLenght)
            {
                chasing = true;
            }
            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTranform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //Collision work
        collidingWithPlayer = false;
        hitbox.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null) continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }
    }

    protected override void Death()
    {
        gameObject.SetActive(false);
        GameManager.instance.GrantXp(xpValue);
        GameManager.instance.ShowText("+" + xpValue + " exp", 30, Color.magenta,transform.position, Vector3.up * 40, 0.5f);
        Invoke("Respawn", 10f);
    }

    protected void Respawn()
    {
        enemyHitbox.damagePoint += 30;
        xpValue += 10;
        maxHealthpoint += 40;
        healthpoint = maxHealthpoint;
        gameObject.SetActive(true);
    }
}
