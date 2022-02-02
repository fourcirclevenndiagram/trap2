using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();

            if(item.itemType == ItemType.Score)
            {
                SoundManager.instance.PlaySE("Score");
                // Debug.Log(item.extraScore + "를 획득했습니다.");
                ScoreManager.extraScore += item.extraScore;
            }
            Destroy(other.gameObject);
        }
    }

}
