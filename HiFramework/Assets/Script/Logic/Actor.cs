﻿using HiFramework;
using System;
using UnityEngine;

/// <summary>
/// 负责组装和销毁
/// </summary>
public class Actor : View
{
    public void OnDestroy()
    {
        Remove(this);
    }
}