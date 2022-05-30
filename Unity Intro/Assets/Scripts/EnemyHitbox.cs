using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 2f;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.transform.parent.name == "Player")
        {
            Damage dmg = new Damage(transform.position, damagePoint, pushForce);
            coll.transform.parent.SendMessage("ReceiveDamage", dmg);
        }
    }
}
