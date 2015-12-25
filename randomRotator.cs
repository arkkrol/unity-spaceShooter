using UnityEngine;
using System.Collections;

public class randomRotator : MonoBehaviour {

    public float tumble;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }

	void Update () {
	
	}
}
