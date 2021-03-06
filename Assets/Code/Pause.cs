using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

    }

   public void resume()
    {
        pause = false;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Map()
    {
        pause = !pause;
        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void quit()
    {
        Application.LoadLevel("Chonmap");
    }
   
}