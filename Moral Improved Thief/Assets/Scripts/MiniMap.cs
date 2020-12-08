using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> maps;
    public Material lineMaterial;
    public GameObject linePrefab;
    public Canvas canvas;

    List<GameObject> mapList;
    List<(int, int)> mapGraph;

    Transform mapParent;
    Transform LIneParent;

    float radius = 50f;
    public GameObject mapImage;
    int playerPos;

    void Awake()
    {
        //maps = new List<GameObject>();
        mapParent = transform.GetChild(0);
        LIneParent = transform.GetChild(1);
        //DrawLine(maps[0].transform.position, maps[1].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void lineRenderer()
    {
        Vector3 startPos = maps[0].transform.position;
        Vector3 endPos = maps[2].transform.position;
        GameObject currentLine = new GameObject();
        //currentLine.transform.position = startPos;
        LineRenderer currentLineRenderer = currentLine.AddComponent<LineRenderer>();
        currentLineRenderer.SetPosition(0, startPos);
        currentLineRenderer.SetPosition(1, endPos);
        currentLineRenderer.material = lineMaterial;
        currentLineRenderer.startWidth = 1f;
        currentLineRenderer.endWidth = 1f;
    }

    void DrawLine(Vector3 startPos, Vector3 endPos)
    {
        GameObject line = Instantiate(linePrefab, (startPos + endPos) / 2, Quaternion.identity, LIneParent.transform);
        Vector3 dir = endPos - startPos;
        line.transform.Rotate(0f, 0f, Mathf.Atan2(dir.y, dir.x) * 180f / Mathf.PI);
        //line.GetComponent<RectTransform>().sizeDelta.Set(dir.magnitude, 1f);
        line.GetComponent<RectTransform>().sizeDelta = new Vector2(dir.magnitude, 1f);
    }

    public void SetMapList(List<GameObject> list)
    {
        mapList = list;
        int mapcount = mapList.Count;
        if (mapcount <= 0) return;
        for (int i = 0; i < mapcount; i++)
        {
            mapList[i].GetComponent<MapManager>().SetIndex(i);
            mapList[i].GetComponent<MapManager>().SetMinimap(this);
            GameObject miniMapImage = Instantiate(mapImage, mapParent);
            float angle = 2f * Mathf.PI * i / (float)mapcount;
            miniMapImage.transform.localPosition = new Vector3(radius * Mathf.Sin(angle), radius * Mathf.Cos(angle), 0f);
        }
    }

    public void SetMapGraph(List<(int, int)> list)
    {
        foreach (Transform child in LIneParent)
        {
            GameObject.Destroy(child.gameObject);
        }
        mapGraph = list;
        int listCount = mapGraph.Count;
        for (int i = 0; i < listCount; i++)
        {
            (int, int) edge = list[i];
            DrawLine(mapParent.GetChild(edge.Item1).transform.position, mapParent.GetChild(edge.Item2).transform.position);
        }
    }

    public void SetPlayerPos(int idx)
    {
        mapParent.GetChild(playerPos).GetComponent<Image>().color = Color.white;
        playerPos = idx;
        mapParent.GetChild(playerPos).GetComponent<Image>().color = Color.blue;
    }
}
