using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 20;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.name == "rat_debut")
        {
            col.GetComponent<Enemy>().DamageEnemy(10);
        }

        if (col.name == "rat_fin_bas_1")
        {
            col.GetComponent<Enemy>().DamageEnemy(10);
        }

        if (col.name == "rat_fin_bas_2")
        {
            col.GetComponent<Enemy>().DamageEnemy(10);
        }

        if (col.name == "rat_fin_milieu_2")
        {
            col.GetComponent<Enemy>().DamageEnemy(10);
        }

        if (col.name == "rat_fin_milieu_1")
        {
            col.GetComponent<Enemy>().DamageEnemy(10);
        }
    }
}
