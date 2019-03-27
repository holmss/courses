using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroController : MonoBehaviour
{
    public float velocity = 6.0f;
    public float jumpForce = 5.0f;

    public float bonus = 0;

    Rigidbody2D rb;
    Rigidbody2D rb2;

    SpriteRenderer sr, sr2;

    Quaternion rot;

    Vector3 pos;

    bool grounded = false;

    public GameObject gmo; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb2 = gmo.GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();
        sr2 = gmo.GetComponent<SpriteRenderer>();

        pos = gameObject.transform.position;
        rot.y = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
            sr.enabled = true;
            sr2.enabled = false;
        }

        if (collision.gameObject.tag == "die")
            Application.LoadLevel(Application.loadedLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bonus")
        {
            bonus++;
            Destroy(collision.gameObject);
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rot.y = 180;
            gameObject.transform.rotation = rot;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rot.y = 0;
            gameObject.transform.rotation = rot;
        }

        pos = new Vector3(Input.GetAxis("Horizontal") * velocity * Time.deltaTime, 0, 0);
        gameObject.transform.position += pos; //gameObject.transform.position = gameObject.transform.position + pos

        if(grounded && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            sr.enabled = false;
            sr2.enabled = true;
            grounded = false;
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 200, 20), "Bonus: " + bonus);
    }
}
