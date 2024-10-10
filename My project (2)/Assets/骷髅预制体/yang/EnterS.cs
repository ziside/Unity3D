using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterS : MonoBehaviour
{
     public bool isHave = false;
     public void OnTriggerEnter(Collider collision)
     {
        if(collision.CompareTag("Player"))
        {
            isHave = true;
        }

     }
}
