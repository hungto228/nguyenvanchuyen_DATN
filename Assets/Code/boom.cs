using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public player pl;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{
		pl = GameObject.FindGameObjectWithTag("nendat").GetComponent<player>();
		transform.Rotate(0f, 180f, 0f);
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if (hitInfo.CompareTag("Player"))
		{
			pl.Damage(damage);
		}
		
		if (hitInfo.CompareTag("nendat"))
		{

			Instantiate(impactEffect, transform.position, transform.rotation);
			Instantiate(impactEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

	//	Instantiate(impactEffect, transform.position, transform.rotation);
		//	Instantiate(impactEffect, transform.position, Quaternion.identity);
		//Destroy(impactEffect, 0.5f);
		Debug.Log("Va cham");

	}
}
