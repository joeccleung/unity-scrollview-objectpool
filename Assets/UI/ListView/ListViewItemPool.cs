﻿/*
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

public class ListViewItemPool : MonoBehaviour {

   [SerializeField] int PoolSize = 1;
   [SerializeField] GameObject PoolObjectPrefab;

   int head = 0;

   void Awake()
   {
      head = 0;

      for(int i = 0; i < PoolSize; i++) {
         GameObject poolObj = Instantiate(PoolObjectPrefab) as GameObject;
         poolObj.transform.SetParent(this.transform);
         poolObj.SetActive(false);
      }
   }

   public GameObject ItemBorrow()
   {
      if(head >= PoolSize) {
         return null;
      }

      head++;
      return this.transform.GetChild(0).gameObject;
   }

   public void ItemReturn(GameObject go)
   {
      if(head <= 0) {
         return;
      }

      head--;
      go.SetActive(false);
      go.transform.SetParent(this.transform);
   }
}
