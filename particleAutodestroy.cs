using UnityEngine;
//using System.Collections;

public class particleAutodestroy : MonoBehaviour {
    private ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        Destroy(gameObject, ps.duration);
    }
}
