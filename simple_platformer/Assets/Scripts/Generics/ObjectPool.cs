using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Generic Object Pool
/// This pool does not track or handle returning objects
/// </summary>
public class ObjectPool<T>
{
    private List<T> _pool;
    private int _increaseSize;

    public ObjectPool(int initialSize)
    {
        _increaseSize = initialSize;
        _pool = new List<T>();
        PoolObjects(initialSize);
    }

    /// <summary>
    /// Pools up some objects
    /// </summary>
    /// <param name="poolSize"></param>
    protected virtual void PoolObjects(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            _pool.Add(CreateObject());
        }
    }

    /// <summary>
    /// Creates Object of type T
    /// </summary>
    protected virtual T CreateObject()
    {
        return Activator.CreateInstance<T>();
    }

    /// <summary>
    /// Take and object from the pool
    /// </summary>
    protected virtual T TakeObject()
    {
        if(_pool.Count == 0)
        {
            PoolObjects(_increaseSize);
        }

        T toReturn = _pool[0];
        _pool.RemoveAt(0);
        return toReturn;
    }
}
