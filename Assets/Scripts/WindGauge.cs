using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGauge : MonoBehaviour
{
    private Animator anim;
    private int randomAngle;
    public float currDirection;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("ChangeDirection", 4, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeDirection()
    {
        randomAngle = Random.Range(45, 270);
        transform.Rotate(0, 0, randomAngle, Space.Self);
    }
}
