﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LCL
{
    public class HotFixLoop : IGameHotFixInterface
    {
        private static HotFixLoop m_Instance;

        public override void Start()
        {
            m_Instance = this;
            //注册需要修复的bug
            LCLFieldDelegateName.__LCL_MainTest__Test2_Int32_Single__Delegate += OnHotFixTest;

        }

        private void OnHotFixTest(object arg0, int arg1, float arg2)
        {
            Debug.Log("修复一个bug arg1:"+arg1+"arg2:"+arg2);
        }

        public override void Update()
        {

        }
        public static HotFixLoop GetInstance()
        {
            return m_Instance;
        }

        public override void OnDestroy()
        {

        }
        public override void OnApplicationQuit()
        {

        }
        public override object OnMono2GameDll(string func, params object[] data)
        {
            return null;
        }

    }
}
