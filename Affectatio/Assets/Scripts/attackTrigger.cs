using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.name == "rat")
        {
            col.GetComponent<Enemy>().DamageEnemy(10);
        }

        
    }
}
