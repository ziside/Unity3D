using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.AI;
public class YC : MonoBehaviour  
{  
    public enum State  //声明状态枚举
    {  
        Idle,  
        Walking,
        Attack
    }  
  
    private State currentState;  //当前状态变量
    Vector3 cubePosition;
    private  Vector3 targetPostion;
    private NavMeshAgent agent;
    public  Animator animator;
    float IdleTime = 2;
    public GameObject [] way;

    private float size = 50;
    public GameObject test2;
    private void Start()  
    {  
        // 初始化当前状态为 Idle  
        currentState = State.Walking;  
        animator = GetComponent<Animator>(); 
        agent    = GetComponent<NavMeshAgent>();
    }  
    public void Health(float damage)
    {
         size -= damage;
         Debug.Log("DSADAS");
         if(size <= 0)
         {
            Vector3 p = this.transform.position;
            p.y = this.transform.position.y+0.3f;
             GameObject h = Instantiate(test2,p,this.transform.rotation);
             Destroy(gameObject); 
         }
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
            case State.Attack:  
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
     public void TransitionToAttack()  
    {  
        currentState = State.Attack;  
    }  
  
    // 状态行为实现  
    float time = 0;
    private void Idle()  
    {  
      if(time <IdleTime)
      {
        time += Time.deltaTime;
         animator.SetBool("run",false);
        return;
      }
      else
      {
        time = 0;
        TransitionToWalking();
      }
      
    }  
  float time2 = 0f;
  int i = 0;
    private void Walking()  
    {  
         animator.SetBool("run",true);
         agent.speed = 15f;
        if(Vector3.Distance(transform.position,cubePosition) >= 5f)
        {   
            targetPostion = Vector3.MoveTowards(transform.position,cubePosition,agent.speed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position,cubePosition) < 5f)
        {
          targetPostion = Vector3.MoveTowards(transform.position,way[i].transform.position,20 * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position,way[i].transform.position)<= 1.5f)
        {
           i = Random.Range(0,way.Length);
        }
   if(Vector3.Distance(transform.position,cubePosition) < 5.5f && Vector3.Distance(transform.position,cubePosition)>4.5f )
      TransitionToIdel() ;
        agent.destination = targetPostion;
      
    }
public GameObject obj;
public void F()
{
    Vector3 playerPosition = cubePosition;
    Vector3 m = this.transform.position; 
    m.y += 0.4f;      
    GameObject projectile = Instantiate(obj,m,Quaternion.identity);
    projectile.GetComponent<Rigidbody>().AddForce((playerPosition - m).normalized * 2000);
}
}
