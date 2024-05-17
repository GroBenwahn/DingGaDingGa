using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stroke : MonoBehaviour
{
    Animator animator;
    Rigidbody2D myrigidbody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            animator.SetTrigger("up");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetTrigger("down");
        }
    }
}
