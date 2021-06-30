using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float vantoc;
    private float tocdo = 5f;
    private bool chuyenhuong = false;
    private bool huongquay = true;
    public float nhay;
    public float delaydie= 2f;
    private bool dat = true;
    private bool water = true;
    private Animator hoathoa;
    private Rigidbody2D rigidbody2D;
    public int luongmau;
    public int maxluongmau=12;
    public AudioSource audio;
    public AudioClip diedpl;
    public GameObject die;

    public GameObject pauseUI;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        hoathoa = GetComponent<Animator>();
        luongmau = maxluongmau;
    }

    // Update is called once per frame
    void Update()
    {
        hoathoa.SetFloat("tocdo", tocdo);
        hoathoa.SetBool("nendat", dat);
  
        hoathoa.SetBool("nuoc", water);
        Nhay();
       
       

    
}
   
    private void FixedUpdate()
    {
        Dichuyen();
        if (luongmau <= 0)
        {

            died();
        }
    
    }

  

  public void Dichuyen()
    {
      
        float phaitrai = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(vantoc * phaitrai, rigidbody2D.velocity.y);
        tocdo = Mathf.Abs(vantoc * phaitrai);
        float d = Input.GetAxis("Vertical");
        if (phaitrai > 0 && !huongquay) Huongquay();
        if (phaitrai < 0 && huongquay) Huongquay();
        
    }
    void Huongquay()
    {
        huongquay = !huongquay;
        transform.Rotate(0f, 180f, 0f);
        
    }
    void Nhay()
    {

        if (Input.GetKeyDown(KeyCode.W) && dat == true)
        {
              Debug.Log("bay lên");
            if (dat)
                rigidbody2D.AddForce((Vector2.up) * nhay);
            dat = false;
        }
    }

    public void died()
    {
        // biud lai màn chơi
         if (audio && diedpl)
         {
           audio.PlayOneShot(diedpl);
           //  Destroy(Instantiate(die, transform.position, Quaternion.identity), 1.5f);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           

        }
      
      // Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 1.5f);
    }
    public void Addhp(int cuuthuong)
    {
        luongmau += cuuthuong;
    }
    public void Damage(int dame)
    {
        luongmau -= dame;
      
    }
    void OnTriggerEnter2D(Collider2D collision) { 
     if (collision.tag == "nendat")
      {
        dat = false;
       
         }

        if (collision.CompareTag("nuoc"))
        {
            water = true;
        }
        else if (collision.CompareTag("nuoc"))
        {
            if (!water)
                return;
            //   rigidbody2D.AddForce(Vector2.up * nhay, ForceMode2D.Impulse);
        }

        // water = true;

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "nendat")
          {
        dat = true;
     
          water = false;
          }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
          if (collision.tag == "nendat")
          {
        dat = false;
        
          }

          if (collision.CompareTag("nuoc"))
           {
        water = false;
        }


    }
}

