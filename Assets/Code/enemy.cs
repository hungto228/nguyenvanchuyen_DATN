using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float walk, khoangcach, timeBTWShots, shoot;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    private bool chuyenhuong, canShoot;

    public Rigidbody2D rb;
    public Transform check;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player, shootPos;
    public GameObject bullet;
    private Animator hoathoa;

    void Start()
    {
        mustPatrol = true;
        canShoot = true;
        hoathoa = gameObject.GetComponent<Animator>();
        //  
    }

    void Update()
    {
        hoathoa.SetBool("move", mustPatrol);
        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer <= khoangcach)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;

            if (canShoot)
                StartCoroutine(Shoot());
        }
        else
        {
            mustPatrol = true;
        }
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            chuyenhuong = !Physics2D.OverlapCircle(check.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (chuyenhuong || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        rb.velocity = new Vector2(walk * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walk *= -1;
        mustPatrol = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shoot * walk * Time.fixedDeltaTime, 0f);
        Debug.Log("Shoot");
 
        canShoot = true;

    }

}
