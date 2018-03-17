using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PooledListView listView;
    [SerializeField] int DataCount;

    void Start()
    {
        int[] demoData = new int[DataCount];
        for(int i = 0; i < DataCount; i++)
        {
            demoData[i] = i + 1;
        }

        listView.Setup(demoData);
    }
}
