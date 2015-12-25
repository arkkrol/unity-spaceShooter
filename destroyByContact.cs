using UnityEngine;
using System.Collections;

public class destroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private ParticleSystem ps;

    private void destroy(Collider collider)
    {
        Destroy(collider.gameObject);
        Destroy(this.gameObject);
        Instantiate(this.explosion, transform.position, transform.rotation);
        //Destroy(this.explosion, GetComponent<ParticleSystem>().duration);
    }

    public void Start()
    {     
        ps = GetComponent<ParticleSystem>();
    
    }

    void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case ("boundary"):               
                break;
            case ("Player"):
                this.destroy(other);
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                break;
            default:
                this.destroy(other);
                break;
        }
       
    }
}
