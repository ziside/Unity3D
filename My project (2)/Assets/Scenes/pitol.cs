using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArsenal;
public class pitol : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject attack;
     public GameObject frie;
     public int count;
    private void OnTriggerStay(Collider collision)
   {
    if(collision.tag == "Player")
    {
        frie.GetComponent<PolygonFireProjectile>().frie = true;
        frie.GetComponent<PolygonFireProjectile>(). AimSpeed = 0.1f;
       attack.GetComponent<ATTACK>().ArmsCount = count;
       attack.GetComponent<Move>().akMove = true;
    }
   }
}
