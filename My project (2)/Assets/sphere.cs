using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    Vector3 end;
    Vector3 look;
    float ZDtime = 3f;
    public GameObject wan;
    // Start is called before the first frame update
    void Start()
    {
        end  = new Vector3(0,0,0);
        look = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            LOOKROTATION();
            ZDtime = 0;
        }
        if(ZDtime<=3f)
        {
             LOOKROTATION();
             ZDtime += Time.deltaTime;
        }
        
    }
     void LOOKROTATION()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
             
           
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                look = hit.point;
                look.y=0;
            }
            look.y = wan.transform.position.y+0.5f;
           transform.rotation = Quaternion.LookRotation( look );
           transform.position = look;
    }
}
