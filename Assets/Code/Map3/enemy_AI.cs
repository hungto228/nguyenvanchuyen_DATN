using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_AI : MonoBehaviour
{
    public float speed=5f;
    public float lineofsite;
    public Transform player;
    private Vector2 movement;
    public float shootting,fire=2f,nextfire;
    public GameObject bullet_enemy;
    public GameObject bullet_enemy_parent;
    private Rigidbody2D rb;
    public int heath = 100;
    public GameObject death;
    public Animation anim;
    public AudioSource audio;
    public AudioClip diedpl, amdan;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        rb = this.GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        var diffNorm = direction.normalized;
        float angle = Mathf.Atan2(diffNorm.y, diffNorm.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f;
        diffNorm.Normalize();
        movement = diffNorm;
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceFromPlayer < lineofsite && distanceFromPlayer > shootting)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootting && nextfire < Time.time)
        {
            Instantiate(bullet_enemy, bullet_enemy_parent.transform.position, Quaternion.identity);
            nextfire = Time.time + fire;
        }
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
        Gizmos.DrawWireSphere(transform.position, shootting);
    }

    public void TakeDamage(int Damage)
    {
        heath -= Damage;

        if (heath <= 0)
        {
            _die();
        }
    }

    void _die()
    {
        if (audio && diedpl)
        {
            audio.PlayOneShot(diedpl);
        }
            Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
