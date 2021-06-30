using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{

    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pause = !pause;
    
        if (pause)
        {
         
            Time.timeScale = 0;
        }
        if (pause == false)
        {
         
            Time.timeScale = 1;
        }
    }
}
