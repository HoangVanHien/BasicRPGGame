using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //Damage
    public int damagePoint = 10;
    public float pushForce = 2.0f;

    //Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //Attack
    private Animator animator;
    private float attackCooldown = 0.5f;
    private float lastSwing;
    private bool isAttack = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        //Swing
        if (Input.GetKey(KeyCode.Space))
        {
            BasicAttack();
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (!isAttack) return;

        if (coll.tag == "Fighter")
        {
            if (coll.transform.parent.name != "Player")
            {
                Damage dmg = new Damage(transform.position, damagePoint, pushForce);
                Debug.Log("Dmg: " + dmg.damageAmount + " " + dmg.pushForce);
                coll.transform.parent.SendMessage("ReceiveDamage",dmg);
            }
        }
    }

    private void BasicAttack()
    {
        if (Time.time - lastSwing > attackCooldown)
        {
            lastSwing = Time.time;
            animator.SetTrigger("BasicAttack");
            isAttack = true;
            Invoke("StopAttack", attackCooldown);
        }
    }

    private void StopAttack()
    {
        isAttack = false;
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        //spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }

    public void SetWeaponLevel(int lv)
    {
        weaponLevel = lv;
        //spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
