﻿using UnityEditor;
using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
[System.Reflection.Obfuscation(Exclude = true)]
public class ILRuntimeCLRBinding
{
    public static void GenerateCLRBindingByAnalysis(string hotfixdll, string bindGen)
    {
        //用新的分析热更dll调用引用来生成绑定代码
        ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();
        using (System.IO.FileStream fs = new System.IO.FileStream(hotfixdll, System.IO.FileMode.Open, System.IO.FileAccess.Read))
        {
            domain.LoadAssembly(fs);
        }
        //Crossbind Adapter is needed to generate the correct binding code
        InitILRuntime(domain);
        ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, bindGen);
    }

    static void InitILRuntime(ILRuntime.Runtime.Enviorment.AppDomain domain)
    {
        //这里需要注册所有热更DLL中用到的跨域继承Adapter，否则无法正确抓取引用
        //domain.RegisterCrossBindingAdaptor(new MonoBehaviourAdapter());
        //domain.RegisterCrossBindingAdaptor(new CoroutineAdapter());
        domain.RegisterCrossBindingAdaptor(new IGameHotFixInterfaceAdapter());
        //domain.RegisterCrossBindingAdaptor(new ISerializePacketAdapter());
    }
}
