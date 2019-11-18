//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using UnityEngine;

//public static class TransformProcessor
//{
//    private static Dictionary<TransformState, Transform> Transforms = new Dictionary<TransformState, Transform>();
//    private static bool IsInitialized;

//    private static void Initialize()
//    {
//        Transforms.Clear();

//        var transformStates = Assembly.GetAssembly(typeof(Transform)).GetTypes().Where(t => typeof(Transform).IsAssignableFrom(t) && t.IsAbstract == false);

//        foreach(var transformState in transformStates)
//        {
//            Transform transform = Activator.CreateInstance(transformState) as Transform;
//            Transforms.Add(transform.TransformState, transform);
//        }

//        IsInitialized = true;
//    }

//    public static void TransformBlock(TransformState tramsformState)
//    {

//    }

//}
