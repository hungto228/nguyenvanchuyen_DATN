using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vacham : MonoBehaviour
{
    public player pl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger== false)
        {
            if (collision.CompareTag("Player"))
            {
                collision.SendMessageUpwards("Damage", 12);
            }
        }
    }
}
