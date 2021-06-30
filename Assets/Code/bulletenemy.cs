using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletenemy : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 20;
	public Rigidbody2D rb;
	public player pl;
	public Player2 pl2;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{
		pl = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
		
		//	transform.Rotate(0f, 180f, 0f);
		rb.velocity = transform.right * speed;
		pl2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
		
		//	transform.Rotate(0f, 180f, 0f);
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if (hitInfo.CompareTag("Player"))
		{
			//pl.Damage(1);
		}
		player pl = hitInfo.GetComponent<player>();
		if (pl != null)
		{
			pl.Damage(1);
			//pl.died(damage);
			
			Destroy(gameObject);
		}
		Player2 pl2 = hitInfo.GetComponent<Player2>();
		if (pl2 != null)
		{
			pl.Damage(2);
			//pl.died(damage);

			Destroy(gameObject);
		}

		//	Instantiate(impactEffect, transform.position, transform.rotation);
		//	Instantiate(impactEffect, transform.position, Quaternion.identity);
		Debug.Log("Va cham");

	}
}
