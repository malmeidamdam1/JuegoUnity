using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rbd2;
    float horizontal;
    float speed = 5f;
    float salto;
    float timerSalto;
    float alturaSalto = 1000f;
    bool saltando = false;
    Animator animator;
    bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive!");
        rbd2 = GetComponent<Rigidbody2D>();
        timerSalto = 0;
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", isRunning);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log("horizontal: " + horizontal);
        if (horizontal != 0)
        {
            isRunning = true;
            animator.SetBool("isRunning", isRunning);
        }
        else isRunning = false;
        animator.SetBool("isRunning", isRunning);


        Vector2 velocity = rbd2.velocity;
        velocity.x = horizontal * speed;
        rbd2.velocity = velocity;

        salto = Input.GetAxis("Jump");
        Debug.Log("Salto: " + salto);

        timerSalto -= Time.deltaTime;
        if (timerSalto <= 0 && salto == 1) {
            timerSalto = 3;
            rbd2.AddRelativeForce(new Vector2(0, salto*alturaSalto));
        }

        /*Alternativa
        if (saltando && salto == 1) {
            rbd2.AddRelativeForce(new Vector2(0, salto * alturaSalto));
            saltando = true;
        }
        */ 

    }

    public void setSaltando(bool saltando) {
            this.saltando = saltando;
      }

 }

