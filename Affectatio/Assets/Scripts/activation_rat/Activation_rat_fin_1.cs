using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation_rat_fin_1 : MonoBehaviour
{
    public GameObject rat1;
    public bool apparitionVariable;
    public GameObject activationCollider;


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "heros")
        {
            rat1.SetActive(true);
            activationCollider.SetActive(false);
        }
    }
}
