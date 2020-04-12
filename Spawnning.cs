using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnning : MonoBehaviour
{
    public GameObject[] VisualRes;
    public Vector3 spawnValues;
    public float spawnTime;
    public float spawnMaxTime;
    public float spawnMinTime;
    public int startTime;
    public int VisualResLimit = 10;
    public bool stopSpawn;

    int randVisualRes;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = Random.Range(spawnMinTime, spawnMaxTime);
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startTime);
        int objectsSpawned = 0;
        while (objectsSpawned < VisualResLimit)
        {
            randVisualRes = Random.Range(0, 11);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(VisualRes[randVisualRes], spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            objectsSpawned++;

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
