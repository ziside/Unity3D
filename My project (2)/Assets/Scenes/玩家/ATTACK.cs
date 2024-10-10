using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArsenal;

public class ATTACK : MonoBehaviour
{
    // Start is called before the first frame update
    //动画
    private int count = 0;
    private Animator animator;  //动画组件
    private bool left;  //按左键bool
    private float TIME3; //攻击间隔标记时间
    private float TIME = 0.2f;  //攻击间隔  akcount
    private float TimePistol = 0;

    public Transform  txwz;  //特效位置
    public AnimatorStateInfo stateinfo; //攻击状态 LineRenderer

    #region(位移攻击标记时间)
    float TIMESkill=0;   //4a
    float TIMESkill1 = 0;//1a
    float TIMESkill2 = 0;//2a
    float TIMESkill3 = 0;//3a
    #endregion
 
    #region(攻击特效)
    public GameObject daoguang01;  //普通1特效
    public GameObject daoguang02;  //普通2特效
    public GameObject daoguang03;  //普通3特效
    #endregion
   
    #region(大剑普工位移)
    private float aklength = 35;
    public float  akcount1 = 35;
    public float  akcount2 = 35;
    public float  akcount3 = 35;
    public float  akcount4 = 35;
    #endregion

    public Camera MainCamera;  //摄像机组件
    public Vector3 qypublic;
    public float xJD;
    public float zJD;
    private int daoguang=0;
    public float txTime= 0.3f;

     public GameObject []Have;
     public GameObject HaveAK47;


     public GameObject HaveLaserModel;
     public GameObject HavePistolModel;
     
     public GameObject Left;
     public GameObject Right;
     public GameObject move;

    public Transform  sjwz;
    private float raytime = 0;
    public int ArmsCount = 0;

    bool looktrue;
    Vector3 end;
    Vector3 look;

    float ZDtime = 3;

    public GameObject uzi1;
    public GameObject uzi2;
    
    void Start()
    {
        animator = GetComponent<Animator>();  // 获取动画组件
          animator.SetBool("Fire",false);
    }

    // Update is called once per frame
    void Update()
    {
        
        stateinfo = animator.GetCurrentAnimatorStateInfo(0); //动画状态检测
        left = Input.GetMouseButton(0);   //左键点击
        UpdateAK47();   //ArmsAttack = 1
        UpdateDajian();
        UpdateLaser();
        Qiang();

   	}
    void  UpdateAK47()//Health
    {
        if(ArmsCount != 1)
        {
            return;
        }
        setMove();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 s = sjwz.forward;//zidan
        HavePistolModel.transform.localPosition = new Vector3(-0.484f,0.908f,0.548f);
        HavePistolModel.GetComponent<PolygonFireProjectile>().zidan = 0;
         if(Input.GetKey(KeyCode.Mouse0))
         {
            LOOKROTATION();
            HavePistolModel.SetActive(true);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 45, 0));
            if(count == 0){ sjwz.rotation = Quaternion.Euler(sjwz.rotation.eulerAngles + new Vector3(0, -45,0 ));count++;}
            animator.SetBool("AkFire",true);
              if(stateinfo.IsName("AKfire"))
            {
                 HavePistolModel.SetActive(true);
                 HaveAK47.SetActive(true);
                 if(raytime > 0.001f)
                 {
                    Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
                    RayTest(5f);
                    raytime = 0;
                 }
                 else{
                    raytime += Time.deltaTime;
                 }
            }
            else
            {
              
            }
         }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
             animator.SetBool("AkFire",false);
        }
    }
    void Qiang()
    {
        if(ArmsCount == 3)  UpdatePistol(1,0);
        if(ArmsCount == 6)  UpdatePistol(0,3);
        if(ArmsCount == 7)  UpdatePistol(2,4);
        if(ArmsCount == 8)  UpdatePistol(13,5);
    }
    void UpdatePistol(int ZiDan , int HavaIndex)
    {
        HavePistolModel.transform.localPosition = new Vector3(0.07f,1.051f,0.694f);
        HavePistolModel.GetComponent<PolygonFireProjectile>().zidan = ZiDan;
        Left.transform.localPosition = new Vector3(0.028f,-0.08f,0.016f);
        Right.transform.localPosition= new Vector3(-0.065f,-0.028f,0.022f);
        setMove();
        if(Input.GetKey(KeyCode.Mouse0) &&move.GetComponent<Move>().isGround) // 点击鼠标 在地面
        {
        
         animator.SetBool("Fire",true); //激活
         uzi1.SetActive(true);
         uzi2.SetActive(true);
         ZDtime = 0f;
        }
        else{
            uzi1.SetActive(false);
            uzi2.SetActive(false);
        }
        if(ZDtime <=1.15f)
        {
            LOOKROTATION();     //扭头缓冲
            animator.SetBool("AimRun",true);
            ZDtime+= Time.deltaTime;
            Have[HavaIndex].SetActive(true);
        }
        else{
            animator.SetBool("AimRun",false);
            Have[HavaIndex].SetActive(false);
            
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKey(KeyCode.E) || !move.GetComponent<Move>().isGround )
        {
         
            animator.SetBool("Fire",false);
        }


    }
    void setMove()
    {
         if(look.z>=0)
         {
         if(Input.GetKey(KeyCode.W))
         {
            animator.SetFloat("y",3.37f);
         }
         else if(Input.GetKey(KeyCode.S))
         {
            animator.SetFloat("y",-3.37f);
         }
         else{
            animator.SetFloat("y",0);
         }
         if(Input.GetKey(KeyCode.D))
         {
            animator.SetFloat("x",3.37f);
         }
         else if(Input.GetKey(KeyCode.A))
         {
            animator.SetFloat("x",-3.37f);
         }
          else{
            animator.SetFloat("x",0);
         }
        }
        else{
        if(Input.GetKey(KeyCode.S))
         {
            animator.SetFloat("y",3.37f);
         }
         else if(Input.GetKey(KeyCode.W))
         {
            animator.SetFloat("y",-3.37f);
         }
          else{
            animator.SetFloat("y",0);
         }
         if(Input.GetKey(KeyCode.A))
         {
            animator.SetFloat("x",3.37f);
         }
         else if(Input.GetKey(KeyCode.D))
         {
            animator.SetFloat("x",-3.37f);
         }
          else{
            animator.SetFloat("x",0);
         }

        }
    }
    void UpdateDajian()
    {
        if(ArmsCount != 4)
        {
            return;
        }
         if(Input.GetMouseButton(0) && looktrue)
        {
             LOOKROTATION();  //点击扭头
        }
        attackALL();   //攻击函数
        #region  (移动函数)
        attackfunALL();   //4a移动函数
        attackfunALL1();  //1a移动函数
        attackfunALL2();  //2a移动函数
        attackfunALL3();  //3a移动函数
        #endregion
        if(stateinfo.IsName("Attack_3Combo_1") || stateinfo.IsName("Attack_3Combo_2") || stateinfo.IsName("Attack_3Combo_3") || stateinfo.IsName("Skill_A"))
        { 
            Have[1].SetActive(true);
        }
        else
        {
           Have[1].SetActive(false);
        }
    }
    public void lookt()
    {
        looktrue = true;
    }
    public void lookf()
    {
        looktrue = false;
    }
    void RayTest(float a)
    {
       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 s = sjwz.forward;
             if(Physics.Raycast(sjwz.position,s,out hit,100))
           {
              if(hit.transform.gameObject.transform.tag == "敌人" )
             {
               hit.transform.gameObject.GetComponent<Enemy>().Health(a);
             }
             if(hit.transform.gameObject.transform.tag == "玩偶")
             {
                hit.transform.gameObject.GetComponent<Enemy1>().Health(a);
             }
             if(hit.transform.gameObject.transform.tag == "易怒小子")
             {
                hit.transform.gameObject.GetComponent<YANG>().Health(a);
             }
              if(hit.transform.gameObject.transform.tag == "喷射史莱姆")
             {
                hit.transform.gameObject.GetComponent<YC>().Health(a);
             }
             Debug.Log(hit.transform.gameObject.transform.tag);
           }
    }
    void UpdateLaser()
    {
      if( move.GetComponent<Move>().isjump) return;   
        if(ArmsCount == 2)
        {
        Have[2].SetActive(true); 
        if(Input.GetMouseButton(0))
        {
            HaveLaserModel.SetActive(true);
            LOOKROTATION();  //点击扭头
            animator.SetBool("Take",true);
            RayTest(0.5f);
        }
        else
        {
             animator.SetBool("Take",false);
             HaveLaserModel.SetActive(false);
        }
        }
        else
        {
           
         Have[2].SetActive(false);
        }
    }
    void attackALL()
    {
         if(left)
         {
             qypublic = transform.rotation.ToEulerAngles();//四元数转欧拉角
             animator.SetBool("Attack",true);
         }
         else
         {
            animator.SetBool("Attack",false);
            daoguang = 0;
         }
    }
    void LOOKROTATION()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
             end  = new Vector3(0,0,0);
             look = new Vector3(0,0,0);
           
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                look = hit.point;
                look.y=0;
                
                end = transform.position;
                end.y = 0;
                look = look - end;
            }
            transform.rotation = Quaternion.LookRotation( look );
    }
    #region(普攻位移)
    void attackfunALL()
    {
         if(stateinfo.IsName("Skill_A") && TIMESkill < 0.3f)  //0.3移动速度
        {
            if(akcount4<=10) akcount4 = 10;
            aklength = akcount4;
        this.transform.Translate(0,0,aklength * Time.deltaTime,Space.Self);//移动函数
        TIMESkill += Time.deltaTime;  //累计时间
        }
        else if(!stateinfo.IsName("Skill_A"))
        {
            TIMESkill = 0;
        }
    }
        void attackfunALL1()
    {
       
         if(stateinfo.IsName("Attack_3Combo_1") && TIMESkill1 < 0.1f)  //0.3移动速度
        {
        aklength = akcount1;
        this.transform.Translate(0,0,aklength * Time.deltaTime,Space.Self);//移动函数
        TIMESkill1 += Time.deltaTime;  //累计时间
        }
        else if(!stateinfo.IsName("Attack_3Combo_1"))
        {
            TIMESkill1 = 0;
        }
    }
    void attackfunALL2()
    {
         if(stateinfo.IsName("Attack_3Combo_2") && TIMESkill2 < 0.1f)  //0.3移动速度
        {
            aklength = akcount2;
        this.transform.Translate(0,0,aklength* Time.deltaTime,Space.Self);//移动函数
        TIMESkill2 += Time.deltaTime;  //累计时间
        }
        else if(!stateinfo.IsName("Attack_3Combo_2"))
        {
            TIMESkill2 = 0;
        }
    }
    void attackfunALL3()
    {
         if(stateinfo.IsName("Attack_3Combo_3") && TIMESkill3 < 0.1f)  //0.3移动速度
        {
        aklength = akcount3;
        this.transform.Translate(0,0,aklength * Time.deltaTime,Space.Self);//移动函数
        TIMESkill3 += Time.deltaTime;  //累计时间
        }
        else if(!stateinfo.IsName("Attack_3Combo_3"))
        {
            TIMESkill3 = 0;
        }
    }
#endregion
    #region (武器特效)
             void daoguangALL(int a)  //动画时间 特效
    {
        Vector3 la = transform.position;
        Quaternion q = transform.rotation;
        q = Quaternion.Euler(90,qypublic.y * Mathf.Rad2Deg,0);
        GameObject h = Instantiate(daoguang01,txwz.position,q);
         Destroy(h,txTime);
    }
        void daoguang2ALL(int a)  //动画时间 特效
    {
        Vector3 la2 = transform.position;
        Quaternion q2 = transform.rotation;
        q2 = Quaternion.Euler(90,qypublic.y * Mathf.Rad2Deg,0);
        GameObject h2 = Instantiate(daoguang01,txwz.position,q2);
        Destroy(h2,txTime);
    }
         void daoguang3ALL(int a)  //动画时间 特效
    {
        Vector3 la3 = transform.position;
        Quaternion q3 = transform.rotation;
        q3 = Quaternion.Euler(xJD,qypublic.y * Mathf.Rad2Deg,zJD);
        GameObject h3 = Instantiate(daoguang02,txwz.position,q3);
        Destroy(h3,txTime);
    }
         void daoguang4ALL(int a)  //动画时间 特效
    {
        Vector3 la4 = transform.position;
        Quaternion q4 = transform.rotation;
        q4 = Quaternion.Euler(xJD,qypublic.y * Mathf.Rad2Deg,zJD);
        GameObject h4 = Instantiate(daoguang03,txwz.position,q4);
        Destroy(h4,txTime);
    }
    #endregion //Debug
}
