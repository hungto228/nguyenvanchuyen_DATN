using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float move = 1;
    public float xoay = 12;
    public float speedmoment = 5f;
    public Rigidbody2D r2;
    Vector2 moment;
    Vector2 mousepos;
    public Camera cam;
    public int ourhealth, maxhealth = 100;
    public AudioSource audio;
    public AudioClip amdan;

    private void Start()
    {
        ourhealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (audio && amdan)
        {
            audio.PlayOneShot(amdan);
            mousepos = Input.mousePosition;
        }
    }
    private void FixedUpdate()
    {
        r2.MovePosition(r2.position + moment * speedmoment * Time.fixedDeltaTime);
        float moveVector = Input.GetAxis("Vertical");
        float xoayVector = Input.GetAxis("Horizontal");
        this.transform.Translate(0f, moveVector * move * Time.deltaTime, 0f);
        this.transform.Rotate(0f, 0f, xoayVector * (xoay * 10) * Time.deltaTime);
        // Vector2 lookdir = mousepos - r2.position;
        // float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        // r2.rotation = angle;

        if (ourhealth <= 0)
        {
            _death();
        }
    }
    void _death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Damage(int damage)
    {
        ourhealth -= damage;
    }
}
