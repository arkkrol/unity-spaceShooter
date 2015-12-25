using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine(this.spawnWaves());
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
        }
    }
}
