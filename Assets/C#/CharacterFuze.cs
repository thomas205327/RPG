using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFuze : Character
{
    void Awake()
    {
        Vector3 move = new Vector3(10f, 3.5f, 0);
        pos = move;
        moveDis = 30;
        hp = 100;
        hpMax = 100;
        sp = 50;
        spMax = 50;
        speed = 0;
        actionValue = 40;
        actionValueMax = 40;
        attackDis = 10;
        characterName = "Fuze";
        image = "Fuze";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        menuShow();
        //moveDisplay(moveDis);
    }
}
