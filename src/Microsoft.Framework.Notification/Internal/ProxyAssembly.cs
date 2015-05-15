﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if NET45 || DNX451 || DNXCORE50

using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Microsoft.Framework.Notification.Internal
{
    public static class ProxyAssembly
    {
        private static volatile int Counter = 0;

        private static AssemblyBuilder AssemblyBuilder;
        private static ModuleBuilder ModuleBuilder;

        static ProxyAssembly()
        {
            var assemblyName = new AssemblyName("Microsoft.Framework.Notification.ProxyAssembly");

            AssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder = AssemblyBuilder.DefineDynamicModule("Main Module");
        }

        public static TypeBuilder DefineType(
            string name,
            TypeAttributes attributes,
            Type baseType,
            Type[] interfaces)
        {
            name = name + "_" + Counter++;
            return ModuleBuilder.DefineType(name, attributes, baseType, interfaces);
        }
    }
}

#endif