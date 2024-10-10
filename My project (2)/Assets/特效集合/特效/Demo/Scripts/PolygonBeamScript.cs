using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace PolygonArsenal
{

public class PolygonBeamScript : MonoBehaviour {

    [Header("Prefabs")]
    public GameObject[] beamLineRendererPrefab;
    public GameObject[] beamStartPrefab;
    public GameObject[] beamEndPrefab;

    private int currentBeam = 1;

    private GameObject beamStart;
    private GameObject beamEnd;
    private GameObject beam;
    private LineRenderer line;

    [Header("Adjustable Variables")]
    public float beamEndOffset = 1f; //How far from the raycast hit point the end effect is positioned
    public float textureScrollSpeed = 8f; //How fast the texture scrolls along the beam
	public float textureLengthScale = 3; //Length of the beam texture

    public Vector3 kong;
     public GameObject move;
     public GameObject move2;
     private bool j = false;
    // Use this for initialization  LineRenderer   move.GetComponent<Move>().isGround
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonUp(0)  || Input.GetKeyDown(KeyCode.Space)) && j )
        {
            Destroy(beamStart);
            Destroy(beamEnd);
            Destroy(beam);
            j=false;
        }
     kong= move2.transform.position;
     kong.y += 1;
     this.transform.position = kong;


        if (Input.GetMouseButtonDown(0) && !j )
        {
            beamStart = Instantiate(beamStartPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            beamEnd   = Instantiate(beamEndPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            beam      = Instantiate(beamLineRendererPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            line = beam.GetComponent<LineRenderer>();
            j = true;
        }

        if( !move.GetComponent<Move>().isGround)
        {
            return;
        }
          if (Input.GetMouseButton(0))
        {
            Vector3 look;
            Vector3 end;
            Vector3 tdir = new Vector3(0,0,0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                 look = hit.point;
                 look.y=0;
                 end = transform.position;
                 end.y=0;
                 tdir = look - end;
               
            }
            ShootBeamInDir(transform.position, tdir);
        }
    }
    void ShootBeamInDir(Vector3 start, Vector3 dir)
    {
        line.positionCount = 2;
        line.SetPosition(0, start);
        beamStart.transform.position = start;

        Vector3 end = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(start, dir, out hit))
            end = hit.point - (dir.normalized * beamEndOffset);
        else
            end = transform.position + (dir * 100);

        beamEnd.transform.position = end;
        line.SetPosition(1, end);

        beamStart.transform.LookAt(beamEnd.transform.position);
        beamEnd.transform.LookAt(beamStart.transform.position);

        float distance = Vector3.Distance(start, end);
        line.sharedMaterial.mainTextureScale = new Vector2(distance / textureLengthScale, 1);
        line.sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * textureScrollSpeed, 0);
    }
}
}
