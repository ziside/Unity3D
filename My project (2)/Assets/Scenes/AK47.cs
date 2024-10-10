using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArsenal;
public class AK47 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject attack;
    public GameObject frie;
    private void OnTriggerStay(Collider collision)
   {
    if(collision.tag == "Player")
    {
       attack.GetComponent<ATTACK>().ArmsCount = 1;
       attack.GetComponent<Move>().akMove = true;
       frie.GetComponent<PolygonFireProjectile>().frie = true;
    }
   }
}
