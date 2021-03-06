﻿/****************************************************************************
* Description:
*
* Author: hiramtan @live.com
****************************************************************************/

using System.Collections.Generic;

namespace HiFramework
{
    public class Pool<T> : IPool<T>
    {
        private readonly IPoolHandler<T> _iPoolHandler;
        private readonly Queue<T> _objects = new Queue<T>();
        private IPoolComponent _iPoolComponent;
        public Pool(IPoolHandler<T> iPoolHandler)
        {
            _iPoolHandler = iPoolHandler;
             _iPoolComponent = Center.Get<PoolComponent>();
            _iPoolComponent.AddPool(this);
        }
        public void Destory()
        {
            while (_objects.Count > 0)
            {
                var obj = _objects.Dequeue();
                _iPoolHandler.Destory(obj);
            }
            _iPoolComponent.RemovePool(this);
        }
        public T Get()
        {
            T t = default(T);
            if (_objects.Count > 0)
            {
                t = _objects.Dequeue();
                _iPoolHandler.OutFromPool(t);
            }
            else
            {
                t = _iPoolHandler.Create();
            }
            return t;
        }
        public void Reclaim(T args)
        {
            _iPoolHandler.InToPool(args);
            _objects.Enqueue(args);
        }
    }
}
