using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Interface for basic decoupling/DI
/// </summary>
public interface IFactory
{
    void RegisterType<T>(Type type);
    void GetInstance<T>();
    void DeregisterClass<T>();    
}
