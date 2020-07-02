﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasController : MonoBehaviour
{
    //public Character Obj1;
    public CharacterOrder characterOrder;
    public GameObject canvas;
    public GameObject move;
    public GameObject attack;
    public GameObject skill;
    public GameObject item;
    public GameObject end;
    public Image image;
    public static canvasController Instance;
    // Start is called before the first frame update

    void Start()
    {
        Instance = this;
        move.GetComponent<Button>().onClick.AddListener(moveOnclick);
        attack.GetComponent<Button>().onClick.AddListener(attackOnclick);
        skill.GetComponent<Button>().onClick.AddListener(skillOnclick);
        item.GetComponent<Button>().onClick.AddListener(itemOnclick);
        end.GetComponent<Button>().onClick.AddListener(endOnclick);
    }

    void Awake()
    {
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("white");
        //image = GetComponent<Image>();
        move.SetActive(false);
        attack.SetActive(false);
        skill.SetActive(false);
        item.SetActive(false);
        image.enabled = false;
        end.SetActive(false);
    }

    public void menuShow()
    {
        move.SetActive(true);
        attack.SetActive(true);
        skill.SetActive(true);
        item.SetActive(true);
        image.enabled = true;
        end.SetActive(true);
        //Debug.Log(Resources.Load<Sprite>(characterOrder.characters[0].image));
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>(characterOrder.characters[0].image);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveOnclick()
    {
        Debug.Log("移動");
        Character Obj1 = characterOrder.characters[0];
        Obj1.moveDisplay(Obj1.moveDis);
    }

    public void attackOnclick()
    {
        Debug.Log("攻擊");
        Character Obj1 = characterOrder.characters[0];
        Obj1.attackDisplay(Obj1.attackDis);
    }

    public void skillOnclick()
    {
        Debug.Log("技能");
        Character Obj1 = characterOrder.characters[0];
        Obj1.moveDisplay(Obj1.moveDis);
    }

    public void itemOnclick()
    {
        Debug.Log("道具");
        Character Obj1 = characterOrder.characters[0];
        Obj1.moveDisplay(Obj1.moveDis);
    }

    public void endOnclick()
    {
        Debug.Log("結束");
        Character Obj1 = characterOrder.characters[0];
        Obj1.clearDisplay();
        characterOrder.orderChange();
        move.SetActive(false);
        attack.SetActive(false);
        skill.SetActive(false);
        item.SetActive(false);
        image.enabled = false;
        end.SetActive(false);
    }
}