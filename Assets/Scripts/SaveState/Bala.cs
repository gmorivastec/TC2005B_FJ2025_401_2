using System.Collections;
using UnityEngine;

public class Bala : MonoBehaviour
{

    [SerializeField]
    private float _speed = 7;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
    {
        // pseudodestrucción
        // al igual que el caso de instanciar / destruir
        // con el pool hay que tener estrategias para regresar los objetos prestados

        StartCoroutine(RegresarAlPool(5));
    }

    void OnDisable()
    {
        StopAllCoroutines();


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            0,
            _speed * Time.deltaTime,
            0
        );
    }

    IEnumerator RegresarAlPool(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        BalaPoolManager.Instance.ReturnObject(this);
    }
}
