using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    private Rigidbody rb;
    public float boltSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * boltSpeed;
    }
}
