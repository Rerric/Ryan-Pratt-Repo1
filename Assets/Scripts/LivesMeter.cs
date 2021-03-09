using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesMeter : MonoBehaviour
{
    public GameObject child1, child2, child3, child4;
    public float lives;

    // Start is called before the first frame update
    void Start()
    {
        child1 = GameObject.Find("spr_mark_1");
        child2 = GameObject.Find("spr_mark_2");
        child3 = GameObject.Find("spr_mark_3");
        child4 = GameObject.Find("Gamover");
        lives = 3;
        child4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 2)
        {
            Destroy(child3);
        }

        if (lives == 1)
        {
            Destroy(child2);
        }

        if (lives == 0)
        {
            Destroy(child1);
            child4.SetActive(true);
        }
    }
}
