using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 2f; 
    private Vector3 targetDirection;
    public float lifeTime = 40f; 

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetTarget(Vector3 playerPosition)
    {
        targetDirection = (playerPosition - transform.position).normalized;
    }

    void Update()
    {
        transform.position += targetDirection * speed * Time.deltaTime;

        transform.Rotate(0, 0, 50f * Time.deltaTime);
    }
}