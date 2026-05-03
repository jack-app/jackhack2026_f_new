using UnityEngine;

public class MovingWallvitamin21 : MonoBehaviour
{
    public float moveDistance = 3f;
    public float movingSpeed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isMovingUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.localPosition;
        targetPos = startPos - new Vector3(0, moveDistance, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = isMovingUp ? targetPos : startPos;

        transform.localPosition = Vector3.MoveTowards(
            transform.localPosition,
            target,
            Time.deltaTime * movingSpeed
        );
    }

    public void SetMoveUp(bool value)
    {
        isMovingUp = value;
    }
}
