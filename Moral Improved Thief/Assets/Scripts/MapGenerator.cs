﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> mapTemplate;
    [SerializeField]public List<GameObject> mapList;
    //List<(int, int)> mapGraph;
    public Transform map;
    public int size;
    //public int additional
    int chk;

    // Start is called before the first frame update
    void Start()
    {
        mapList = new List<GameObject>();
        chk = 0;
        InstantiateMap();
        while (Generate() == null) ;
        
    }

    void HeapTest()
    {
        MinHeap<int> heap = new MinHeap<int>();
        heap.Add(2);
        heap.Add(4);
        heap.Add(3);
        heap.Add(5);
        heap.Add(1);

        while (!heap.Empty())
        {
            Debug.Log(heap.Top());
            heap.Pop();
        }
    }

    void InstantiateMap()
    {
        for (int i = 0; i < size; i++)
        {
            Vector3 pos = new Vector3(i * 25, 0, 0);
            GameObject obj = Instantiate(mapTemplate[0], pos, Quaternion.identity, map);
            mapList.Add(obj);
        }
    }
    
    public void Reconnect()
    {
        foreach (GameObject map in mapList)
        {
            map.GetComponent<PortalManager>().Unconnect();
        }
        while (Generate() == null) ;
    }

    List<(int, int)> Generate()
    {
        MinHeap<ValueTuple<float, int, int>> minHeap = new MinHeap<ValueTuple<float, int, int>>();

        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                float len = UnityEngine.Random.Range(0.1f, 10.0f);
                ValueTuple<float, int, int> edge = (len, i, j);
                minHeap.Add(edge);
            } 
        }

        //Find Minimum Spanning Tree
        List<(int, int)> _mapGraph = new List<(int, int)>();
        int[] parentNode = new int[size];

        for (int idx = 0; idx < size; idx++)
        {
            parentNode[idx] = idx;
        }

        for (int idx = 0; idx < size - 1; idx++)
        {
            while (true)
            {
                ValueTuple<float, int, int> edge = minHeap.Top();
                minHeap.Pop();
                if (FindParent(parentNode, edge.Item2) != FindParent(parentNode, edge.Item3))
                {
                    //Debug.Log(edge);
                    if(PortalManager.Connect(mapList[edge.Item2].GetComponent<PortalManager>(), mapList[edge.Item3].GetComponent<PortalManager>()) < 0) //try connect
                    {
                        continue;
                    }
                    _mapGraph.Add((edge.Item2, edge.Item3)); //  save MST
                    parentNode[FindParent(parentNode, edge.Item2)] = FindParent(parentNode, edge.Item3);
                    break;
                }
                //runtime error check;
                if (minHeap.Empty())
                {
                    Debug.LogError("infinite loop");
                    return null;
                }
            }
        }
        return _mapGraph;
    }

    int FindParent(int[] parent, int idx)
    {
        if (parent[idx] == idx) return idx;
        else return FindParent(parent, parent[idx]);
    }

}
