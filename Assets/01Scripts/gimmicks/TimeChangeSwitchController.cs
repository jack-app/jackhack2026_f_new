using UnityEngine;

public class TimeChangeSwitchController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("switchtouch");
        if (collision.gameObject.tag == "Player" ||collision.gameObject.tag == "Spire")
        {
            TimeChange tc = FindObjectOfType<TimeChange>();
            tc.ChangeTime();
        }
    }
}
