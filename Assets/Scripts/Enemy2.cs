using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    private float bottomfloat = -10;
    private Animator anim;
    private Rigidbody rb;
    private BoxCollider bc;
    bool isdead = false;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (isdead == true)
        {
            count += 1;
            if (count == 90)
            {
                rb.useGravity = true;
                transform.Rotate(0, 0, 180);
            }
        }

        if (transform.position.y < bottomfloat)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -1.5)
        {
            Debug.Log("Game Over!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow") && isdead == false)
        {
            bc.enabled = false;
            anim.Play("enemy_fall", 0, 0);
            isdead = true;
        }
    }
}
