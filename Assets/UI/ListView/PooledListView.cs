using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PooledListView : MonoBehaviour
{
    [SerializeField] ScrollRect ScrollRect;
    [SerializeField] RectTransform viewPortT;
    [SerializeField] RectTransform DragDetectionT;
    [SerializeField] RectTransform ContentT;
    [SerializeField] float ItemHeight = 1;      // TODO: Replace it with dynamic height
    [SerializeField] int BufferSize;
    [SerializeField] ListViewItemPool ItemPool;

    public int TargetVisibleItemCount { get { return Mathf.CeilToInt(viewPortT.rect.height / ItemHeight); } }

    int[] data;
    int dataHead = 0;
    int dataTail = 0;

    public void Setup(int[] data)
    {
        ScrollRect.onValueChanged.AddListener(OnDragDetectionPositionChange);

        this.data = data;

        DragDetectionT.sizeDelta = new Vector2(DragDetectionT.sizeDelta.x, this.data.Length * ItemHeight);

        for(int i = 0; i < TargetVisibleItemCount + BufferSize; i++)
        {
            GameObject itemGO = ItemPool.ItemBorrow();
            itemGO.transform.SetParent(ContentT);
            itemGO.SetActive(true);
            itemGO.transform.localScale = Vector3.one;
            itemGO.GetComponent<ListViewItem>().Setup(data[dataTail]);
            dataTail++;
        }
    }


    public void OnDragDetectionPositionChange(Vector2 eventData)
    {
        
    }
}
