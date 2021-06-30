using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankshot1 : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 20;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		
		
		//	Instantiate(impactEffect, transform.position, transform.rotation);
		//	Instantiate(impactEffect, transform.position, Quaternion.identity);
		Debug.Log("Va cham");

	}
}
