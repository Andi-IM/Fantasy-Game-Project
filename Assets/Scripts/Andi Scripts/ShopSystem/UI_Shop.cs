using Andi_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    [Header("Header")] public TextMeshProUGUI uiHeaderText;
    
    [Header("Bag")] public UI_ShopBag uiShopBag;
    
    [Header("Trade")]
    public TextMeshProUGUI uiTradeName;
    public TextMeshProUGUI uiTradeDescription;
    public TextMeshProUGUI uiTradeBuyText;
    public Transform uiTradeBuyButton;
    
    public void Open(string headerText, Item[] items)
    {
        gameObject.SetActive(true);

        uiShopBag.Clean();
        uiShopBag.Init(this);
        uiShopBag.AddItems(items);

        uiHeaderText.SetText(headerText);

        OnShopBagSlotClicked(items[0]);
    }
    
    public void Close()
    {
        uiShopBag.Clean();
        gameObject.SetActive(false);
    }

    public void OnShopBagSlotClicked(Item item)
    {
        uiTradeName.SetText(item.nickname);
        uiTradeDescription.SetText(item.descriptionText);
        uiTradeBuyText.SetText("$" + item.cost.ToString("0"));

        Button buyButton = uiTradeBuyButton.GetComponent<Button>();
        buyButton.onClick.RemoveAllListeners();
        buyButton.GetComponent<Button>().onClick.AddListener(delegate () { OnBuyClicked(item); });
    }

    public void OnBuyClicked(Item item)
    {
        //Inventory.instance.BuyItem(item);
    }
}
