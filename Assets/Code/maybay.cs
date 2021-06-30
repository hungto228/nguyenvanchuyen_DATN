using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maybay : MonoBehaviour
{
	public float minDistance;
	public Transform canon;
	public GameObject prefab;
	public float rate;
	public float bulletSpeed;
	public int lifes;
	public GameObject died;
	public int health = 100;
	Transform player;

	void Start()
	{
		player = GameObject.FindWithTag("Player").transform;
		InvokeRepeating("Shoot", rate, rate);
	}

	Vector3 diff;
	void Update()
	{
		diff = player.position - transform.position;
	//	var diffNorm = diff.normalized;
		//float rot_z = Mathf.Atan2(diffNorm.y, diffNorm.x) * Mathf.Rad2Deg;
	//	transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
	}
	void Shoot()
	{
		if (diff.magnitude <= minDistance)
		{
			var b = Instantiate(prefab, canon.position, canon.rotation).GetComponent<Rigidbody2D>();
			b.AddForce(canon.right * bulletSpeed, ForceMode2D.Impulse);
			Destroy(b.gameObject, 4f);
		}
	}
	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GameObject ef = Instantiate(died, transform.position, Quaternion.identity);
		Destroy(ef, 0.5f);
		Destroy(gameObject);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Bullet"))
		{
			Destroy(col.gameObject);
			lifes--;

			if (lifes <= 0)
			{
				Destroy(gameObject);
				Destroy(Instantiate(died, transform.position, Quaternion.identity), 1.2f);
			}
		}
	}
}
