using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public GameObject[] Bombs;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool running;
    public Slider HealthSlider;
    int randBomb;
    private float time;
    private int StartTime;
    


    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitSpawner());

        running = true;

    }
    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);


    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (running)
        {      
            randBomb = Random.Range(0, 2);

            Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 4, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(Bombs[randBomb], spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            
            yield return new WaitForSeconds(spawnWait);

        }
    }
}
