﻿//****************************************************************************
// Description: 无参数异步任务父类
// Author: hiramtan@live.com
//****************************************************************************

using System;

namespace HiFramework
{
    public abstract class AsyncTaskNoParam : ITick
    {
        private readonly IAsyncComponent _iAsyncComponent;
        protected Action Action;
        protected AsyncTaskNoParam(Action action)
        {
            _iAsyncComponent = Center.Get<AsyncComponent>();
            _iAsyncComponent.RegistTick(this);
            Action = action;
        }

        public abstract void Tick();

        protected virtual void Done()
        {
            _iAsyncComponent.UnRegistTick(this);
            Action();
        }
    }
}