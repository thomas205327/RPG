using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMidoriya : Character
{
    int rotate = 0;
    int moveToX;
    int moveToZ;
    void Awake()
    {
        Vector3 move = new Vector3(-40f, 3.5f, 0);
        pos = move;
        moveDis = 20;
        hp = 60;
        hpMax = 60;
        sp = 50;
        spMax = 50;
        speed = 0;
        actionValue = 50;
        actionValueMax = 50;
        attackDis = 10;
        characterName = "綠谷";
        image = "4232";
        moveLock = 0;
        STR = 50;
        INT = 0;
        DEF = 0;
        RES = 0;
        team = 1;
        GetComponent<Character>().damageFloatUp = GameObject.Find("damage");
    }

    // Start is called before the first frame update
    void Start()
    {
        moveToX = (int)pos.x;
        moveToZ = (int)pos.z;
        planeSet();
    }

    override
    public void move(float x, float z)
    {
        speed = 0.2f;
        moveLock = 1;
        moveToX = (int)x;
        moveToZ = (int)z;
        GameObject.Find("Canvas").GetComponent<canvasController>().move.GetComponent<Button>().interactable = false;
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
                    //Debug.Log(" x: "+pos.x +"  z:  "+ pos.z);
                    //Debug.Log(" movex: " + moveToX + "   movez:  " + moveToZ);
                }
                break;
            case 2://移動x
                if (pos.x >= moveToX)
                {
                    //Debug.Log("x要減少");
                    if (pos.x <= moveToX)
                    {
                        moveLock = 3;
                        break;
                    }
                    transform.position += new Vector3(-1, 0, 0);
                    pos.x = pos.x - 1;
                }
                else
                {
                    if (pos.x >= moveToX)
                    {
                        moveLock = 3;
                        break;
                    }
                    //Debug.Log("x要增加");
                    transform.position += new Vector3(1, 0, 0);
                    pos.x = pos.x + 1;
                }
                break;
            case 3://轉向
                transform.Rotate(0, 3, 0);
                rotate = rotate + 3;
                if (rotate >= 90)
                {
                    moveLock = 4;
                    rotate = 0;
                    //Debug.Log(" x: " + pos.x + "  z:  " + pos.z);
                }
                break;
            case 4://移動z
                if (pos.z >= moveToZ)
                {
                    //Debug.Log("z要減少");
                    if (pos.z <= moveToZ)
                    {
                        moveLock = 0;
                        clearDisplay();                 //移動完清除藍色地板
                        break;
                    }
                    transform.position += new Vector3(0, 0, -1);
                    pos.z = pos.z - 1;
                }
                else
                {
                    if (pos.z >= moveToZ)
                    {
                        moveLock = 0;
                        clearDisplay();                 //移動完清除藍色地板
                        break;
                    }
                    //Debug.Log("z要增加");
                    transform.position += new Vector3(0, 0, 1);
                    pos.z = pos.z + 1;
                }
                break;
            case 5:
                planeSet();
                GameObject.Find("Main Camera").GetComponent<MainCamera>().CameraReturn();
                moveLock = 0;

                break;
        }
    }

    void OnMouseDown()
    {
        if (plane.GetComponent<MeshRenderer>().material.color == Color.red &&
            GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[0] != this)
        {
            Debug.Log("確定要攻擊敵人");
            GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[0].attack(this);
        }
        else
        {
            menuShow();
        }
    }
}
