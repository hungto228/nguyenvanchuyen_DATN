using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

	public float speed = 20f;
	public int damage = 20;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		linhAI enemy = hitInfo.GetComponent<linhAI>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			Destroy(gameObject);
		}
		tank enemy1 = hitInfo.GetComponent<tank>();
		if (enemy1 != null)
		{
			enemy1.TakeDamage(damage);
			Destroy(gameObject);
		}
		boss enemy2 = hitInfo.GetComponent<boss>();
		if (enemy2 != null)
		{
		enemy2.TakeDamage(damage);
			Destroy(gameObject);
		}

			//Instantiate(impactEffect, transform.position, transform.rotation);
			Instantiate(impactEffect, transform.position, Quaternion.identity);
		Debug.Log("Va cham");

	}

}
