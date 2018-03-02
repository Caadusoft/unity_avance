using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player: PlayerStat {
    //on change la méthode monobehaviour afin d'avoir accès aux variables

        public bool PlayerIsDead { get { return PV <= 0f; } }

    //Action est une version générique des delegates
    public event Action MonEvent;

    [SerializeField] private Transform Player;
	
	void Start ()
    {
        
	}
	
	
	void Update ()
    {

        PlayerTombe();

        if (MonEvent != null && PlayerIsDead)
        {
            MonEvent();
        }

	}

    public void PlayerTombe()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.y <= 0.0f)
        {
            RecevoirDegat(Mathf.Infinity);
            //Si on tombe, on lui inflige une infinité de degats
        }
    }

    public void RecevoirDegat(float degat)
    {
        PV -= degat;
    }
}
