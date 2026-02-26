using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public Color idleColor = new Color(1f, 0f, 0f);
    public Color movingColor = new Color(0f, 1f, 0f);

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = idleColor;
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.down;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

        moveDirection.Normalize();

        transform.position += moveDirection * speed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            meshRenderer.material.color = movingColor;
        }
        else
        {
            meshRenderer.material.color = idleColor;
        }
    }
}