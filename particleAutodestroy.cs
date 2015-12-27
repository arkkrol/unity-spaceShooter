using UnityEngine;
//using System.Collections;

public class ParticleAutodestroy : MonoBehaviour {
    private ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        Destroy(gameObject, ps.duration);
    }
}
