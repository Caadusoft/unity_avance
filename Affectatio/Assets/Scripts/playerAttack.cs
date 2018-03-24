using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;
    public Collider2D attackTrigger;
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        //Pour supprimer le collider au début de la scène
        attackTrigger.enabled = false;
    }

    void Update()
    {
        Debug.Log("le code playerattack tourne");
        if (Input.GetKeyDown("f") && !attacking)
        {
            Debug.Log("si j'appuie sur f");
            attacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = false;

        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                Debug.Log("si attackTimer est superieur a 0");
            }
            else
            {
                Debug.Log("ou bien si attacktimer est inferieur a 0");
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        anim.SetBool("Attacking", attacking);
    }
}
