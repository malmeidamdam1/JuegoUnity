using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCuerda : MonoBehaviour
{
    public float velocidadHorizontal = 2.0f;
    public float distanciaMaxima = 5.0f;
    public float velocidadDescenso = 2.0f;
    public float distanciaDescenso = 5.0f;

    private bool descendiendo = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
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
        }
        else
        {
            transform.position = startPosition;
            float movimiento = Mathf.PingPong(Time.time * velocidadHorizontal, distanciaMaxima * 2) - distanciaMaxima;
            transform.position = new Vector3(movimiento, transform.position.y, transform.position.z);

            if (Input.GetButtonDown("Fire1")) // Cambiar a la tecla que prefieras
            {
                descendiendo = true;
            }
        }
    }
}