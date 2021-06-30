using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacdichuyen : MonoBehaviour

{
    public   float speed = 0.05f, change = -1;
    Vector3 vector3;
    public Pause pausep;
    // Start is called before the first frame update
    void Start()
    {
        vector3 = this.transform.position;
        pausep = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausep.pause)
        {
            this.transform.position = this.transform.position;
           
        }
        if (pausep.pause == false)
        {
            vector3.x += speed;
            this.transform.position = vector3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("nendat"))
        {
            speed *= change;
        }
    }
}
