using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController wan;  //玩家
    //移动设置
    private Animator animator; //动画组件
    private Vector3 move;  //移动
    private float  speed = 0f;//速度
    public float  speed1 = 2f;//速度
    public float  speed2 = 4f;//速度
    public bool Dodge;//翻滚
    public  float TIME = 0;//翻滚加速
    public  float TIME2 = 0;//Run后摇
    public float DodgeSize = 1f;//翻滚距离


  //跳跃设置
    private float jumpF = 0f ;     //跳跃的力
    public float fallF = 30f;     //降落的力
    private CollisionFlags  collisionFlags;
    public bool isjump=true;
    public bool isGround=false;
     public bool isGroundPulas=false;
    [SerializeField] private float slopeForce = 6.0f;//走斜坡时施加的力度
    [SerializeField] private float slopeForceRayLength = 2.0f;//斜坡射线长度（自定义量）
    AnimatorStateInfo stateinfo;

    private float jumpcount=0;
    public bool akMove = false;
    float ZDtime = 3;
    void Start()
    {
        wan         = GetComponent<CharacterController>(); //获取玩家的组件
        animator    = GetComponent<Animator>();
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        stateinfo = animator.GetCurrentAnimatorStateInfo(0);
        
        if(stateinfo.IsName("Double_Jump_End 0")) 
        {
            fall();
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space)) jumpcount++;
        jump();
        float h = Input.GetAxis("Horizontal");       //x轴
        float v = Input.GetAxis("Vertical");         //y轴
        move  = new Vector3(h,0,v);
        DODGE();
        if(!stateinfo.IsTag("不能动"))
        movede();
       
    }
    void movede()
    {
       if( move != Vector3.zero && Dodge ==false)
       {
         transform.rotation = Quaternion.LookRotation( move );

         animator.SetBool("isRun",true);
          if(Input.GetKey(KeyCode.Mouse0) &&akMove)
        {
            ZDtime = 0;
        }
        if(ZDtime<=1.15f && akMove)
        {
             collisionFlags = wan.Move(move*0.01f);
             ZDtime += Time.deltaTime;
        }
         else  collisionFlags = wan.Move(move*0.04f);
         
       }
       else if(TIME2<0.2)
       {
        TIME2+=Time.deltaTime;
       }
       else
       {
         animator.SetBool("isRun",false);
         TIME2 = 0;
       }
    }
    //翻滚
    void DODGE()
    {
        speed = 15;
        speed2 = 15;
        if(Input.GetKeyDown(KeyCode.E))
       {
        // transform.rotation = Quaternion.LookRotation( move );
         animator.Play("Dodge_Front",0,0);  //播放动画
         Dodge = true;                     
         TIME = 0f;//重置
       }
       else
       {
        TIME += Time.deltaTime;//累加时间
        if(TIME >= 0.2f)
        {
            Dodge = false;speed = speed2;
        }
       }
       if(TIME > 2)
       {
        speed = speed1;
       }
       if(Dodge)
       {
        
          if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Dodge)
         {
             this.transform.Translate( -(float)Math.Sqrt(DodgeSize * 0.3f * Time.deltaTime),0,(float)Math.Sqrt(DodgeSize * 0.3f * Time.deltaTime),Space.World);
         }
          else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && Dodge)
         {
             this.transform.Translate( (float)Math.Sqrt(DodgeSize * 0.3f * Time.deltaTime),0,(float)Math.Sqrt(DodgeSize * 0.3f * Time.deltaTime),Space.World);
         }
         else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Dodge)
         {
             this.transform.Translate( (float)Math.Sqrt(DodgeSize * 0.3f * Time.deltaTime),0,-(float)Math.Sqrt(DodgeSize * 0.3f * Time.deltaTime),Space.World);
         }
         else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Dodge)
         {
             this.transform.Translate( -(float)Math.Sqrt(DodgeSize * 0.3f * Time.deltaTime),0,-(float)Math.Sqrt(DodgeSize * 0.3f * Time.deltaTime),Space.World);
         }
        else if(Input.GetKey(KeyCode.W) && Dodge)
         {
             this.transform.Translate(0,0,DodgeSize * Time.deltaTime,Space.World);
         }
        else if(Input.GetKey(KeyCode.S) && Dodge)
         {
             this.transform.Translate(0,0,-DodgeSize * Time.deltaTime,Space.World);
         }
        else if(Input.GetKey(KeyCode.A) && Dodge)
         {
             this.transform.Translate(-DodgeSize * Time.deltaTime,0,0,Space.World);
         }
        else if(Input.GetKey(KeyCode.D) && Dodge)
         {
             this.transform.Translate(DodgeSize * Time.deltaTime,0,0,Space.World);
         }
         else{
            this.transform.Translate(0,0,DodgeSize * Time.deltaTime,Space.Self);//翻滚逻辑 x y z
         }
       }
    }

       public void jump()
    {
          isjump = Input.GetKeyDown(KeyCode.Space);     //空格键 跳跃
          isGroundPulas = Input.GetKeyDown(KeyCode.Space);
          if(isjump && isGroundPulas)   //按空格 &&在地面 起跳判断
        { 
            isGroundPulas = false;
            jumpF = 10f;
            animator.Play("Jump_ALL",0,0);  //播放动画
            
        }
        else if(isGroundPulas && !isjump)
        {
            isGround = true; jumpcount=0;
            isGroundPulas = false;
        }
         fall();
         jump2();
    }
  //  [Header("解决斜坡不可跳跃 代码块")]
    public bool Onslpe()
    {
        if(isGroundPulas) return false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, wan.height / 2 * slopeForceRayLength))
        {
            if( hit.normal != Vector3.up )
            {
                return true;
            }
        }
        return false;
    }
void fall()
{
    if(!isGroundPulas || stateinfo.IsName("Double_Jump_End 0"))         //不在地面
         {
            jumpF -= fallF*Time.deltaTime;   //重力加速度
            Vector3 jump = new Vector3(0,jumpF * Time.deltaTime,0);  //矢量化
            collisionFlags = wan.Move(jump);  //赋值
          
            if(collisionFlags == CollisionFlags.Below)
            {
                isGround = true;
                isGroundPulas = true;
                jumpF = 0f;
            }
            if(isGround && collisionFlags == CollisionFlags.None)
            {
                isGround = true;
                isGroundPulas=false;
            }
         }
}
        public void jump2()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isGround && jumpcount == 2 )
        {
           animator.Play("Double_Jump",0,0);  //播放动画
            jumpF = 10;
        }
    }
    }
