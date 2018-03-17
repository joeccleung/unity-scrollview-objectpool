using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ListViewItemModel
{
    public System.Object Data { get { return data; } }

    System.Object data;

    public ListViewItemModel(System.Object data)
    {
        this.data = data;
    }
}
