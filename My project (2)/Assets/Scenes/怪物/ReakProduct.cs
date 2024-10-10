using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReakProduct : MonoBehaviour
{
    public GameObject Reak;
    public Transform[] ArrReak;
    // Start is called before the first frame update
    void Start()
    {
     //  Product();
        Instantiate(Reak,ArrReak[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Product()
    {
       /* int n = Random.Range(0,ArrReak.Length);
        for(int i = 0; i<n ;i++)
        {
           
        }*/
    }
}
