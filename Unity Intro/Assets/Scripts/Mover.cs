using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Fighter
{
    [SerializeField] private CircleCollider2D groundCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float xSpeed = 0.75f;
    protected float ySpeed = 1.0f;

    private float defaultFaceDirect;

    private bool isRunning;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        defaultFaceDirect = transform.localScale.x;
    }

    

    // Update is called once per frame
    protected virtual void UpdateMotor(Vector3 input)
    {
        //reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);
        
        //animation
        characterAnimator.SetFloat("RunSpeed", moveDelta.magnitude);

        //Change direction right or left
        if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(defaultFaceDirect, transform.localScale.y, transform.localScale.z); //Nothing change
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-defaultFaceDirect, transform.localScale.y, transform.localScale.z);
        }

        //Push back
        moveDelta += pushDirection;
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);//reduce pushDirection

        //Check to know if there is a thing in the direction we want to go
        hit = Physics2D.CircleCast(groundCollider.transform.position + (Vector3)groundCollider.offset, groundCollider.radius, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            //Move
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);//Time.deltaTime to make it go with the real time
        }

        hit = Physics2D.CircleCast(groundCollider.transform.position + (Vector3)groundCollider.offset, groundCollider.radius, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            //Move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);//Time.deltaTime to make it go with the real time
        }

    }
}
