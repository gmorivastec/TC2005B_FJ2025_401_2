using System.Collections.Generic;
using UnityEngine;

// generics! 
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
public class PoolManager<T> : MonoBehaviour where T : MonoBehaviour
{
    // POOL
    // singleton, obviamente
    public static PoolManager<T> Instance 
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
    private Queue<T> _poolQueue;
    void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_original.GetComponent<T>() == null)
            throw new System.Exception("EL ORIGINAL NO TIENE EL COMPONENTE REQUERIDO");

        _poolQueue = new Queue<T>();
        
        for(int i = 0; i < _poolSize; i++) 
        {
            GameObject nuevoObjeto = Instantiate(_original);
            nuevoObjeto.SetActive(false);
            _poolQueue.Enqueue(nuevoObjeto.GetComponent<T>());
        }
    }

    // método para prestar objeto
    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        if(_poolQueue.Count == 0)
            return null;
        
        // obtener objeto a prestar desde el queue
        GameObject lendObject = _poolQueue.Dequeue().gameObject;

        lendObject.SetActive(true);
        lendObject.transform.position = position;
        lendObject.transform.rotation = rotation;
        return lendObject;

    }

    // método para recibir objeto de vuelta
    public void ReturnObject(T returnObject)
    {
        returnObject.gameObject.SetActive(false);
        _poolQueue.Enqueue(returnObject);

        //////
    }

}
