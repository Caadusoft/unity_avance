using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationFlute : MonoBehaviour {

    public GameObject activationCollider2;
    public Image confusionImage;
    public float camShakeAmt = 0.1f;
    CameraShake camShake;

    //public Animator ani;

    void Start()
    {
        camShake = GameMaster.gm.GetComponent<CameraShake>();
        confusionImage.enabled = false;
        if (camShake == null)
        {
            Debug.Log("Le script cameraShake n'a pas été trouvé");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "heros")
        {
            //ani.SetBool("Booleen1", true);
            camShake.Shake(camShakeAmt, 0.2f);
            activationCollider2.SetActive(false);
            confusionImage.enabled = true;
        }
    }
}
