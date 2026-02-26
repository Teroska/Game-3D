using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public Transform player; 

    public float spawnRate = 3f;
    public float spawnRadius = 15f; 

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (player == null) return;

        if (Time.time >= nextSpawnTime)
        {
            SpawnMeteor();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnMeteor()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = player.position + new Vector3(randomCircle.x, randomCircle.y, 0) * spawnRadius;

        GameObject newMeteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);

        Meteor meteorScript = newMeteor.GetComponent<Meteor>();
        if (meteorScript != null)
        {
            meteorScript.SetTarget(player.position);
        }
    }
}