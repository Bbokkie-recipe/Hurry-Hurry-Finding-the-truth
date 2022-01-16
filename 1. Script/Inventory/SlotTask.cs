using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotTask : MonoBehaviour
{
    yumiRun yumiRunSc;
    public bool isEmpty;
    InventoryScript inventory;
    public int num;
    public Transform ImgChild;
    Image curItem;

    /*바뀌어질 아이템 이미지*/
    public Sprite accelItem;
    public Sprite randItem;
    public Sprite heartitem;
    public Sprite shieldItem;
    public Sprite fireworkItem;
    
    /*null 상태 이미지*/
    public Sprite nullimg;

    Sprite getItem;

    /*아이템 사용 상태*/
    public bool accelState = false;
    public bool randState = false;
    public bool heartState = false;
    public bool shieldState = false;
    public bool fireworkState = false;


    private void Start()
    {
        yumiRunSc= GameObject.Find("Yumi").GetComponent<yumiRun>();
        curItem = ImgChild.GetComponent<Image>();
        SetColor(0);
        isEmpty = true;
        inventory = GameObject.Find("Yumi").GetComponent<InventoryScript>();
    }

    private void SetColor(float _alpha)
    {
        Color color = curItem.color;
        color.a = _alpha;
        curItem.color = color;
    }

    public void AddItem()
    {
        RandGetItem();
        curItem.sprite = getItem;
        SetColor(1);
        isEmpty = false;
    }

    public void UseItem()
    {
        if (curItem.sprite == accelItem)
        {
            accelState = true;
            yumiRunSc.Accel();
            Invoke("StateReset", 0.5f);
        }

        if (curItem.sprite == randItem)
        {
            int stateIndex = Random.Range(0, 4);
            switch (stateIndex)
            {
                case 0:
                    accelState = true;
                    yumiRunSc.Accel();
                    Invoke("StateReset", 0.5f);
                    break;
                case 1:
                    heartState = true;
                    yumiRunSc.HeartUp();
                    Invoke("StateReset", 0.1f);
                    break;
                case 2:
                    shieldState = true;
                    yumiRunSc.Shielding();
                    Invoke("StateReset", 3f);
                    break;
                case 3:
                    fireworkState = true;
                    yumiRunSc.Firework();
                    break;
            }
        }

        if (curItem.sprite == heartitem)
        {
            yumiRunSc.HeartUp();
            Invoke("StateReset", 0.1f);
            heartState = true;
        }

        if (curItem.sprite == shieldItem)
        {
            yumiRunSc.Shielding();
            shieldState = true;
            Invoke("StateReset", 3f);
        }

        if (curItem.sprite == fireworkItem)
        {
            fireworkState = true;
            yumiRunSc.Firework();
        }

        SetColor(0);
        curItem.sprite = nullimg;
        isEmpty = true;
    }

    private void StateReset()
    {
        accelState = false;
        heartState = false;
        shieldState = false;
        fireworkState = false;
    }

    private void RandGetItem()
    {
        int itemIndex = Random.Range(0, 5);

        switch (itemIndex)
        {
            case 0:
                getItem = accelItem;
                break;
            case 1:
                getItem = randItem;
                break;
            case 2:
                getItem = heartitem;
                break;
            case 3:
                getItem = shieldItem;
                break;
            case 4:
                getItem = fireworkItem;
                break;
        }
    }

}

//num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));
