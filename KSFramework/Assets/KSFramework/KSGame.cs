﻿#region Copyright (c) 2015 KEngine / Kelly <http://github.com/mr-kelly>, All rights reserved.

// KEngine - Toolset and framework for Unity3D
// ===================================
// 
// Filename: AppEngineInspector.cs
// Date:     2015/12/03
// Author:  Kelly
// Email: 23110388@qq.com
// Github: https://github.com/mr-kelly/KEngine
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3.0 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library.

#endregion
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AppSettings;
using KEngine;
using KEngine.UI;
using SLua;

namespace KSFramework
{
    /// <summary>
    /// KSFramework base game entry,  create your class extends from this
    /// </summary>
    public abstract class KSGame : MonoBehaviour, IAppEntry
    {
        public static KSGame Instance { get; private set; }

        /// <summary>
        /// Module/Manager of Slua
        /// </summary>
        public LuaModule LuaModule { get; private set; }

        /// <summary>
        /// Create Module, with new some class inside
        /// </summary>
        /// <returns></returns>
        protected virtual IList<IModuleInitable> CreateModules()
        {
            return new List<IModuleInitable>
            {
                UIModule.Instance,
                LuaModule,
            };
        }

        /// <summary>
        /// Unity `Awake`
        /// </summary>
        protected virtual void Awake()
        {
            Instance = this;
            LuaModule = new LuaModule();
            AppEngine.New(gameObject, this, CreateModules());
        }



        /// <summary>
        /// Before KEngine init modules
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator OnBeforeInitModules();

        /// <summary>
        /// After KEngine inited all module, make the game start!
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator OnFinishInitModules();
    }
}
