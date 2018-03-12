using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{
    //objet à poursuivre
    public Transform target;

    //combien de fois par seconde nous allons update notre chemin
    public float UpdateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    //chemin défini
    public Path path;

    //vitesse de l'IA par seconde
    public float speed = 300f;
    //Pour contrôler la force de notre IA
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //la distance max de l'IA au waypoint pour qu'il recommence ensuite
    public float nextWayPointDistance = 3;

    //the waypoint we are currently moving towards
    public int currentWayPoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.LogError("No target");
            return;
        }
        //commence un nouveau chemin vers la cible et retourne le résulat à la méthode OnPathComplete
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());

    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            yield return false;
        }

        //commence un nouveau chemin vers la cible et retourne le résulat à la méthode OnPathComplete
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / UpdateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("nous sommes dans la fonction OnPathComplete. Erreur? " + p.error);
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        if (path == null)
        {
           return;
        }

        if (currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //Direction to the next point
        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //Move the AI
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);
        if (dist < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }
}
