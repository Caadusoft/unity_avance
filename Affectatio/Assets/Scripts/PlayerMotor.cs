using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))] //Comme ça lorsqu'on met un script à un objet l'autre se place aussi

public class PlayerMotor : MonoBehaviour {

    private Vector2 velocity;
    private Rigidbody2D rb;
    //Serialize permet de modifier les valeurs dans l'inspecteur
    [SerializeField]  private float maxSpeed;
    [SerializeField] private float maxSpeedJump;
    [SerializeField] private float radiusCircle;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask layer;
    public bool canMove;

    private bool grounded;

    public bool Grounded { get { return grounded; } }

    void Start ()
    {
        velocity = Vector2.zero; //Met des zéros en X et en Y	
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void FixedUpdate ()
    {
        if (!canMove)
        {
            return;
        }

        PerformRunAndJump();

	}

    public void RunAndJump(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    private void PerformRunAndJump()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.transform.position, radiusCircle, layer); //verification si on est sur le sol
        if (grounded)  //si je suis bien sur le sol
        {
            rb.AddForce(new Vector2(0f, velocity.y) * Time.deltaTime * maxSpeedJump, ForceMode2D.Impulse);
            Debug.Log("je suis dans la fonction grounded");
        }
        rb.velocity = new Vector2(velocity.x * maxSpeed * Time.deltaTime, rb.velocity.y);
        //time.deltaTime permet de synchroniser le nombre d'images par secondes à tous les écrans
        //rb.AddForce(new Vector2(0f, velocity.y), ForceMode2D.Impulse);
        //si on applique seulement la ligne au-dessus on pourra sauter même en l'air
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.transform.position, radiusCircle);
    }
}
