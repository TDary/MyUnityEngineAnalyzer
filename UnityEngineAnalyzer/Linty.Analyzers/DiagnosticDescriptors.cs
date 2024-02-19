﻿using System;
using System.Linq;
using System.Resources;
using Linty.Analyzers.Animator;
using Linty.Analyzers.AOT;
using Linty.Analyzers.Audio;
using Linty.Analyzers.Camera;
using Linty.Analyzers.CompareTag;
using Linty.Analyzers.Coroutines;
using Linty.Analyzers.EmptyMonoBehaviourMethods;
using Linty.Analyzers.FindMethodsInUpdate;
using Linty.Analyzers.ForEachInUpdate;
using Linty.Analyzers.IL2CPP;
using Linty.Analyzers.Material;
using Linty.Analyzers.OnGUI;
using Linty.Analyzers.Physics;
using Linty.Analyzers.StringMethods;
using Linty.Analyzers.Transform;
using Linty.Analyzers.Vector;
using Microsoft.CodeAnalysis;
using UnityEngineAnalyzer;

namespace Linty.Analyzers
{
    public static class DiagnosticDescriptors
    {
        public static readonly DiagnosticDescriptor DoNotUseOnGUI;
        public static readonly DiagnosticDescriptor DoNotUseStringMethods;
        public static readonly DiagnosticDescriptor DoNotUseCoroutines;
        public static readonly DiagnosticDescriptor EmptyMonoBehaviourMethod;
        public static readonly DiagnosticDescriptor UseCompareTag;
        public static readonly DiagnosticDescriptor DoNotUseFindMethodsInUpdate;
        public static readonly DiagnosticDescriptor DoNotUseFindMethodsInUpdateRecursive;
        public static readonly DiagnosticDescriptor DoNotUseRemoting;
        public static readonly DiagnosticDescriptor DoNotUseReflectionEmit;
        public static readonly DiagnosticDescriptor TypeGetType;
        public static readonly DiagnosticDescriptor DoNotUseForEachInUpdate;
        public static readonly DiagnosticDescriptor UnsealedDerivedClass;
        public static readonly DiagnosticDescriptor InvokeFunctionMissing;
        public static readonly DiagnosticDescriptor DoNotUseStateName;
        public static readonly DiagnosticDescriptor DoNotUseStringPropertyNames;
        public static readonly DiagnosticDescriptor UseNonAllocMethods;
        public static readonly DiagnosticDescriptor CameraMainIsSlow;
        public static readonly DiagnosticDescriptor AudioSourceMuteUsesCPU;
        public static readonly DiagnosticDescriptor InstantiateTakeParent;
        public static readonly DiagnosticDescriptor VectorMagnitudeIsSlow;

        static DiagnosticDescriptors()
        {
            //** UNITY **

            //GC
            DoNotUseOnGUI = CreateDiagnosticDescriptor<DoNotUseOnGUIResources>(DiagnosticIDs.DoNotUseOnGUI, DiagnosticCategories.GC, DiagnosticSeverity.Info);
            DoNotUseStringMethods = CreateDiagnosticDescriptor<DoNotUseStringMethodsResources>(DiagnosticIDs.DoNotUseStringMethods, DiagnosticCategories.GC, DiagnosticSeverity.Info);
            DoNotUseCoroutines = CreateDiagnosticDescriptor<DoNotUseCoroutinesResources>(DiagnosticIDs.DoNotUseCoroutines, DiagnosticCategories.GC, DiagnosticSeverity.Info);
            UseCompareTag = CreateDiagnosticDescriptor<UseCompareTagResources>(DiagnosticIDs.UseCompareTag, DiagnosticCategories.GC, DiagnosticSeverity.Warning);
            UseNonAllocMethods = CreateDiagnosticDescriptor<UseNonAllocMethodsResources>(DiagnosticIDs.PhysicsUseNonAllocMethods, DiagnosticCategories.GC, DiagnosticSeverity.Warning, UnityVersion.UNITY_5_3);
            CameraMainIsSlow = CreateDiagnosticDescriptor<CameraMainResource>(DiagnosticIDs.CameraMainIsSlow, DiagnosticCategories.GC, DiagnosticSeverity.Warning);

            //Performance
            AudioSourceMuteUsesCPU = CreateDiagnosticDescriptor<AudioSourceResource>(DiagnosticIDs.AudioSourceMuteUsesCPU, DiagnosticCategories.Performance, DiagnosticSeverity.Info);
            DoNotUseFindMethodsInUpdate = CreateDiagnosticDescriptor<DoNotUseFindMethodsInUpdateResources>(DiagnosticIDs.DoNotUseFindMethodsInUpdate, DiagnosticCategories.Performance, DiagnosticSeverity.Warning);
            DoNotUseFindMethodsInUpdateRecursive = CreateDiagnosticDescriptor<DoNotUseFindMethodsInUpdateResources>(DiagnosticIDs.DoNotUseFindMethodsInUpdate, DiagnosticCategories.Performance, DiagnosticSeverity.Warning);
            DoNotUseForEachInUpdate = CreateDiagnosticDescriptor<DoNotUseForEachInUpdateResources>(DiagnosticIDs.DoNotUseForEachInUpdate, DiagnosticCategories.Performance, DiagnosticSeverity.Warning, UnityVersion.UNITY_1_0, UnityVersion.UNITY_5_5);
            UnsealedDerivedClass = CreateDiagnosticDescriptor<UnsealedDerivedClassResources>(DiagnosticIDs.UnsealedDerivedClass, DiagnosticCategories.Performance, DiagnosticSeverity.Warning);
            InvokeFunctionMissing = CreateDiagnosticDescriptor<InvokeFunctionMissingResources>(DiagnosticIDs.InvokeFunctionMissing, DiagnosticCategories.Performance, DiagnosticSeverity.Warning);
            DoNotUseStateName = CreateDiagnosticDescriptor<DoNotUseStateNameResource>(DiagnosticIDs.DoNotUseStateNameInAnimator, DiagnosticCategories.Performance, DiagnosticSeverity.Warning);
            DoNotUseStringPropertyNames = CreateDiagnosticDescriptor<DoNotUseStringPropertyNamesResource>(DiagnosticIDs.DoNotUseStringPropertyNames, DiagnosticCategories.Performance, DiagnosticSeverity.Warning);
            InstantiateTakeParent = CreateDiagnosticDescriptor<InstantiateResource>(DiagnosticIDs.InstantiateShouldTakeParentArgument, DiagnosticCategories.Performance, DiagnosticSeverity.Warning, UnityVersion.UNITY_5_4);
            VectorMagnitudeIsSlow = CreateDiagnosticDescriptor<VectorAnalyzerResource>(DiagnosticIDs.VectorMagnitudeIsSlow, DiagnosticCategories.Performance, DiagnosticSeverity.Info);

            //Miscellaneous
            EmptyMonoBehaviourMethod = CreateDiagnosticDescriptor<EmptyMonoBehaviourMethodsResources>(DiagnosticIDs.EmptyMonoBehaviourMethod, DiagnosticCategories.Miscellaneous, DiagnosticSeverity.Warning);

            //** AOT **
            DoNotUseRemoting = CreateDiagnosticDescriptor<DoNotUseRemotingResources>(DiagnosticIDs.DoNotUseRemoting, DiagnosticCategories.AOT, DiagnosticSeverity.Info);
            DoNotUseReflectionEmit = CreateDiagnosticDescriptor<DoNotUseReflectionEmitResources>(DiagnosticIDs.DoNotUseReflectionEmit, DiagnosticCategories.AOT, DiagnosticSeverity.Info);
            TypeGetType = CreateDiagnosticDescriptor<TypeGetTypeResources>(DiagnosticIDs.TypeGetType, DiagnosticCategories.AOT, DiagnosticSeverity.Info);
        }

        private static DiagnosticDescriptor CreateDiagnosticDescriptor<T>(string id, string category, DiagnosticSeverity severity, UnityVersion first = UnityVersion.UNITY_1_0, UnityVersion latest = UnityVersion.LATEST, bool isEnabledByDefault = true)
        {
            var resourceManager = new ResourceManager(typeof(T));

            return new DiagnosticDescriptor(
            id: id,
            title: new LocalizableResourceString("Title", resourceManager, typeof(T)),
            messageFormat: new LocalizableResourceString("MessageFormat", resourceManager, typeof(T)),
            category: category,
            defaultSeverity: severity,
            isEnabledByDefault: isEnabledByDefault,
            customTags: CreateUnityVersionInfo(first, latest),
            description: new LocalizableResourceString("Description", resourceManager, typeof(T)));
        }

        private static string[] CreateUnityVersionInfo(UnityVersion start, UnityVersion end)
        {
            return new string[] { Enum.GetName(typeof(UnityVersion), start), Enum.GetName(typeof(UnityVersion), end) };
        }

        public static UnityVersionSpan GetVersion(DiagnosticDescriptor dc)
        {
            var list = dc.CustomTags.ToList();

            if (list.Count < 2)
            {
                return new UnityVersionSpan(UnityVersion.NONE, UnityVersion.LATEST);
            }

            var start = (UnityVersion)Enum.Parse(typeof(UnityVersion), list[0]);
            var end = (UnityVersion)Enum.Parse(typeof(UnityVersion), list[1]);

            return new UnityVersionSpan(start, end);
        }
    }
}