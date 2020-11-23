using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;

public class MinHeap<T> where T : System.IComparable<T>
{
    public T[] heap;
    int size;

    public MinHeap(int maxSize = 300) {
        size = 0;
        heap = new T[maxSize];
    }

    public void Add(T e)
    {
        size++;
        heap[size] = e;
        int temp = size;
        while (temp > 1)
        {
            if (heap[temp].CompareTo(heap[temp / 2]) < 0)
            {
                T tempT = heap[temp];
                heap[temp] = heap[temp / 2];
                heap[temp / 2] = tempT;
                temp /= 2;
            }
            else break;
        }
    }

    public T Top()
    {
        return heap[1];
    }

    public bool Empty()
    {
        if (size == 0) return true;
        else return false;
    }

    public void Pop()
    {
        if (size <= 0) return;
        heap[1] = heap[size];
        int temp = 1;
        size--;
        while(temp < size)
        {
            if (heap[temp].CompareTo(heap[2 * temp]) < 0 && heap[temp].CompareTo(heap[2 * temp + 1]) < 0)
            {
                break;
            }
            else if (heap[2 * temp].CompareTo(heap[2 * temp + 1]) < 0)
            {
                T tempT = heap[temp];
                heap[temp] = heap[2 * temp];
                heap[2 * temp] = tempT;
                temp = 2 * temp;
            }
            else
            {
                T tempT = heap[temp];
                heap[temp] = heap[2 * temp + 1];
                heap[2 * temp + 1] = tempT;
                temp = 2 * temp +1;
            }
        }
    }

}

public class PriorityQueue
{
    
}

