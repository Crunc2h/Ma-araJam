using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public int ActiveItemID { get; set; }
    public GameObject CurrentItemSlot;
    public bool interactionActive = false;    
}
