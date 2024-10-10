using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Spider : MonoBehaviour {
	private NavMeshAgent agent;//给怪物添加制动巡航组件
	private Animator an;//获取新动画
	public Transform[] waypoints;//创建一个对象数组,把需要导航的位置存入进去
	private int index = 0;
	private float timer = 0;
	private float times = 3;
	private Transform player;
	public GameObject wan;
	private float attackTime=1f;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();//
		an = GetComponent<Animator>();
		agent.destination = waypoints[index].position;
		player = GameObject.FindWithTag("Player").transform;
	}
	void Update () {
		float dir = Vector3.Distance(player.position, transform.position);//获取玩家距离敌人的距离
		transform.position += an.deltaPosition;
		
		if( dir>3 && dir < 10)//追踪
		{
			Track();
			Debug.Log("walk");
			an.SetBool("idle",true);
			attackTime = 0f;
        }
		else if(dir <= 3 )//攻击
		{
			Attack();
			an.SetBool("idle",false);
        }
		else
		{
			attackTime  += Time.deltaTime;
			Patrol();
        }
	}
	void Track()
	{
		//transform.LookAt(player.position);//给定条件看向玩家   这行代码可以不用
		agent.destination = Vector3.MoveTowards(transform.position,player.position,agent.speed * Time.deltaTime);
    }
	void Attack()//攻击
	{
		
	}
	void Patrol()//自动导航
	{
        if (agent.remainingDistance < 0.5f)//在自动巡航到0.5m后进入这个判断条件
        {
            timer += Time.deltaTime;
            if (timer >= times)
            {
				an.SetBool("idle",true);
                timer = 0;
                index++;
                index %= 4;//给怪物巡逻几个点位就给几
                agent.SetDestination(waypoints[index].position);//继续网下一个位置导航
            }
        }
		else
		{
			an.SetBool("idle",true);
        }
    }
}
