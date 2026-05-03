using UnityEngine;

public class Movevitamin21 : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;
    private bool isMoving = false;

    private Vector3 originalPos;
    private Vector3 targetPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPos = transform.localPosition;
        targetPos = originalPos + new Vector3(moveDistance, 0, 0);     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = isMoving ? targetPos : originalPos;

        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            target,
            Time.deltaTime * moveSpeed
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isMoving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isMoving = false;
        }
    }

}
