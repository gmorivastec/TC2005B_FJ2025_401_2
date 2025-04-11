using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // POOL
    // singleton, obviamente
    public static PoolManager Instance 
    {
        get;
        private set;
    }

    // miembros utilizados por el mecanismo de pool
    [SerializeField]
    private GameObject _original;

    [SerializeField]
    private int _poolSize = 10;

    [SerializeField]
    private Queue<GameObject> _poolQueue;
    void Awake()
    {
        if(Instance == null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
