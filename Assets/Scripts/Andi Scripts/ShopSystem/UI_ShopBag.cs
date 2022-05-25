using UnityEngine;

public class UI_ShopBag : UI_Bag
{
    private UI_Shop uiShop;

    public void Init(UI_Shop uiShop)
    {
        this.uiShop = uiShop;
    }

    public override void Clean()
    {
        uiShop = null;
        base.Clean();
    }

    public override void OnBagSlotClicked(UI_BagSlot uiBagSlot)
    {
        uiShop.OnShopBagSlotClicked(uiBagSlot.item);
    }
}