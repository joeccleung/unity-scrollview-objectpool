using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PooledListView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] ScrollRect ScrollRect;
    [SerializeField] RectTransform viewPortT;
    [SerializeField] RectTransform DragDetectionT;
    [SerializeField] RectTransform ContentT;
    [SerializeField] float ItemHeight = 1;      // TODO: Replace it with dynamic height
    [SerializeField] int BufferSize;
    [SerializeField] ListViewItemPool ItemPool;

    int TargetVisibleItemCount { get { return Mathf.Max(Mathf.CeilToInt(viewPortT.rect.height / ItemHeight), 0); } }
    int TopItemOutOfView { get { return Mathf.CeilToInt(ContentT.anchoredPosition.y / ItemHeight); }}

    float dragDetectionAnchorPreviousY = 0;

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





    public void OnDragDetectionPositionChange(Vector2 dragNormalizePos)
    {
        float dragDelta = DragDetectionT.anchoredPosition.y - dragDetectionAnchorPreviousY;

        ContentT.anchoredPosition = new Vector2(ContentT.anchoredPosition.x, ContentT.anchoredPosition.y + dragDelta);

        UpdateContentBuffer();

        dragDetectionAnchorPreviousY = DragDetectionT.anchoredPosition.y;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        dragDetectionAnchorPreviousY = DragDetectionT.anchoredPosition.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    void UpdateContentBuffer()
    {
        if(TopItemOutOfView > BufferSize)
        {
            if(dataTail >= data.Length)
            {
                return;
            }

            Transform firstChildT = ContentT.GetChild(0);
            firstChildT.SetSiblingIndex(ContentT.childCount - 1);
            firstChildT.gameObject.GetComponent<ListViewItem>().Setup(data[dataTail]);
            ContentT.anchoredPosition = new Vector2(ContentT.anchoredPosition.x, ContentT.anchoredPosition.y - firstChildT.gameObject.GetComponent<ListViewItem>().ItemHeight);
            dataHead++;
            dataTail++;
        }
        else if(TopItemOutOfView < BufferSize)
        {
            if(dataHead <= 0)
            {
                return;
            }

            Transform lastChildT = ContentT.GetChild(ContentT.childCount - 1);
            lastChildT.SetSiblingIndex(0);
            dataHead--;
            dataTail--;
            lastChildT.gameObject.GetComponent<ListViewItem>().Setup(data[dataHead]);
            ContentT.anchoredPosition = new Vector2(ContentT.anchoredPosition.x, ContentT.anchoredPosition.y + lastChildT.gameObject.GetComponent<ListViewItem>().ItemHeight);

        }

    }
}
