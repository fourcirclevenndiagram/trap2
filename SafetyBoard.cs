using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyBoard : MonoBehaviour
{
    [SerializeField] float verticalDistance; // 수직 움직임
    [SerializeField] float horizontalDistance; // 수평 움직임
    [Range(0,1)]
    [SerializeField] float moveSpeed; // 움직일 스피드
    [SerializeField] int damage;

    Vector3 endPos1;
    Vector3 endPos2;
    Vector3 currentDestination;

    void Start()
    {
        Vector3 originPos = transform.position;
        endPos1.Set(originPos.x, originPos.y + verticalDistance, originPos.z + horizontalDistance);
        endPos2.Set(originPos.x, originPos.y - verticalDistance, originPos.z - horizontalDistance);
        currentDestination = endPos1;
    }
    void Update()
    {
        if((transform.position - endPos1).sqrMagnitude <= 0.1f) // 25
            currentDestination = endPos2;
        else if((transform.position - endPos2).sqrMagnitude <= 0.1f)
            currentDestination = endPos1;
        transform.position = Vector3.Lerp(transform.position, currentDestination, moveSpeed);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.name == "Player") // Hierarchy에서 취급하는 이름을 참조
        {
            other.transform.GetComponent<StatusManager>().DecreaseHp(damage);
            // other.transform.Translate(new Vector3(0, 0, 0)); // 지정된 좌표로 이동시키는 좌표라고 착각하여 이 함수를 사용했다.
            // other.transform.position(new Vector3(0, 0, 0));  // 상동

            other.transform.Rotate(new Vector3(10f, 20f, 10f) * Time.deltaTime);
        }
    }
}
