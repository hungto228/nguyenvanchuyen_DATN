using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootting : MonoBehaviour
{
	public Transform canon0;

	public int damage = 40;
	public GameObject bulletPrefab;

	
	public float bulletSpeed;
	//public Transform firePoint;
	public AudioSource audio;
	public AudioClip auclip;
	SpriteRenderer r;
	void Start()
	{
		r = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			
			if (!r.flipX)
			{
			//	if (Input.GetAxisRaw("Vertical") == 0)
			//	{
					// Derecha
					Shoot(canon0);
			//	}
			}
			if(auclip && audio)
            {
				audio.PlayOneShot(auclip);
            }

		}
		
	}
	private void Shoot(Transform canon)
	{

		var b = Instantiate(bulletPrefab, canon.position, canon.rotation).GetComponent<Rigidbody2D>();
		b.AddForce(canon.right * bulletSpeed, ForceMode2D.Impulse);
		Instantiate(bulletPrefab, canon.position, canon.rotation);

		Destroy(b.gameObject, 1f);
	}
	//}
}
