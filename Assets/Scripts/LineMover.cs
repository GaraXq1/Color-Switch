using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMover : MonoBehaviour
{
    public float speed = 100f;
    
    bool Flip = false;
    void Update()
    {
        if(transform.position.x >= 1)
        {
            Flip = true;
        }
        else if(transform.position.x <= -8)
        {
            Flip = false;
        }
        if (Flip)
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
        if (!Flip)
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }


    }

}
