using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Vector3 pos;
    float v = 3.0f;

    public float dir = 1;

    //public bool position = false;

    void Start()
    {
        pos = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rotate")
            dir *= -1;
    }

    void FixedUpdate()
    {

        //if(pos.x >= 1.0f)
        //{
        //    position = true;
        //    pos = new Vector3(v * Time.deltaTime * 1, 0, 0);
        //    gameObject.transform.position += pos;
        //}
        //else if (pos.x <= 3.68f)
        //{
        //    pos = new Vector3(v * Time.deltaTime * -1, 0, 0);
        //    gameObject.transform.position += pos;
        //}

        pos = new Vector3(v * Time.deltaTime * dir, 0, 0);
        gameObject.transform.position += pos;

        //if (pos.x <= 3.5f)
        //{
        //    pos = new Vector3(v * Time.deltaTime, 0, 0);
        //    gameObject.transform.position -= pos;
        //}
        //else if (pos.x >= 1.0f)
        //{
        //    pos = new Vector3(v * Time.deltaTime, 0, 0);
        //    gameObject.transform.position += pos;
        //}
    }
}
