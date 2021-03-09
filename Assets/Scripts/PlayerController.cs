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
    private float delay;
    public GameObject projectilePrefab;
    public SpriteRenderer p_sprite;
    public Sprite sprite0;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;

    // Start is called before the first frame update
    void Start()
    {
        power = 0;
        apower = 0;
        delay = 60;
        p_sprite = gameObject.GetComponent<SpriteRenderer>();
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
                if (delay == 0)
                {
                    power += 500 * Time.deltaTime;
                }
            }
        }

        //Release Spacebar to fire shot
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (delay == 0)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                apower = power;
                power = 0;
                delay = 60;
                p_sprite.sprite = sprite4;
            }
        }

        //Shot Delay Timer
        if (delay > 0)
        {
            delay -= 1;
        }

        //Change sprite based on current power

        if (delay == 0)
        {
            if (power >= powerMax - 100)
            {
                p_sprite.sprite = sprite0;
            }
            else if (power >= powerMax - 300)
            {
                p_sprite.sprite = sprite1;
            }
            else if (power >= powerMax - 500)
            {
                p_sprite.sprite = sprite2;
            }
            else if (power == 0)
            {
                p_sprite.sprite = sprite3;
            }
        }



    }
}
