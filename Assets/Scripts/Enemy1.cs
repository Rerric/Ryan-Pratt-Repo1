using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private BoxCollider bc;
    bool isdead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x == -1.5)
        {
            Debug.Log("Game Over!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow") && isdead == false)
        {
            bc.enabled = false;
            anim.Play("enemy_death", 0, 0);
            isdead = true;
        }
    }
}
