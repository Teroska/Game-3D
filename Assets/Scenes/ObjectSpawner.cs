using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float spawnRadius = 8f;

    void Start()
    {
        PrimitiveType[] typesToSpawn = {
            PrimitiveType.Cube,
            PrimitiveType.Sphere,
            PrimitiveType.Capsule,
            PrimitiveType.Cylinder
        };

        for (int i = 0; i < typesToSpawn.Length; i++)
        {
            GameObject newObj = GameObject.CreatePrimitive(typesToSpawn[i]);

            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnRadius, spawnRadius), 
                Random.Range(-spawnRadius, spawnRadius), 
                0f                                       
            );

            newObj.transform.position = randomPosition;

            MeshRenderer objRenderer = newObj.GetComponent<MeshRenderer>();
            if (objRenderer != null)
            {
                objRenderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}