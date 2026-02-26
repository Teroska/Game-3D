using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private float screenBoundsX;
    private float screenBoundsY;

    void Start()
    {
        screenBoundsY = Camera.main.orthographicSize;
        screenBoundsX = screenBoundsY * Camera.main.aspect;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        float clampedX = Mathf.Clamp(transform.position.x, -screenBoundsX, screenBoundsX);
        float clampedY = Mathf.Clamp(transform.position.y, -screenBoundsY, screenBoundsY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        RotateTowardsMouse();
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; 

        Vector3 lookDirection = mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 0f);
    }
}