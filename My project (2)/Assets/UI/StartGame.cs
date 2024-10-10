using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public GameObject load;
    public Slider slider;
    public Text text;

    public GameObject xuanxinag;
    public void StartMenu()
    {
        StartCoroutine(Loadlevel());
    }
    IEnumerator Loadlevel()
    {
        load.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync( SceneManager.GetActiveScene().buildIndex+1);
        op.allowSceneActivation = false;
        while(!op.isDone)
        {
            slider.value = op.progress;
            text.text = op.progress * 100 +"%";
            if(op.progress>=0.9f)
            {
                slider.value = 1;
                text.text = "100%";
                 op.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    public void xuan()
    {
        xuanxinag.SetActive(true);
    }
}
