using System.Collections;
using System.Collections.Generic;
using Andi_Scripts;
using UnityEngine;

public class UI_Bag : MonoBehaviour
{
    public GameObject slotPrefab;

    public virtual void Clean()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddItems(Item[] items)
    {
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }

    public void AddItem(Item item)
    {
        AddSlot(item);
    }

    private void AddSlot(Item item)
    {
        GameObject bagSlot = Instantiate(slotPrefab, transform);
        UI_BagSlot uiBagSlot = bagSlot.GetComponent<UI_BagSlot>();

        uiBagSlot.Init(this, item);
    }

    public void AddStacks(Stack[] stacks)
    {
        foreach (Stack stack in stacks)
        {
            AddStack(stack);
        }
    }

    public void AddStack(Stack stack)
    {
        AddSlot(stack);
    }

    private void AddSlot(Stack stack)
    {
        GameObject bagSlot = Instantiate(slotPrefab, transform);
        UI_BagSlot uiBagSlot = bagSlot.GetComponent<UI_BagSlot>();

        uiBagSlot.Init(this, stack);
    }

    public virtual void OnBagSlotClicked(UI_BagSlot uiBagSlot)
    {
    }
}