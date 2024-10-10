using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//转换状态 敌人类 加载敌人巡逻路线
public class Enemy : MonoBehaviour
{
    
    private NavMeshAgent agent;
    public Animator animator;
    
    public float enemyHealth;  //敌人血量
    public Slider slider;      //敌人血条

    public GameObject [] wayPointobj;//存放敌人不同路线 NavMeshSurface
    public List<Vector3> wayPoints = new List<Vector3>();//存放巡逻点
    public int index; //数组下标

    public EnemyBaseState currentState;
    public  Vector3 targetPostion;
    public int animState;//动画状态标识，0 idle  1 run   2 attack;
    public Transform targetPoint;

    public PatrolState patrolState;//声明对象，定义敌人巡逻状态
    public AttackState attackState;//声明对象，定义敌人攻击状态 patrolState

    //敌人的攻击目标，场景中有敌人（用链表储存）； 
    public List<Transform> attackList = new List<Transform>();
    //攻击间隔
    public float attackRate;
    //下次攻击时间
    private float nextAttack = 0.5f;
    private float nextTimeCount1 = 3;

    //攻击距离
    public float attackRange = 3f;
    // Start is called before the first frame update
    public bool isDead = false;
    public GameObject obj;
    Vector3 cubePosition;
    public GameObject Slider;
private Transform player;
   
      AnimatorStateInfo stateinfo; //攻击状态 LineRenderer
     public GameObject chosenEffect;
        public float loopTimeLimit = 2.0f;
      private float hitTime = 0;

      public GameObject txwz;
    void Awake()
    {
        patrolState = transform.gameObject.AddComponent<PatrolState>();
        attackState = transform.gameObject.AddComponent<AttackState>();
    }
    void Start()
    {
        agent    = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        index = 0;
        TransitionToState(patrolState);//初始化状态：巡逻；  state
        isDead = false;
        slider.maxValue = enemyHealth;
        slider.value    = enemyHealth;
        slider.minValue = 0;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //当前状态持续执行
        //敌人移动状态持续执行
        
         stateinfo = animator.GetCurrentAnimatorStateInfo(0); //动画状态检测
        if(!isDead)
        {
            currentState.OnUpdate(this);
            animator.SetInteger("state",animState);
        }
        cubePosition = GameObject.Find("Muryotaisu").GetComponent<Transform>().position;
        setActive();
    }
    public void AttackAction()
    {
        if(Vector3.Distance(transform.position,targetPoint.position) < 1f)
        {
            if(!stateinfo.IsName("attack"))
            {
                transform.LookAt(player.position);
            }
            if(nextTimeCount1 > nextAttack)
            {
               animState = 2;
                animator.SetBool("attack",true); //spped
               nextTimeCount1 = 0;
            }
            else
            {
                animator.SetBool("attack",false);
                animState = 1;
                nextTimeCount1 += Time.deltaTime;
            }
        }
        else{
            animator.SetBool("attack",false);
        }
    }
    public void PlayMustatAttackEff()
    {

    }

    //敌人向着导航点移动
    public void MoveToTaget()
    {
         if( stateinfo.IsTag("不能动")) return;
             if(stateinfo.IsName("attack") || stateinfo.IsName("Idle2"))
            {
                agent.speed = 0;
            }
            else
            {
                agent.speed = 5f;
            }
            if(!obj.GetComponent<other>().isNav)//isNav true向着玩家移动 false向着导航点移动   state
            {
targetPostion = Vector3.MoveTowards(transform.position,wayPoints[index],agent.speed * Time.deltaTime);
            }
            else
            {
targetPostion = Vector3.MoveTowards(transform.position,cubePosition,agent.speed * Time.deltaTime);             
            }
            agent.destination = targetPostion;
    }

    //加载路线
    public void loadPath(GameObject go)
    {
        wayPoints.Clear();
        foreach (Transform T in go.transform)
        {
            wayPoints.Add(T.position);
        }
    }
    //切换敌人状态方法
    public void TransitionToState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnemyState(this);
    }
            public void PlayEffect()
        {
            StartCoroutine("EffectLoop");
        }


    public void Health(float damage)
    {
        if(isDead) return;
        enemyHealth -= damage;
        slider.value = enemyHealth;
         if(slider.value <= 0)
        {
            isDead = true;
            animator.SetTrigger("dying");//dying
        }
        animator.SetTrigger("hit");
         animator.CrossFadeInFixedTime("behit",0.4f);

    }
    int b = 0;
    public GameObject p;
          public void sisi()
          {
            Destroy(gameObject); 
          }
          public void si()
          {
          Quaternion q4 = transform.rotation;
          GameObject h4 = Instantiate(chosenEffect,txwz.transform.position,q4);
          Destroy(h4,2.0f);
          }
  
    public void setActive()
    {
        if(enemyHealth < 100 && enemyHealth > 0) 
        {
            Slider.SetActive(true);
        }
        if(enemyHealth <= 0 )
        {
            Slider.SetActive(false);
        }
    }
}
