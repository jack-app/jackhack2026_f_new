using UnityEngine;

public class ButtonBehaviorvitamin21 : MonoBehaviour
{
    public MovingWallvitamin21 wall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            wall.SetMoveUp(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            wall.SetMoveUp(false);
        }
    }
}
