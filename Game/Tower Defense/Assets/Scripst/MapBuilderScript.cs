using UnityEngine;

public class MapBuilderScript : MonoBehaviour
{
    public GameObject MapUI;
    private GameObject lastMap;
    private Transform lastTile;
    private Transform midTile;
    private Transform waypoint;
    private Transform end;
    private Vector3 dir;
    private Vector3 rotation = new Vector3(0, 0, 0);
    public GameObject startPrefab;
    public GameObject endPrefab;
    public GameObject straightPrefab;
    public GameObject rightPrefab;
    public GameObject leftPrefab;
    private int count = 0;
    void Awake()
    {
        ShowUI();
        lastMap = (GameObject)Instantiate(startPrefab, transform.position, transform.rotation);
        Next();
    }
    public void Expand()
    {
        GameObject prefab = ChooseRoute();
        lastMap = (GameObject)Instantiate(prefab, (dir * 28) + lastMap.transform.position, transform.rotation);
        transform.eulerAngles = rotation;
        Next();
        HideUI();
    }

    void Next()
    {
        lastTile = lastMap.transform.Find("Last");
        waypoint = lastMap.transform.Find("Waypoint");
        midTile = lastMap.transform.Find("Middle");
        end = lastMap.transform.Find("END");
        GMScript.waypoints.Insert(0, waypoint);
        dir = (lastTile.position - midTile.position).normalized;
        transform.position = lastTile.position + (dir*3);
        MapUI.transform.position = lastTile.position + (dir * 13);
        if(end != null)
        {
            transform.position = end.position;
            HideUI();
        }
        count++;
    }
    GameObject ChooseRoute()
    {
        bool frente = false, izq = false, der = false;
        Vector3 left = Vector3.Cross(dir, Vector3.up);
        Vector3 right = -left;
        GameObject prefab;
        int random = -1;
        if(count == WaveScript.waveLimit)
        {
            rotation += new Vector3(0, -180, 0);
            End();
            return endPrefab;
        }
        if (Physics.Raycast(transform.position, dir, 40f))
        {
            frente = true;
        }
        if (Physics.Raycast(transform.position, left, 40f))
        {
            izq = true;
        }
        if (Physics.Raycast(transform.position, right, 40f))
        {
            der = true;
        }

        if (frente && izq && der)
        {
            rotation += new Vector3(0, -180, 0);
            End();
            return endPrefab;
        }

        if (frente && izq && !der)
        {
            rotation += new Vector3(0, 90, 0);
            return rightPrefab;
        }

        if (frente && der && !izq)
        {
            rotation += new Vector3(0, -90, 0);
            return leftPrefab;
        }

        if (izq && der && !frente)
        {
            return straightPrefab;
        }

        if(frente && !der && !izq)
        {
            random = Random.Range(0, 2); 
        }
        else if (!frente && !der && izq)
        {
            random = Random.Range(1,3);
        }
        else if(!frente && der && !izq)
        {
            random = 0;
        }
        else
        {
            random = Random.Range(0, 4);
        }

        if (random == 0)
        {
            prefab = leftPrefab;
            rotation += new Vector3(0, -90, 0);
        }
        else if (random == 1)
        {
            prefab = rightPrefab;
            rotation += new Vector3(0, 90, 0);
        }
        else
        {
            prefab = straightPrefab;
        }
        return prefab;
    }

    private void End()
    {
        transform.eulerAngles = rotation;
        MapUI.SetActive(false);
    }
    private void HideUI()
    {
        MapUI.SetActive(false);
    }
    public void ShowUI()
    {
        MapUI.SetActive(true);
    }
    private void Update()
    {
        Debug.Log(WaveScript.count);
        if(WaveScript.count != 0)
        {
            HideUI();
            return;
        }
        if(end != null)
        {
            HideUI();
            return;
        }
        ShowUI();
    }
}
