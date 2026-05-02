using UnityEngine;

public class FIreTImer : MonoBehaviour
{
    public GameObject firePrefab;
    [SerializeField] float fireTimerStart;
    float fireTimer;
    bool fireSwitch;
    GameObject createFirePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        createFirePrefab = Instantiate(firePrefab);
        fireTimer = fireTimerStart;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer < 0 && fireSwitch == false)
        {
            fireTimer = fireTimerStart;   
            Destroy(createFirePrefab);   
            fireSwitch = true;     
        }
        if (fireTimer < 0 && fireSwitch == true)
        {
            fireTimer = fireTimerStart;
            createFirePrefab = Instantiate(firePrefab);
            firePrefab.transform.position = this.transform.position;
            fireSwitch = false;
        }
    }
}
