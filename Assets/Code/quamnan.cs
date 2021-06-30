using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quamnan : MonoBehaviour
{
    public int loadlv = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // if (Input.GetKey(KeyCode.E))
         //   {
                SceneManager.LoadScene(loadlv+1);
//}
        }
    } 
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
