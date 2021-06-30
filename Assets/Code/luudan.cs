using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luudan : MonoBehaviour
{
	public Transform  canon1;

	public int damage = 40;
	
	public GameObject bulletPrefab1;
	public LineRenderer lineRenderer;
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
		if (Input.GetMouseButtonDown(1))
		{

			if (!r.flipX)
			{
				if (Input.GetAxisRaw("Vertical") == 0)
				{
					// Derecha
					Shoot(canon1);
				}
			}
			if (auclip && audio)
			{
				audio.PlayOneShot(auclip);
			}

		}

	}
	private void Shoot(Transform canon)
	{

		var b = Instantiate(bulletPrefab1, canon.position, canon.rotation).GetComponent<Rigidbody2D>();
		b.AddForce(canon.right * bulletSpeed, ForceMode2D.Impulse);
		Instantiate(bulletPrefab1, canon.position, canon.rotation);

		Destroy(b.gameObject, 1f);
	}
	//}
}
