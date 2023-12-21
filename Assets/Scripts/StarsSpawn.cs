using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnRotationsEnemy;
    [SerializeField] private Transform _enemy;

    public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> starPrefabs = new List<GameObject>();

    public float minTime = 3f;
    public float maxTime = 10f;




    private void Start()
    {
        StartCoroutine(SpawnStars());
        

    }

    private void Repeat()
    {
        StartCoroutine(SpawnStars());

    }

    public IEnumerator SpawnStars()
    {

        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        var rotation = Quaternion.Euler(0, 0, -45);
        var prefab = starPrefabs[Random.Range(0, starPrefabs.Count)];

        var starSpawnPoint = GetRandomSpawnPoint();
        var star = Instantiate(prefab, starSpawnPoint.position, rotation);
        star.transform.parent = starSpawnPoint.transform;

        Repeat();
    }

    private Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }

    


}





