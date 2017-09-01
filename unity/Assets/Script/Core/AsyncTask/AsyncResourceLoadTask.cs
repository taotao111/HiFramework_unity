﻿//****************************************************************************
// Description:
// Author: hiramtan@live.com
//****************************************************************************

using System;
using UnityEngine;

namespace HiFramework
{
    /// <summary>
    /// Resource文件夹下异步加载
    /// </summary>
    public class AsyncResourceLoadTask : AsyncTask
    {
        private ResourceRequest _resourceRequest;
        /// <summary>
        /// resource文件夹下路径
        /// </summary>
        /// <param name="param"></param>
        public AsyncResourceLoadTask(string param, Action<object> action) : base(action)
        {
            _resourceRequest = Resources.LoadAsync(param);
        }

        protected override void Tick()
        {
            if (_resourceRequest.isDone)
                IsDone = true;
        }

        protected override void Complate()
        {
            Action(_resourceRequest.asset);
        }
    }
}


//public class TestLoad : MonoBehaviour
//{

//    // Use this for initialization
//    void Start()
//    {

//        new AsyncResourceLoadTask("Cube").Start().Finish((p) =>
//        {
//            Object temp = (Object)p;
//            Instantiate(temp);
//        });
//    }
//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
