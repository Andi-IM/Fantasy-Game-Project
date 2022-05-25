using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Andi_Scripts
{
    public class InventorySystem : MonoBehaviour
    {
        [Header("General Fields")] 
        // List of items picked up
        public List<GameObject> items = new List<GameObject>();
        // Flag indicates if the inventory is open or not
        public bool isOpen;

        [Header("UI items Section")]
        // Inventory System Window
        public GameObject ui_window;
        public Image[] items_image;

        [Header("UI Item Description")]
        public GameObject ui_Description_Window;
        public Image description_Image;
        public Text description_Title;
        public Text description_Text;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                ToggleInventory();
            }
        }

        void ToggleInventory()
        {
            isOpen = !isOpen;
            ui_window.SetActive(isOpen);
        }
        
        // Add the item to the items list
        public void PickUp(GameObject item)
        {
            items.Add(item);
            Update_UI();
        }
        
        // Refresh the UI elements in the inventory window
        void Update_UI()
        {
            HideAll();
            // For each item in the "items" list
            // Show it in the respective slot in the "items_images"
            for (int i = 0; i < items.Count; i++)
            {
                items_image[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
                items_image[i].gameObject.SetActive(true);
            }
        }
        
        // Hide all the items ui images
        void HideAll()
        {
            foreach (var image in items_image)
            {
                image.gameObject.SetActive(false);
            }

            HideDescription();
        }

        public void ShowDescription(int id)
        {
            // Set the Image
            description_Image.sprite = items_image[id].sprite;
            // Set the Title
            description_Title.text = items[id].name;
            // Show the Description
            description_Text.text = items[id].GetComponent<Item>().descriptionText;
            // Show the elements
            description_Image.gameObject.SetActive(true);
            description_Title.gameObject.SetActive(true);
            description_Text.gameObject.SetActive(true);
        }

        public void HideDescription()
        {
            description_Image.gameObject.SetActive(false);
            description_Title.gameObject.SetActive(false);
            description_Text.gameObject.SetActive(false);
        }

        public void Consume(int id)
        {
            if (items[id].GetComponent<Item>().type == Item.ItemType.Consumable)
            {
                Debug.Log($"CONSUMED {items[id].name}");
                // Invoke the consume custom event
                items[id].GetComponent<Item>().consumeEvent.Invoke();
                // Destroy the item in very tiny time
                Destroy(items[id], 0.1f);
                // Clear the item from the list
                items.RemoveAt(id);
                // Update UI
                Update_UI();
            }
        }
    }
}