using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy1 : MonoBehaviour
{
    public Animator s;
    public GameObject lenth;
    public Slider slider; 
     public float enemyHealth;  //敌人血量
    // Start is called before the first frame update
    void Start()
    {
        s =  GetComponent<Animator>();
        enemyHealth = 100;
    }
    public void Health(float a) 
    {
          s.CrossFadeInFixedTime("pushed",0.4f);  //播放动画
          enemyHealth -= a;
          setActive();
           slider.value = enemyHealth *0.01f;
          
    }
    public void setActive()
    {
        if(enemyHealth < 100 && enemyHealth > 0) 
        {
            lenth.SetActive(true);
            s.SetBool("over",false);
        }
        else if (enemyHealth <= 0 )
        {
           lenth.SetActive(false);
           s.SetBool("over",true);
           enemyHealth = 100;
        }
    }
}
