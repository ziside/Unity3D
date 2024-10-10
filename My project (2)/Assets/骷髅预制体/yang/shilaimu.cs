using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.AI;
public class shilaimu : MonoBehaviour  
{  
    public enum State  //声明状态枚举
    {  
        Idle,  
        Walking
    }  
  
    private State currentState;  //当前状态变量
    Vector3 cubePosition;
    public  Vector3 targetPostion;
    private NavMeshAgent agent;
    public  Animator animator;
    public float len;
    float IdleTime = 1;
    private void Start()  
    {  
        // 初始化当前状态为 Idle  
        currentState = State.Walking;  
        animator = GetComponent<Animator>(); 
        agent    = GetComponent<NavMeshAgent>();
    }  
  
    private void Update()  
    {  
        // 根据当前状态执行相应的行为  
        cubePosition = GameObject.Find("Muryotaisu").GetComponent<Transform>().position;
        switch (currentState)  
        {  
            case State.Idle:  
                Idle();  
                break;  
            case State.Walking:  
                Walking();  
                break;
            default:  
                Debug.LogError("Invalid state");  
                break;  
        }  
        
    }  
  
    // 状态转换函数  
    public void TransitionToWalking()  
    {  
        currentState = State.Walking;  
    }  
     public void TransitionToIdel()  
    {  
        currentState = State.Idle;  
    }  
  
    // 状态行为实现  
    float time = 0;
    private void Idle()  
    {  
      if(time <IdleTime)
      {
        time += Time.deltaTime;
        return;
      }
      time = 0;
      TransitionToWalking();
    }  
  
    private void Walking()  
    {   agent.speed = 15f;
        targetPostion = Vector3.MoveTowards(transform.position,cubePosition,agent.speed * Time.deltaTime);
        agent.destination = targetPostion;
        // 添加步行行为实现或其他操作
        animator.SetBool("run",true);
    }
}