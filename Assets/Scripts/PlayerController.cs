using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float rotationSpeed;
    public float verticalInput;
    public float powerMax;
    public float power;
    public float apower;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        power = 0;
        apower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Up/Down Arrows rotates bow up/down
        verticalInput = Input.GetAxis("Vertical");

        if (transform.rotation.eulerAngles.z > 65 && transform.rotation.eulerAngles.z < 75)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self);
        }

        if (transform.rotation.eulerAngles.z > 310 && transform.rotation.eulerAngles.z < 320)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime, Space.Self);
        }

        transform.Rotate(0, 0, rotationSpeed * verticalInput * Time.deltaTime, Space.Self);

        //Hold Spacebar to charge up shot
        if (Input.GetKey(KeyCode.Space))
        {
            if (power < powerMax)
            {
                power += 2;
            }
        }

        //Release Spacebar to fire shot
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            apower = power;
            power = 0;
        }


    }
}
