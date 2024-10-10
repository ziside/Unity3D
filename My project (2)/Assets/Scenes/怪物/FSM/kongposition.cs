using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kongposi : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 kong ;
    void Start()
    {
        Application.targetFrameRate = 300;
        kong = this.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 获取名为“Cube”的物体的位置坐标
    kong= GameObject.Find("疫医").GetComponent<Transform>().position;
    this.transform.position = kong;

    }
}
