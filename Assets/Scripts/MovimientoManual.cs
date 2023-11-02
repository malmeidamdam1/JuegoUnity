using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 2.0f;
    public bool descendiendo = false;

    public float velocidadHorizontal = 2.0f;
    public float distanciaMaxima = 5.0f;
    public float velocidadDescenso = 2.0f;
    public float distanciaDescenso = 5.0f;

    private Vector3 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0) * velocidad * Time.deltaTime;

        transform.Translate(movimiento);


        if (descendiendo)
        {
            // Mueve hacia abajo si está descendiendo
            float newY = Mathf.Max(transform.position.y - (velocidadDescenso * Time.deltaTime), startPosition.y - distanciaDescenso);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Si llega al punto de descenso, cambia de dirección
            if (transform.position.y <= startPosition.y - distanciaDescenso)
            {
                descendiendo = false;
            }
            else
            {
                if (Input.GetButtonDown("Fire1")) // Cambiar a la tecla que prefieras
                {
                    descendiendo = true;
                }
            }



        }
    }

}
