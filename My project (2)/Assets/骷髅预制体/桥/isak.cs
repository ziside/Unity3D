using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isak : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scq;
     private Animator animator;  //动画组件
    void Start()
    {
        animator = GetComponent<Animator>();  // 获取动画组件
    }

    // Update is called once per frame
    void Update()
    {
        if(scq.GetComponent<newguaiwu>().isAK)
        {
            animator.SetBool("ak",true);
        }
        else{
            animator.SetBool("ak",false);
        }
        Debug.Log(scq.GetComponent<newguaiwu>().isAK);
    }
}
