using System;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Andi_Scripts
{
    public class Item : MonoBehaviour
    {
        public enum InteractionType { NONE, PickUp, Examine, GrabDrop }
        public enum ItemType{ Static, Consumable }

        [Header("Attributes")] 
        public InteractionType interactType;
        public ItemType type;
        
        [Header("Indicator")] 
        public GameObject indicator;
        public GameObject window;

        [Header("Type")] 
        public Sprite icon;
        public string nickname;
        public double cost;
        public string descriptionText;

        [Header("Custom Event")] 
        public UnityEvent customEvent;
        public UnityEvent consumeEvent;
        
        private void Awake()
        {
            ToggleIndicator(false);
            ToggleWindow(false);
        }

        public static int GetCost(ItemType type)
        {
            switch (type)
            {
                default:
                case ItemType.Static: return 0;
                case ItemType.Consumable: return 1;
            }
        }

        public static Sprite GetSprite(ItemType type)
        {
            switch (type)
            {
                default:
                case ItemType.Static: return GameAssets.i.s_static;
                case ItemType.Consumable: return GameAssets.i.s_consumable;
            }
            ;
        }

        private void Reset()
        {
            GetComponent<Collider2D>().isTrigger = true;
            gameObject.layer = 10;
        }

        public void Interact()
        {
            switch (interactType)
            {
                case InteractionType.PickUp:
                    // Add the object to the PickedUUpItems list
                    FindObjectOfType<InventorySystem>().PickUp(gameObject);
                    // Disable
                    gameObject.SetActive(false);
                    break;
                case InteractionType.Examine:
                    // Call the Examine item in the interaction system
                    FindObjectOfType<InteractionSystem>().ExamineItem(this);
                    break;
                case InteractionType.GrabDrop:
                    // Grab interaction
                    FindObjectOfType<InteractionSystem>().GrabDrop();
                    break;
                default:
                    Debug.Log("NULL ITEM");
                    break;
            }
            
            // Invoke (call) the custom event(s)
            customEvent.Invoke();
        }

        private void ToggleWindow(bool show)
        {
            window.SetActive(show);
        }

        public void ToggleIndicator(bool show)
        {
            indicator.SetActive(show);
        }
        
        
    }
}