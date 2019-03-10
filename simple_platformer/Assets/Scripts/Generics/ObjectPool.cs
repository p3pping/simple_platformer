using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

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

    protected virtual void PoolObjects(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            _pool.Add(CreateObject());
        }
    }

    protected virtual T CreateObject()
    {
        return Activator.CreateInstance<T>();
    }

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
