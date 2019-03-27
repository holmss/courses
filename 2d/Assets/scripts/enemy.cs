using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    void FixedUpdate()
    {
        this.gameObject.transform.Rotate(0, 0, -1);
    }
}
