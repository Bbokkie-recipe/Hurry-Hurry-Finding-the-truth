using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public List<SlotTask> slots = new List<SlotTask>();
    private const int maxSlot = 5;
    public SlotTask slot_1;
    public SlotTask slot_2;
    public SlotTask slot_3;
    public SlotTask slot_4;
    public SlotTask slot_5;
    public KeyCode[] keyCodes;


    void Start()
    {
            slots.Add(slot_1);
            slots.Add(slot_2);
            slots.Add(slot_3);
            slots.Add(slot_4);
            slots.Add(slot_5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCodes[0]))
        {
            slot_1.UseItem();
            slots[0].isEmpty = true;
        }
        if (Input.GetKeyDown(keyCodes[1]))
        {
            slot_2.UseItem();
            slots[1].isEmpty = true;
        }
        if (Input.GetKeyDown(keyCodes[2]))
        {
            slot_3.UseItem();
            slots[2].isEmpty = true;
        }
        if (Input.GetKeyDown(keyCodes[3]))
        {
            slot_4.UseItem();
            slots[3].isEmpty = true;
        }
        if (Input.GetKeyDown(keyCodes[4]))
        {
            slot_5.UseItem();
            slots[4].isEmpty = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "runitem")
        {
            other.gameObject.SetActive(false);
            _AddItem();
        }
    }

    public void _AddItem()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].isEmpty)
            {
                slots[i].AddItem();
                i= slots.Count;
                break;
            }
        }
    }


}
