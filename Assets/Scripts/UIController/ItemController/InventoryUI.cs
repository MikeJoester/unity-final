using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform itemsContainer;
    Inventory inventory;
    ItemSlot[] slots;

    public static InventoryUI ivUIinstance;

    private void Awake() {
        if (ivUIinstance == null) {
            ivUIinstance = this;
        }
    }

    void Start() {
        inventory = Inventory.invenInstance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsContainer.GetComponentsInChildren<ItemSlot>();
    }

    public void UpdateUI() {
        // Debug.Log("Updating UI!");
        for (int i = 0; i < slots.Length; i++) {
            if (i < inventory.itemList.Count) {
                slots[i].AddItem(inventory.itemList[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }
}
