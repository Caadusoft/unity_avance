using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationRat : MonoBehaviour
{
    public GameObject rat;
    public bool apparitionVariable;
    public GameObject activationCollider;


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "heros")
        {
            rat.SetActive(true);
            activationCollider.SetActive(false);
        }
    }

}
