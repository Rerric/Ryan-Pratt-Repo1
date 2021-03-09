using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private BoxCollider bc;
    private LivesMeter lmscript;
    bool through = false;
    bool isdead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider>();
        lmscript = GameObject.Find("Lives Meter").GetComponent<LivesMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < -3.5)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -3.0)
        {
            if (through == false)
            {
                lmscript.lives -= 1;
            }
            through = true;
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
