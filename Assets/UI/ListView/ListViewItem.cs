using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ListViewItem : MonoBehaviour
{

    [SerializeField] Text itemText;

    public int ItemHeight { get { return 100; }}

    public void Setup(ListViewItemModel model)
    {
        gameObject.name = ((int)(model.Data)).ToString();
        itemText.text = ((int)(model.Data)).ToString();
    }
}
