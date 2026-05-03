using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("背景の画像")]
    [Tooltip("現在")]
    [SerializeField] private GameObject Current;
    [Tooltip("過去")]
    [SerializeField] private GameObject Past;
    private bool IsCurrentChecker=false;
    void Start()
    {

        Instantiate(Current, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity, this.transform);
        if(GameStatusManager.Instance.runtimeStatus.isCurrent == true)
        {
            IsCurrentChecker=true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameStatusManager.Instance.runtimeStatus.isCurrent == true)
        {
            if (IsCurrentChecker != true)
            {
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    Transform child = transform.GetChild(i);
                    Destroy(child.gameObject); 
                }
                Instantiate(Current, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity, this.transform);
            }
            IsCurrentChecker=true;
        }
        else
        {
            if (IsCurrentChecker != false)
            {
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    Transform child = transform.GetChild(i);
                    Destroy(child.gameObject); 
                }
                Instantiate(Past, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity, this.transform);
            }
            IsCurrentChecker=false;
        }

        
    }
}
