using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float max;
    private float current;

    // Start is called before the first frame update
    void Start()
    {
        //Get power and powerMax values from Player
        playerControllerScript = GameObject.Find("spr_archer_bow").GetComponent<PlayerController>();
        max = playerControllerScript.powerMax;
    }

    // Update is called once per frame
    void Update()
    {
        //Scale bar based on current power vs maximum power
        current = playerControllerScript.power;
        transform.localScale = new Vector3((current / max), 1.0f, 1.0f);
    }
}
