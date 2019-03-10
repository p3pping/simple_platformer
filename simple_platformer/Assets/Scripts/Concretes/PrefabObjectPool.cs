using UnityEngine;
using System.Collections;

public class PrefabObjectPool : ObjectPool<GameObject>
{
    private GameObject _prefab;

    public PrefabObjectPool(int initalSize, GameObject prefab):base(initalSize)
    {
        _prefab = prefab;
    }

    protected override GameObject CreateObject()
    {
        GameObject newObj = GameObject.Instantiate(_prefab);
        newObj.SetActive(false);

        return newObj;
    }
}
