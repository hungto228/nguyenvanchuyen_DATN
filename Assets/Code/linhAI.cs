using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linhAI : MonoBehaviour
{
	public float minDistance;
	public Transform canon;
	public GameObject prefab;
	public float rate;
	public float bulletSpeed;
	public int lifes;
	public GameObject died,addhp;
	public int health = 100;
	Transform player;
	public AudioSource audio;
	public AudioClip deatsound;
	//public Rigidbody2D rigidbody2D;


	//public float tocdo = 5f;
	//public Transform batdau, ketthuc;
	//private bool col;
	void Start()
	{
		player = GameObject.FindWithTag("Player").transform;
		InvokeRepeating("Shoot", rate, rate);
		audio = FindObjectOfType<AudioSource>();
		//rigidbody2D = GetComponent<Rigidbody2D>();
	
	}

	Vector3 diff;
	void Update()
	{
		diff = player.position - transform.position;
		var diffNorm = diff.normalized;
		float rot_z = Mathf.Atan2(diffNorm.y, diffNorm.x) * Mathf.Rad2Deg;
		//	transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
	

	}
	void Shoot()
	{
		if (diff.magnitude <= minDistance)
		{
			
			var b = Instantiate(prefab, canon.position, canon.rotation).GetComponent<Rigidbody2D>();
			b.AddForce(canon.right * bulletSpeed, ForceMode2D.Impulse);
			b.transform.Rotate(0f, 180f, 0f);
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

		GameObject hp = Instantiate(addhp, transform.position, Quaternion.identity);
		Destroy(hp, 5f);

		GameObject ef = Instantiate(died, transform.position, Quaternion.identity);
		Destroy(ef, 0.5f);
		if (audio && deatsound)
        {
			audio.PlayOneShot(deatsound);
        }
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