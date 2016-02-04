﻿
using System;
using System.Collections.Generic;

namespace HiFramework
{
    public class GameTick : ITick
    {
        private IList<ITick> tickList = new List<ITick>();

        public void OnTick(float paramTime)
        {
            for (int i = 0; i < tickList.Count; i++)
            {
                tickList[i].OnTick(paramTime);
            }
        }

        public void AddToTickList(ITick paramTick)
        {
            if (!tickList.Contains(paramTick))
                tickList.Add(paramTick);
        }
        public void RemoveFromTickList(ITick paramTick)
        {
            if (tickList.Contains(paramTick))
                tickList.Remove(paramTick);
        }
    }
}