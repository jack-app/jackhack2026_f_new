using UnityEngine;

public class flexiblevitamin21 : MonoBehaviour
{
    public float targetWidth = 5f;
    public float expandSpeed = 2f;
    private bool isExpanding = false;

    private Vector3 originalScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;        
    }

    // Update is called once per frame
    void Update()
    {
       float targetX = isExpanding ? targetWidth : originalScale.x;

       float newX = Mathf.Lerp(transform.localScale.x, targetX, Time.deltaTime * expandSpeed);

       transform.localScale = new Vector3(newX, originalScale.y, originalScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isExpanding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isExpanding = false;
        }
    }

}
