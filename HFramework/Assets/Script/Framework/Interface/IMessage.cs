﻿using UnityEngine;
using System.Collections;

namespace HFramework
{
    /// <summary>
    /// 控制逻辑必须继承
    /// </summary>
    public interface IMessage
    {
        void DispatchMessage(Message paramMessage);
        void OnMessage(Message paramMessage);
    }
}