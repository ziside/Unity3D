using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading; 
using System.IO;
using LitJson;
public class newguaiwu : MonoBehaviour
{
    public GameObject[] arr;
    public GameObject[] guaiwu;
    public GameObject guaiwu1;
    public GameObject guaiwu2;

    List<TestDeta> allTests;
    public int c;
    int a=0;
    // Start isASD called before the first frame update
    public bool isAK = false;
    void Start()
    {
        string path = Application.streamingAssetsPath+"/第一关1地牢.txt";
        string msg = File.ReadAllText(path);
        List<TestDeta> datas = JsonMapper.ToObject<List<TestDeta>>(msg);
        allTests = datas;
    }
    public GameObject[] Jian;
    public  void FinObj()
    {
          if(!Jian[0].GetComponent<EnterS>().isHave)
        {
            return;
        }
          if(a>=allTests[0].len)
        {
            isAK = false;
            return;
        }
         isAK = true;
        c=0;
        var allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (var obj in allObjects)
        {
            if(obj.name=="yiyi(Clone)")
            c++;
        }
        if(c==0)
        {  
         int n = Random.Range(allTests[0].min, allTests[0].max); 
        for(int i = 0;i<n;i++)
            {
              
                StartCoroutine(MyCoroutine(i,0));
            }
        a++;
        }
        
    }
    int t = 0;
    void FinObj1()
    {
       
        if(!Jian[1].GetComponent<EnterS>().isHave)
        {
            return;
        }
         if(t>=allTests[1].len)
        {
            isAK = false;
            return;
        }
        isAK = true;
        c=0;
        var allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (var obj in allObjects)
        {
            if(obj.name=="Slime_01(Clone)")
            c++;
            if(obj.name=="易怒小子(Clone)")
            c++;
        }
        if(c==0)
        {  
         int n = Random.Range(allTests[1].min, allTests[1].max); 
        for(int i = 0;i<n;i++)
            {
                  int m = Random.Range(0,100000); 
                  StartCoroutine(MyCoroutine(i+5,m%2+1));
            }
        t++;
        }
    }
    
    int  p = 0;
    void FinObj2()
    {
        
        if(!Jian[2].GetComponent<EnterS>().isHave)
        {
            return;
        }
        if(p>=allTests[2].len)
        {
            isAK = false;
            return;
        }
        isAK = true;
        c=0;
        var allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (var obj in allObjects)
        {
            if(obj.name=="Slime_01(Clone)")
            c++;
            if(obj.name=="易怒小子(Clone)")
            c++;
            if(obj.name=="yiyi(Clone)")
            c++;
        }
        if(c==0)
        {  
         int n = Random.Range(allTests[2].min, allTests[2].max); 
        for(int i = 0;i<n;i++)
            {
                  int m = Random.Range(0, 10000); 
                StartCoroutine(MyCoroutine(i+10,m%3));
            }
        p++;
        }
        
    }

    IEnumerator MyCoroutine(int a,int i)
{
    GameObject h2 = Instantiate(guaiwu1,arr[a].transform.position, Quaternion.Euler(90, 0, 0));
    yield return new WaitForSeconds(2f); 
    GameObject h3 = Instantiate(guaiwu[i],arr[a].transform.position, Quaternion.identity);
    GameObject h4 = Instantiate(guaiwu2,arr[a].transform.position,  Quaternion.Euler(-90, 0, 0));
    Destroy(h2);
}
}
