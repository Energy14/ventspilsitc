﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropObject : MonoBehaviour
{
    public Image image;
    internal string itemName;
    private MainCanvas canvas;

    public Sprite sprite
    {
        set
        {
            if (itemName != "")
            {
                GameManager.instance.RemoveItem(itemName);
            }


            image.sprite = value;
        }
    }
    private void Awake()
    {
        canvas = GetComponentInParent<MainCanvas>();
    }

    public void OnDrop(BaseEventData bases)
    {
        canvas.OnDrop(this);
    }
    public void OnMouse(BaseEventData data)
    {
        if (((PointerEventData)data).button != PointerEventData.InputButton.Right)
        {
            return;
        }
        GameManager.instance.clearRecipe();
        sprite = null;
        GameManager.instance.buttonCollect.SetActive(false);

    }
}
