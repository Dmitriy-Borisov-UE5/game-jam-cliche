using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTilt : MonoBehaviour
{

    float maxRotation = 40f;
    float minRotation = -40f;
    float currentRotation = 0f;
    Vector3 newPosition;
    public GameObject followTransform;
    float xspeed;
    float yspeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentRotation--;
            Physics2D.gravity = new Vector2(-3f, -9.32f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentRotation++;
            Physics2D.gravity = new Vector2(3f, -9.32f);
        }


        currentRotation = currentRotation * 0.95f;
        if (currentRotation < 0.01f && currentRotation > -0.01f)
        {
            currentRotation = 0;
            Physics2D.gravity = new Vector2(0, -9.8f);
        }

        if (currentRotation > maxRotation)
        {
            currentRotation = maxRotation;
        }

        if (currentRotation < minRotation)
        {
            currentRotation = minRotation;
        }

        Vector3 newPosition = new Vector3(0, 0, currentRotation);

        transform.eulerAngles = newPosition;


        xspeed = followTransform.transform.position.x - this.transform.position.x;
        yspeed = followTransform.transform.position.y - this.transform.position.y;

        if (xspeed > 1f || xspeed < -1f)
        {
            if (currentRotation == 0f && followTransform.GetComponent<Rigidbody2D>().velocity.y == 0f)
            {
                followTransform.GetComponent<Rigidbody2D>().velocity = new Vector3(followTransform.GetComponent<Rigidbody2D>().velocity.x,+ xspeed * 5, 0);
            }
        }

        xspeed = xspeed * 0.005f;
        yspeed = yspeed * 0.005f;


        this.transform.position = new Vector3(this.transform.position.x + xspeed, this.transform.position.y + yspeed, this.transform.position.z);
    }
}
