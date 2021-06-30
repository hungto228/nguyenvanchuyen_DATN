using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{

    //   public GameObject target;

    //void Update()
    //   {
    //       transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

    //   }
    public float smoothtimeX, smoothtimeY;
    public Vector2 velocity;
    public GameObject player;
    public Vector2 minpos, maxpos;
    public bool bound;
  void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }
void FixedUpdate()     
    {
        float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothtimeX);
        float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothtimeY);
        transform.position = new Vector3(posX,posY,transform.position.z);
        if (bound)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x,minpos.x,maxpos.x),
                Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),
                 Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
    }
}
