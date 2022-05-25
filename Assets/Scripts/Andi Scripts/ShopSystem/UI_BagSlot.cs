using System.Collections;
using Andi_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_BagSlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public TextMeshProUGUI bottomText;

    private UI_Bag uiBag;
    [HideInInspector] public Item item;
    [HideInInspector] public Stack stack;

    public void Init(UI_Bag uiBag, Item item)
    {   
        this.uiBag = uiBag;
        this.item = item;
        UpdateVisual();
    }

    public void Init(UI_Bag uiBag, Stack stack)
    {
        this.uiBag = uiBag;
        this.stack = stack;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        if (stack != null)
        {
            icon.sprite = stack.item.icon;
            bottomText.SetText(stack.quantity > 0 ? stack.quantity.ToString("0") : "");
            bottomText.gameObject.SetActive(true);
            return;
        }

        icon.sprite = item.icon;
        bottomText.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        uiBag.OnBagSlotClicked(this);
    }
}