using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //animator
    public Animator characterAnimator;

    //Public feilds
    public int healthpoint = 20;
    public int maxHealthpoint = 20;
    public float pushRecoverySpeed = 0.2f;

    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            healthpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 30, Color.red, transform.position, pushDirection * 50f, 0.5f);

            //animation
            characterAnimator.SetTrigger("GetHit");


            if (healthpoint <= 0)
            {
                healthpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
