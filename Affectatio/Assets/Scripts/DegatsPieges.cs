using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatsPieges : MonoBehaviour {

    public int dmg = 20;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "heros")
        {
            other.GetComponent<Player1>().takedmg(10);
        }
    }
}
