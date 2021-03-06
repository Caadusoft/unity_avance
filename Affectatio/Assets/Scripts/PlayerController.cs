﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))] //Comme ça lorsqu'on met un script à un objet l'autre se place aussi

public class PlayerController : MonoBehaviour
{
    public float x { get; set; }
    private PlayerMotor motor;

    // Use this for initialization
    void Start()
    {

        motor = GetComponent<PlayerMotor>(); //récupérer un composant sur l'objet en question

    }

    // Update is called once per frame
    void Update()
    {


        x = Input.GetAxis("Horizontal"); //projet settings -> input  définis par Unity
        if (x == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            if (this.transform.GetChild(1).localPosition.x > 0)
            {
                this.transform.GetChild(1).localPosition = new Vector2(-this.transform.GetChild(1).localPosition.x, 0);
            }
        }
        else if (x == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            if (this.transform.GetChild(1).transform.localPosition.x < 0)
            {
                this.transform.GetChild(1).localPosition = new Vector2(-this.transform.GetChild(1).localPosition.x, 0);
            }
        }
        float y = Input.GetAxis("Jump");
        Vector2 _velocity = new Vector2(x, y);
        Debug.Log(_velocity);

        motor.RunAndJump(_velocity); //demande le paramètre velocity

    }
}
