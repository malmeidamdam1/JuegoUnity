using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D: " + collision.name);

        //if(collision.name = "terrain")
        GameObject go = GameObject.Find("Player");
        Player playerScript = go.GetComponent<Player>();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject go = GameObject.Find("Player");
        Player playerScript = go.GetComponent<Player>();
        playerScript.setSaltando(false);
    }

}
