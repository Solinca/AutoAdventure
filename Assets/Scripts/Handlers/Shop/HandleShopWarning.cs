using UnityEngine;

public class HandleShopWarning : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        DATA.SHOP.FailBuyingItem += OnFailBuyingItem;
    }

    private void OnDestroy()
    {
        DATA.SHOP.FailBuyingItem -= OnFailBuyingItem;
    }

    private void OnFailBuyingItem()
    {
        animator.SetTrigger("TriggerFade");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
