using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArsenal;
public class jiguang : MonoBehaviour
{
    public GameObject attack;
     public GameObject frie;
    private void OnTriggerStay(Collider collision)
   {
    if(collision.tag == "Player")
    {
        attack.GetComponent<ATTACK>().ArmsCount = 2;
        frie.GetComponent<PolygonFireProjectile>().frie = false;
    }
   }
}
