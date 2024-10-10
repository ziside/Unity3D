using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.AI;
using UnityEngine.UI;
public class YANG : MonoBehaviour  
{  
    Vector3 cubePosition;
    public  Vector3 targetPostion;
    private NavMeshAgent agent;

    public GameObject test1;
    public GameObject test2;

    public Slider slider;
    private void Start()  
    {  
        agent    = GetComponent<NavMeshAgent>();
    }  
  Vector3 p;
    private void Update()  
    {  
        // 根据当前状态执行相应的行为  
        cubePosition = GameObject.Find("Muryotaisu").GetComponent<Transform>().position;
        Walking();
    }  
    private void Walking()  
    { 
        agent.speed = 15f;
        targetPostion = Vector3.MoveTowards(transform.position,cubePosition,agent.speed * Time.deltaTime);
        agent.destination = targetPostion;
        transform.LookAt(GameObject.Find("Muryotaisu").GetComponent<Transform>().transform);
        // 添加步行行为实现或其他操作  
        if(Vector3.Distance(this.transform.position, cubePosition)<1.5f)
        Attak();
    }
    private void Attak()  
    {  
          Quaternion q4 = transform.rotation;
          GameObject h4 = Instantiate(test1,this.transform.position,q4);
          Destroy(gameObject); 
    }
    public void Health(float damage)
    {
         slider.value -= damage*0.02f;
         if(slider.value <= 0)
         {
             Quaternion additionalRotation = Quaternion.Euler(0f, 180f, 0f);
             Quaternion q = this.transform.rotation * additionalRotation;
             GameObject h = Instantiate(test2,this.transform.position,q);
             Destroy(gameObject); 
         }
    }
}