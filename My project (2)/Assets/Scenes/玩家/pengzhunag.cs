using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pengzhunag : MonoBehaviour
{
    Vector3 kong;
    bool  attacktime;
    void Start()
    {
        kong = this.transform.position;;
    }
    void LateUpdate()
    {
        // 获取名为“Cube”的物体的位置坐标
    kong= GameObject.Find("Jian").GetComponent<Transform>().position;
    this.transform.position = kong;
    }

   public void OnTriggerEnter(Collider collision)
   {
    if(collision.tag == "敌人")
    {
        collision.gameObject.GetComponent<Enemy>().Health(15f);
    }
    if(collision.tag == "玩偶")
    {
        collision.gameObject.GetComponent<Enemy1>().Health(15f);
    }
     if(collision.tag == "易怒小子")
    {
        collision.gameObject.GetComponent<YANG>().Health(15f);
    }
      if(collision.tag =="喷射史莱姆")
    {
        collision.gameObject.GetComponent<YC>().Health(15);
    }       
   }
}
