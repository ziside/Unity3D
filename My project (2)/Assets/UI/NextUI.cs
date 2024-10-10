using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextUI : MonoBehaviour
{
    public GameObject next;
    void OnTriggerEnter(Collider collision)
{ Debug.Log("Sa");
    next.SetActive(true);
}
    void OnTriggerExit(Collider collision)
{
    Debug.Log("Ss");
    next.SetActive(false);
}
private void OnTriggerStay(Collider collision)
{
    
    if(Input.GetKeyDown(KeyCode.F))
    {
      AsyncOperation op = SceneManager.LoadSceneAsync( SceneManager.GetActiveScene().buildIndex+1);
    }
}
}
