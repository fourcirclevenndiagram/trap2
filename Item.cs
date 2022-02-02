using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Score,
    Bullet,
}

public class Item : MonoBehaviour
{
    public ItemType itemType; // 아이템 유형

    public int extraScore; // 추가 점수

}
