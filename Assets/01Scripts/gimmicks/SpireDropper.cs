using UnityEngine;

public class SpireDropper : MonoBehaviour
{
    [SerializeField] float shootForce;
    public GameObject spirePrefab;
    DropperSwitch drSwitch;
    bool shooting;
    GameObject createSpirePrefab;
    public GameObject switchObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       drSwitch = switchObject.GetComponent<DropperSwitch>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(drSwitch.spireDrop == true)
        {
            createSpirePrefab = Instantiate(spirePrefab);
            createSpirePrefab.transform.position = this.transform.position;
            drSwitch.spireDrop = false;
            shooting = true;
        }
        if (shooting == true && createSpirePrefab != null)
        {
            createSpirePrefab.transform.Translate(Vector3.up * shootForce * Time.deltaTime);
        }
    }
}
