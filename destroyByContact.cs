using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController; 

    public void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            this.gameController = gameControllerObject.GetComponent<GameController>();
        } else
        {
            Debug.Log("nie znalazlem obiektu gamecontroller");
        }
    }

    private void addScore()
    {
        gameController.addScore(this.scoreValue);
    }

    private void destroy(Collider collider)
    {
        Destroy(collider.gameObject);
        Destroy(this.gameObject);
        Instantiate(this.explosion, transform.position, transform.rotation);
        //Destroy(this.explosion, GetComponent<ParticleSystem>().duration);
    }
  

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case ("boundary"):               
                break;
            case ("Player"):                
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.isGameOver();
                this.destroy(other);
                break;
            default:
                gameController.addScore(this.scoreValue);                               
                this.destroy(other);                
                break;
        }
       
    }
}
