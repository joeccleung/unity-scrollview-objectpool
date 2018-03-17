using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PooledListView : MonoBehaviour
{
    [SerializeField] ScrollRect ScrollRect;
    [SerializeField] RectTransform DragDetectionT;
    [SerializeField] RectTransform ContentT;
    [SerializeField] int BufferSize;
    [SerializeField] ListViewItemPool ItemPool;

    int[] data;

    public void Setup(int[] data)
    {
        this.data = data;

        DragDetectionT.sizeDelta = new Vector2(DragDetectionT.sizeDelta.x, this.data.Length * 100);

    }
}
