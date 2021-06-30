using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuongnha : MonoBehaviour
{
	public float minDistance;
	public Transform canon;
	public GameObject prefab;
	public GameObject died;
	public float bulletSpeed;
	public float rate;
	public int health = 100;
	Transform player;
	public AudioSource audio;
	public AudioClip deatsound;

	void Start()
	{

		player = GameObject.FindWithTag("Player").transform;
		
	}

	Vector3 diff;
	void Update()
	{
		
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
		if (audio && deatsound)
		{
			audio.PlayOneShot(deatsound);
		}
		Destroy(ef, 0.5f);
		Destroy(gameObject);
	}
}
