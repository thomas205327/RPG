﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKirito : Character
{

    void Awake()
    {
        Vector3 move = new Vector3(0, 3.5f, 0);
        pos = move;
        moveDis = 30;
        hp = 100;
        speed = 0;
        actionValue = 50;
        attackDis = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //characterController.SimpleMove(transform.forward * speed);
    }

    void OnMouseDown(){
        menuShow();
        //moveDisplay(moveDis);
    }
}
