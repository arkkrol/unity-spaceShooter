using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

[System.Serializable]
public class TiltLimits
{
    public float tiltX;
}

[System.Serializable]
public class FireSettings {
    public float fireRate;
}


public class PlayerController : MonoBehaviour
{
    public Boundary boundary;
    public TiltLimits tiltLimits;
    public FireSettings fireSettings;

    public float speed;
    public GameObject shot;
    public Transform shotSpawn;

    private Rigidbody rb;
    private AudioSource audioSource;
    private float nextFire;
    



    void Start()
    {
        //SceneManager.LoadScene(2);
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > this.nextFire)
        {
            this.nextFire = Time.time + fireSettings.fireRate;
            Instantiate(this.shot, this.shotSpawn.position, this.shotSpawn.rotation );
            audioSource.Play();
        }

    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * this.speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * tiltLimits.tiltX);
    }
}
