using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class other : MonoBehaviour
{
    public bool isNav;
    public GameObject guaiwu;
    private void OnTriggerEnter(Collider other)
    {
        if(!guaiwu.GetComponent<Enemy>().isDead && other.CompareTag("Player"))
        {
           isNav = true;
            guaiwu.GetComponent<Enemy>().attackList.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
         if(!guaiwu.GetComponent<Enemy>().isDead && other.CompareTag("Player"))
        {
         isNav = false;
        }
    }
    
}
