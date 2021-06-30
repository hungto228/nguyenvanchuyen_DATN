using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpui : MonoBehaviour
{
    public Sprite[] hpsprite;
    public player pl;
    public Player2 pl2;
        public Image imghp;
    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        pl2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
    }

    // Update is called once per frame
    void Update()
    {
     
        imghp.sprite = hpsprite[pl.luongmau];

        //imghp.sprite = hpsprite[pl2.ourhealth];
    }
}
