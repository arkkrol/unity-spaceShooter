using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {        
        this.score = 0;
        this.gameOver = this.restart = false;
        this.restartText.text = "";
        this.gameOverText.text = "";
        this.updateScore();
        StartCoroutine(this.spawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);                
            }
        }
    }
 
    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(this.startWait);
        while(true) { 
            for (int i = 0; i<hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-this.spawnValues.x, this.spawnValues.x), this.spawnValues.y, this.spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(this.hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(this.spawnWait);
                }
            yield return new WaitForSeconds(this.waveWait);

            if (this.gameOver)
            {
                this.restartText.text = "Press R for restart";
                this.restart = true;
                break;
            }
        }
    }

    private void updateScore()
    {
        this.scoreText.text = "Score: " + score;
    }

    public void addScore(int scoreValue)
    {
        score += scoreValue;
        this.updateScore();
    }

    public void isGameOver()
    {
        this.gameOver = true;
        this.gameOverText.text = "Game Over";
    }
}
