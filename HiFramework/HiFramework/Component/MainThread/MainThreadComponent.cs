﻿using System;
using System.Collections.Generic;

namespace HiFramework.Component.MainThread
{
    public class MainThreadComponent : IComponent, ITick, IMainThread
    {
        private readonly Queue<ToExecute> _toExecuteQueue = new Queue<ToExecute>();
        private readonly List<Action> _applicationQuitActionList = new List<Action>();
        private static readonly object Locker = new object();
        public void OnRegist()
        {
            //main thread init
        }

        public void OnUnRegist()
        {
            //throw new System.NotImplementedException();
        }
        public void RunOnMainThread(Action<object> action, object obj)//obj不能可选为空,数据会被线程冲刷,需要传递原有数据
        {
            lock (Locker)
            {
                _toExecuteQueue.Enqueue(new ToExecute(action, obj));
            }
        }

        public void RunOnApplicationQuit(Action action)
        {
            Assert.IsFalse(_applicationQuitActionList.Contains(action));
            _applicationQuitActionList.Add(action);
        }

        public void Quit()
        {
            foreach (var variable in _applicationQuitActionList)
            {
                variable();
            }
        }

        public void Tick()
        {
            if (_toExecuteQueue.Count > 0)
            {
                lock (Locker)
                {
                    while (_toExecuteQueue.Count > 0)
                    {
                        var per = _toExecuteQueue.Dequeue();
                        per.Action(per.Obj);
                    }
                }
            }
        }
        private class ToExecute
        {
            public ToExecute(Action<object> action, object obj)
            {
                Action = action;
                Obj = obj;
            }

            public Action<object> Action { get; private set; }
            public object Obj { get; private set; }
        }
    }
}
