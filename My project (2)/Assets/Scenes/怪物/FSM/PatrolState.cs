using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//敌人进入巡逻状态
public class PatrolState : EnemyBaseState
{
    float RunTime = 0f;
    public override void EnemyState(Enemy enemy)
    {
        enemy.animState = 0;
        Random.seed = 0;
        enemy.index = (int)Random.value*1000%4;
        enemy.loadPath(enemy.wayPointobj[enemy.index]);
        
    }
    public override void OnUpdate(Enemy enemy)
    {
         if(!enemy.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle2"))
          {
          enemy.animState = 1;
          enemy.MoveToTaget();
          enemy.animator.SetBool("ifWalk",true);
          }
          //计算敌人和导航点的距离
          float distance = Vector3.Distance(enemy.transform.position, enemy.wayPoints[enemy.index]);
         if(distance <= 1.5f)
         {
            enemy.animator.SetBool("ifWalk",false);
            float a =  Random.value*1000;
            int b = (int)a;
            enemy.index = b%4;
         }
         if(enemy.obj.GetComponent<other>().isNav)
         {
             enemy.animator.SetBool("ifWalk",true);
            enemy.TransitionToState(enemy.attackState);
         }
    }
}
