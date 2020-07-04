using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKirito : Character
{
    int rotate = 0;
    int moveToDis = 0;
    int moveToX;
    int moveToZ;
    void Awake()
    {
        Vector3 move = new Vector3(0, 3.5f, 0);
        pos = move;
        moveDis = 30;
        hp = 100;
        hpMax = 100;
        sp = 50;
        spMax = 50;
        speed = 0;
        actionValue = 50;
        actionValueMax = 50;
        attackDis = 10;
        characterName = "桐人";
        image = "Sword Art Online II - 20[01-32-37]";
        moveLock = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        moveToX = (int)pos.x;
        moveToZ = (int)pos.z;
    }

    override
    public void move(float x, float z)
    {
        speed = 0.2f;
        moveLock = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveLock)
        {
            case 1://轉向
                transform.Rotate(0, 3, 0);
                rotate = rotate + 3;
                if (rotate >= 90)
                {
                    moveLock = 2;
                    rotate = 0;
                }
                break;
            case 2://移動
                transform.Translate(1, 0, 0);
                moveToDis = moveToDis + 1;
                if (pos.x >= moveToX)
                {
                    moveLock = 3;
                    moveToDis = 0;
                }
                break;
            case 3://轉向
                transform.Rotate(0, 3, 0);
                rotate = rotate + 3;
                if (rotate >= 90)
                {
                    moveLock = 4;
                    rotate = 0;
                }
                break;
            case 4://移動
                transform.Translate(0, 0, 1);
                moveToDis = moveToDis + 1;
                if (pos.z >= moveToZ)
                {
                    moveLock = 0;
                    moveToDis = 0;
                }
                break;
        }
    }

    void OnMouseDown(){
        menuShow();
        //moveDisplay(moveDis);
    }
}
