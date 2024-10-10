using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace PolygonArsenal
{
    public class PolygonFireProjectile : MonoBehaviour
    {
        RaycastHit hit;
        public GameObject[] projectiles;
        public Transform spawnPosition;
        [HideInInspector]
        public int currentProjectile = 0;
        public float speed = 1000;
        private float TimeGun = 0.1f;
        public int zidan = 2;
        public float AimSpeed = 0.1f;
        Vector3 P; 
        public Transform  sjwz;
        public bool frie;

        
        void Start()
        {
        }

        void Update()
        {
            if(!frie)    return;
            if(TimeGun >= AimSpeed || Input.GetKeyDown(KeyCode.Mouse0))
            {
                zidan = zidan % 83;
                UpdateGun();
                TimeGun = 0;
            }
            else
            {
                 TimeGun += Time.deltaTime;
            }
        }
    void RayTest(float a)
    {
       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 s = sjwz.forward;
             if(Physics.Raycast(sjwz.position,s,out hit,100))
           {
              if(hit.transform.gameObject.transform.tag == "敌人")
             {
               hit.transform.gameObject.GetComponent<Enemy>().Health(a);
               
             }
              if(hit.transform.gameObject.transform.tag == "玩偶")
             {
                hit.transform.gameObject.GetComponent<Enemy1>().Health(a);
             }
             if(hit.transform.gameObject.transform.tag == "易怒小子")
             {
                hit.transform.gameObject.GetComponent<YANG>().Health(a);
             }
              if(hit.transform.gameObject.transform.tag == "喷射史莱姆")
             {
                hit.transform.gameObject.GetComponent<YC>().Health(a);
             }
           }
    }
        void UpdateGun()
        {
             speed = 3000;
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0))
            {

                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
                    {
                        GameObject projectile = Instantiate(projectiles[currentProjectile+zidan], spawnPosition.position, Quaternion.identity) as GameObject;
                        P = hit.point;
                        P.y = spawnPosition.position.y;
                        projectile.transform.LookAt(P);
                        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
                        RayTest(30);
                    }
                }
            }
            Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100, Color.yellow);
        }
        public void AdjustSpeed(float newSpeed)
        {
           
        }
    }
}