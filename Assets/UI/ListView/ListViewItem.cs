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

    public void Setup(int i)
    {
        gameObject.name = i.ToString();
        itemText.text = i.ToString();
    }
}
