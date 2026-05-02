using UnityEngine;
using UnityEngine.UI;

public class lifeHyouji : MonoBehaviour
{
    [Header("操作キャラを取り付ける")]
    [SerializeField]private GameObject players;

    [Header("ライフを表示するオブジェクトを取り付ける")]
    [SerializeField] private GameObject[] Life;


    [Header("ハート")]
    [SerializeField] private Sprite[] Heart;
    Image image1;
    Image image2;
    Image image3;

    PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (players == null)
        {
            players=GameObject.Find("Players");
        }
        playerHealth=players.GetComponent<PlayerHealth>();
        image1=Life[0].GetComponent<Image>();
        image2=Life[1].GetComponent<Image>();
        image3=Life[2].GetComponent<Image>();
        

    }

    // Update is called once per frame
    void Update()
    {
        ChangeLifeHyouji();
    }
    public void ChangeLifeHyouji()
    {
        if (playerHealth.currentHP >= 3)
        {
            image1.sprite=Heart[0];
            image2.sprite=Heart[0];
            image3.sprite=Heart[0];
        }else if(playerHealth.currentHP == 2)
        {
            image1.sprite=Heart[0];
            image2.sprite=Heart[0];
            image3.sprite=Heart[1];      
        }else if (playerHealth.currentHP == 1)
        {
            image1.sprite=Heart[0];
            image2.sprite=Heart[1];
            image3.sprite=Heart[1]; 
        }
        else
        {
            image1.sprite=Heart[1];
            image2.sprite=Heart[1];
            image3.sprite=Heart[1]; 
        }
        
    }
}
