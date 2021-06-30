using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrol : MonoBehaviour
{
    public float walkSpeed;
   // public float range, timeBTWShots, shootSpeed;
   // private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    //private bool canShoot;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    //public Transform player, shootPos;
    //public GameObject bullet;
    void Start()
    {
        mustPatrol = true;
    }
    // cho ty t xem lai
    void Update()
    {
        if (mustPatrol)
        {
            Patrols();
        }
        //distToPlayer = Vector2.Distance(transform.position, player.position);
        //if (distToPlayer <= range)
        //{
        //    if (player.position.x > transform.position.x && transform.localScale.x < 0
        //        || player.position.x < transform.position.x && transform.localScale.x > 0)
        //    {
        //        Flip();
        //    }
        //    mustPatrol = false;
        //    rb.velocity = Vector2.zero;
        //    if (canShoot)
        //        StartCoroutine(Shoot1());
        //}
        //else
        //{
        //    mustPatrol = true;
        //}
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrols()
    {
        if (mustTurn)
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
   
}
