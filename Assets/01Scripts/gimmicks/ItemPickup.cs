using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour, IInteractable
{
    [SerializeField]private string itemName = "ポーション";

    [SerializeField] private GameObject Players;
    PlayerManager playerManager;

    // インターフェースのルールに従ってInteractの中身を書く
    void Start()
    {
        if (Players == null)
        {
            Players = GameObject.Find("Players");
           
        }
         
            playerManager = Players.GetComponent<PlayerManager>();
    }
    public void Interact()
    {
        Debug.Log(itemName + " を拾った！");
        if(itemName == "ポーション")
        {
            PlayerHealth playerHealth;
            playerHealth=Players.GetComponent<PlayerHealth>();
            if (playerHealth.currentHP < 3)
            {
                playerHealth.currentHP+=1;
                //効果音入れる
            }
        }else if(itemName == "speed")
        {
            playerManager.moveSpeed=10f;
            playerManager.resetSpeed();
        }
        
        Destroy(gameObject); 
    }

   


}