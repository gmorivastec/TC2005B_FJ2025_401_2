using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(
            horizontal * Time.deltaTime * _speed,
            vertical * Time.deltaTime * _speed,
            0
        );    
    }
}
