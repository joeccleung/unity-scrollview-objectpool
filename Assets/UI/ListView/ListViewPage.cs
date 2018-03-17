using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListViewPage : MonoBehaviour {

   [SerializeField] ScrollRect ScrollRect;
   [SerializeField] RectTransform DragDetectionT;
   [SerializeField] RectTransform ContentT;
   [SerializeField] int BufferSize;
   [SerializeField] ListViewItemPool ItemPool;


   public void Setup(int[] data)
   {

   }
}
