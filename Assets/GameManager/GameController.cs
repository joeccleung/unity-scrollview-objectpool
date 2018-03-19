/*
 * Scroll View with Object Pool based on Unity UI Framework
 * Copyright (C) 2018 Joe Leung
 * 
 * Public Repository of this program: <https://github.com/joeccleung/unity-scrollview-objectpool.git>
 *
 * This program is free software: you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by the Free
 * Software Foundation, either version 3 of the License, or
 * any later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for
 * more details.
 *
 * You should have received a copy of the GNU Lesser General Public License along with
 * this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] PooledListView listView;
    [SerializeField] int DataCount;

    void Start()
    {
        ListViewItemModel[] demoData = new ListViewItemModel[DataCount];
        for(int i = 0; i < DataCount; i++)
        {
            demoData[i] = new ListViewItemModel(i + 1);
        }

        listView.Setup(demoData);
    }
}
