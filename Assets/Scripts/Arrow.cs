using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float power;
    private Rigidbody arrowRb;
    private BoxCollider arrowBc;
    private float bottombound = -10;
    bool hashit;

    // Start is called before the first frame update
    void Start()
    {
        //Get power variable from player
        playerControllerScript = GameObject.Find("spr_archer_bow").GetComponent<PlayerController>();
        power = playerControllerScript.apower;

        arrowRb = GetComponent<Rigidbody>();
        arrowBc = GetComponent<BoxCollider>();
        arrowRb.AddRelativeForce(Vector3.right * power);
    }

    // Update is called once per frame
    void Update()
    {
        if (hashit == false)
        {
            float angle = Mathf.Atan2(arrowRb.velocity.y, arrowRb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (transform.position.y < bottombound)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && hashit == false)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.tag = "Untagged";
        hashit = true;
        arrowRb.velocity = Vector3.zero;
        arrowRb.isKinematic = true;
    }
}
