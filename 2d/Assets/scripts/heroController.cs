using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroController : MonoBehaviour
{
    public GameObject gmo;
    public float velocity = 6.0f;
    public float jumpForce = 5.0f;
    Quaternion rot;

    float bonus = 0;

    SpriteRenderer sr;
    SpriteRenderer sr2;

    Rigidbody2D rb;
    Vector3 pos;
    public bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr2 = gmo.GetComponent<SpriteRenderer>();
        pos = this.gameObject.transform.position;
        gmo = new GameObject();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
            sr.enabled = true;
            sr2.enabled = false;
        }

        if (collision.gameObject.tag == "enemy")
            Application.LoadLevel(Application.loadedLevel);
    }

    private void FixedUpdate()
    {
            pos = new Vector3(Input.GetAxis("Horizontal") * velocity * Time.deltaTime, 0, 0);
            this.gameObject.transform.position += pos;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rot.y = 180;
            this.gameObject.transform.rotation = rot;
            gmo.transform.rotation = rot;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rot.y = 0;
            this.gameObject.transform.rotation = rot;
            gmo.transform.rotation = rot;
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            sr.enabled = false;
            sr2.enabled = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bonus")
        {
            bonus++;
            Destroy(collision.gameObject);
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 20, 20), "Bonus: " + bonus);
    }
}
