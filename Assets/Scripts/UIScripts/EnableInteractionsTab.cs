using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableInteractionsTab : MonoBehaviour
{
    private Inventory _inventory;
    private Color normalButtonColorHexadecimal = Color.red;
    public Texture2D _cursorIcon;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenInteractionTab()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<ItemInteraction>().interactionActive)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ItemInteraction>().interactionActive = false;
        }
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<ItemInteraction>().ActiveItemID != 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ItemInteraction>().ActiveItemID = 0;
        }
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<ItemInteraction>().CurrentItemSlot is not null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<ItemInteraction>().CurrentItemSlot = null;
        }

        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);

        CheckAndCloseIfAnyOpen();
        
        var parentSlot = transform.parent;
        var interactionTab = parentSlot.transform.GetChild(0);
        
        interactionTab.gameObject.SetActive(true);
        
        var itemReference = parentSlot.GetComponent<ItemReference>().currentItemReference;
        
        if(!itemReference.Usable)
        {
            var button = interactionTab.transform.GetChild(0).gameObject.GetComponent<Button>();
            button.interactable = false;
            button.image.color = Color.gray;
        }
        else
        {
            var button = interactionTab.transform.GetChild(0).gameObject.GetComponent<Button>();
            button.interactable = true;
            button.image.color = normalButtonColorHexadecimal;
        }
        
        if (!itemReference.Interactable)
        {
            var button = interactionTab.transform.GetChild(2).gameObject.GetComponent<Button>();
            button.interactable = false;
            button.image.color = Color.gray;
        }
        else
        {
            var button = interactionTab.transform.GetChild(2).gameObject.GetComponent<Button>();
            button.interactable = true;
            button.image.color = normalButtonColorHexadecimal;
        }
    }

    private void CheckAndCloseIfAnyOpen()
    {
        foreach(var slot in _inventory.slots)
        {
            var currentSlot = transform.parent;
            
            if(slot != currentSlot)
            {
                if(slot.transform.GetChild(0).gameObject.activeSelf)
                {
                    slot.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
