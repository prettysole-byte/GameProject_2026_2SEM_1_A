using GLTFast.Schema;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupAnimation : MonoBehaviour
{
    private IEnumerator = PickupAnimation()
    {
        isPickingUp = true;

        PickupItem itemToCollect = targetItem;

        Vector3 itemDirection = itemToCollect.transform.position - transform.position;
        itemDirection.y = 0;

        if (itemDirection.sqrMagnitude > 0.0001f)
        {
           transform.rotation = Quaternion.LookRotation(itemDirection);
        }

        PlayerController.ChangeState(PlayerState.Pickup);
        animator.CrossFade("Pickup01", 0.1f);
        yield return new WaitForSeconds(pickupMoment)

            if (itemToCollect != null)
        {
            itemToCollect.Collect();
        }

        yield return new WaitForSeconds(pickupDuration - pickupMoment);

        animator.CrossFade("Blend Tree", 0.1f);

        playerController.ChangeState(PlayerState.Normal);

        targetItem = null;
        isPickingUp = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickingUp) return;

        //Player 주변에서 가장 가까운 아이템을 찾는다.
        targetItem = FindClosestItem();

        if (targetItem == null) return;

        Keyboard keyboard = Keyboard.current;

        if (keyboard == null) return;

        //가까운 아이템이 있을 때 E키로 줍는다.
        if (keyboard.eKey.wasPressedThisFrame)
        {
            StartCoroutine(PickupAnimation());
        }
    }
}
