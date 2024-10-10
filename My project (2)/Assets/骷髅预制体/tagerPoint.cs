using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tagerPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject taher;
    void Start()
    {
        this.transform.position = taher.transform.position;
    }
}
