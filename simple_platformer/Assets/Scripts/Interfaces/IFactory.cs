using UnityEngine;
using System.Collections;
using System;

public interface IFactory
{
    void RegisterType<T>(Type type);
    void GetInstance<T>();
    void DeregisterClass<T>();    
}
