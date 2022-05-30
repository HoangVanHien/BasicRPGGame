using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    public float boundX = 0.3f;
    public float boundY = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()//call after Upadte() and FixedUpdate() //Call after every object update their part
    {
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;//lookAt is the character, tranform is the camera center
        if(deltaX > boundX) //Character out of camera bound right
        {
            delta.x = deltaX - boundX;
        }
        else if(deltaX < -boundX) //Character out of camera bound left
        {
            delta.x = deltaX + boundX;
        }

        float deltaY = lookAt.position.y - transform.position.y;//lookAt is the character, tranform is the camera center
        if (deltaY > boundY) //Character out of camera bound up
        {
            delta.y = deltaY - boundY;
        }
        else if (deltaY < -boundY) //Character out of camera bound down
        {
            delta.y = deltaY + boundY;
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
