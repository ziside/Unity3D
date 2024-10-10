using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 cubePosition ;
    public AnimatorStateInfo stateinfo;
     private Animator animator;
    void Start()
    {
        cubePosition = this.transform.position;
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 获取名为“Cube”的物体的位置坐标
        stateinfo = animator.GetCurrentAnimatorStateInfo(0);
        if(!stateinfo.IsName("Double_Jump_End 0"))
        {
            cubePosition = GameObject.Find("Muryotaisu").GetComponent<Transform>().position;
            this.transform.position = cubePosition;
        }
       
    

    }
}
