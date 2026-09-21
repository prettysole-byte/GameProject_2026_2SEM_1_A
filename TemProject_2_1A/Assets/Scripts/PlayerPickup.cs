using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerPickup : MonoBehaviour
{
    [Header("직접 연결")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;

    [Header("아이템 탐색")]
    [SerializeField] private float detectionRadius = 2f;

    [Header("줍기 모션")]
    [SerializeField] private float pickupDuration = 1.2f;
    [SerializeField] private float pickupMoment = 0.55f;

    private PickupItem targetItem;
    private bool isPickingUp;

private PickupItem FindClosestItem()
{
    Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, ~0, QueryTriggerInteraction.Collide); //구체의 충돌체를 만든다.
    PickupItem closestItem = null;
    float closestDistance = Mathf.Infinity;

    foreach(Collider itemCollider in colliders)            //충돌 구체에 들어온 모든것을 검사
    {
        PickupItem item = itemCollider.GetComponentInParent<PickupItem>();        //컴포넌트가 PickupItem을 검사

        if (item == null) continue;

        float distance = Vector3.Distance(transform.position, item.transform.position);

        if (distance < closestDistance)
        {
            closestDistance = distance;
            closestItem = item;
        }
    }
    return closestItem;
}
}
