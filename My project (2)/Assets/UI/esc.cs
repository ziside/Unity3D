using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class esc : MonoBehaviour
{
    public GameObject escList;
    bool key = true;
    [SerializeField] AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        ESCfun();
    }
    void ESCfun()
    {
        if(key == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
               escList.SetActive(true);
               key = false;
               Time.timeScale = (0);
               bgm.Pause();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
               escList.SetActive(false);
               key = true;
               Time.timeScale = (1);
               bgm.Play();
            }
        }
    }
    public void Return()
    {
         escList.SetActive(false);
         key = true;
         Time.timeScale = (1);
         bgm.Play();
    }
    public void Restart()
    {
         SceneManager.LoadScene(0);
         Time.timeScale = (1);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }
}
