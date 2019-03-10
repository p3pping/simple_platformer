using UnityEngine;
using System.Collections;

public class PrefabPoolMB : MonoBehaviour
{
    public GameObject prefab;
    public int initialSize;
    private PrefabObjectPool _pool;
    public PrefabObjectPool Pool
    {
        get
        {
            return _pool;
        }
    }
    // Use this for initialization
    void Start()
    {
        _pool = new PrefabObjectPool(initialSize, prefab);
    }
}
