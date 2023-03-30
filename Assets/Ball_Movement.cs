using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Ball_Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float forceAmount = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody>();
        if (collision.gameObject.tag == "Player")
        {
            if (rb!=null) rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
        }
    }
}
