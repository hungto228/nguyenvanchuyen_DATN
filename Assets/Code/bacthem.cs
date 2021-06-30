using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacthem : MonoBehaviour
{
  
    public float freq = 0.5f;
    public float amp = 4f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = posOffset;
        transform.position = new Vector3(transform.position.x, tempPos.y +
            Mathf.Sin(Time.fixedTime * Mathf.PI * freq) *
            amp, transform.position.z);
    }
}

