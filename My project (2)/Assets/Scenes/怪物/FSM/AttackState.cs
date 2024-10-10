using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//敌人进入攻击状态
public class AttackState : EnemyBaseState
{
    
     public override void EnemyState(Enemy enemy) //attackList
    { 
        enemy.animState = 2;
        enemy.targetPoint = enemy.attackList[0];

    }
    public override void OnUpdate(Enemy enemy)
    {
        //当前没有敌人目标，切回巡逻状态
        if(!enemy.obj.GetComponent<other>().isNav)
        {
            enemy.TransitionToState(enemy.patrolState);
        }
        if(enemy.attackList.Count > 5)
        {
            for(int i=0;i<enemy.attackList.Count;i++)
            {
                if(Mathf.Abs(enemy.transform.position.x - enemy.attackList[i].position.x) <
                   Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x)   )
                {
                    enemy.targetPoint = enemy.attackList[i];
                }
            }
        }

        if(enemy.attackList.Count == 1)
        {
            enemy.targetPoint = enemy.attackList[0];
        }

        if(enemy.targetPoint.tag == "Player" && Vector3.Distance(enemy.transform.position,enemy.targetPoint.position) <= 1f)
        {
            enemy.AttackAction();
        }
       
        enemy.MoveToTaget();
    }
}
