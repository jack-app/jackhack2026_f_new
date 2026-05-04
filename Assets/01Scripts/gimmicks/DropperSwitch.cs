using UnityEngine;

public class DropperSwitch : MonoBehaviour
{
    public bool spireDrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
        spireDrop = true;
        Debug.Log("touch");
        }
        
    }
}
