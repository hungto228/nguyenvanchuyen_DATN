using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletene : MonoBehaviour
{
	GameObject target;
	public float speed = 20f;
	public int damage = 20;
	public Rigidbody2D rb;
	public Player2 pl2;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//	target = GameObject.FindGameObjectWithTag("Player");
		pl2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
		Vector2 moveDir = (pl2.transform.position - transform.position).normalized * (speed + 2);
		rb.velocity = new Vector2(moveDir.x, moveDir.y);
		Destroy(this.gameObject, 2);
	}
	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		
		Player2 pl2 = hitInfo.GetComponent<Player2>();
		if (pl2 != null)
		{
			pl2.Damage(3);
			

			Destroy(gameObject);
		}

		//	Instantiate(impactEffect, transform.position, transform.rotation);
		//	Instantiate(impactEffect, transform.position, Quaternion.identity);
		Debug.Log("Va cham");

	}
}