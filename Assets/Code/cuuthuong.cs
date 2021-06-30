using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuuthuong : MonoBehaviour
{
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            player pl = collider.GetComponent<player>();
            if (pl != null)
            {
                player.Addhp(2);
                Destroy(gameObject);
                //   player.Addhp += 2;
            }
            //Destroy(gameObject);
        }
    }
}