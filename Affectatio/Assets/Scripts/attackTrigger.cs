using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.SendMessageUpwards("Damage", dmg);
    }
}
