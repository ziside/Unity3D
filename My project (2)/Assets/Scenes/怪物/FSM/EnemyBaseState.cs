using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//抽象方法
public abstract class EnemyBaseState : MonoBehaviour
{
    public abstract void EnemyState(Enemy enemy);

    public abstract void OnUpdate(Enemy enemy);

}
