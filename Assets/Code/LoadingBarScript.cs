using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBarScript : MonoBehaviour {

  //  private bool loadScene = false;
  //  public string LoadingSceneName;
  ////  public Text loadingText;
  //  public Slider sliderBar;


    
    public void startgame()
    {

        //  StartCoroutine(LoadNewScene(sceneName));
        Application.LoadLevel("Chonmap");
    }
   // Chương trình đăng quang tự chạy cùng lúc với Update() và nhận một số nguyên cho biết cảnh nào sẽ tải.
   //IEnumerator LoadNewScene(int sceneName)
   // {

   //     Bắt đầu một hoạt động không đồng bộ để tải cảnh đã được chuyển đến chương trình điều tra LoadNewScene.
   //     AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

   //     Trong khi thao tác không đồng bộ để tải cảnh mới vẫn chưa hoàn tất, hãy tiếp tục đợi cho đến khi hoàn tất.
   //     while (!async.isDone)
   //     {
   //         float progress = Mathf.Clamp01(async.progress / 0.9f);
   //         loadingText.text = progress * 100f + "%";
   //         yield return null;

   //     }

    }


