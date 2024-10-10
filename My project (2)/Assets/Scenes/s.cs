using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolygonArsenal;
public class s : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject attack;
    public GameObject frie;
    private void OnTriggerEnter(Collider collision)
   {
    if(collision.tag == "Player")
    {
        attack.GetComponent<ATTACK>().ArmsCount = 4;
        frie.GetComponent<PolygonFireProjectile>().frie = false;
        attack.GetComponent<Move>().akMove = false;
    }
   }
}
