using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterKirito : Character
{
    void Awake()
    {
        Vector3 move = new Vector3(170f, 3.5f, -10f);
        pos = move;
        moveDis = 40;
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
        STR = 30;
        INT = 10;
        DEF = 10;
        RES = 10;
        team = 0;
        GetComponent<Character>().damageFloatUp = GameObject.Find("damage");

        skillSP1 = 50;
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

    override
    public void skillDisplay()
    {
        skillDirection = 1;

        Instantiate(Resources.Load("KiritoPlane"), new Vector3(pos.x + 10, 1f, pos.z), new Quaternion(0, 0, 0, 0));
        Instantiate(Resources.Load("KiritoPlane"), new Vector3(pos.x - 10, 1f, pos.z), new Quaternion(0, 0, 0, 0));
        Instantiate(Resources.Load("KiritoPlane"), new Vector3(pos.x, 1f, pos.z + 10), new Quaternion(0, 0, 0, 0));
        Instantiate(Resources.Load("KiritoPlane"), new Vector3(pos.x, 1f, pos.z - 10), new Quaternion(0, 0, 0, 0));
    }

    override
    public void skillAttack()
    {
        int i;
        int j;
        for (i = 0; i < GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters.Count; i++)
        {
            if (GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i].plane.GetComponent<MeshRenderer>().material.color == Color.red && GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i].team == 1)
            {
                Character Obj1 = GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i];
                System.Random crandom = new System.Random();
                for (j = 0; j < 16; j++)
                {
                    int a = crandom.Next(1,3);
                    Obj1.hp = Obj1.hp - a;
                    damageFloatUp.GetComponent<DamageFloatUp>().beAttack(Obj1, a);
                }
                clearDisplay();
                GameObject.Find("Canvas").GetComponent<canvasController>().attack.GetComponent<Button>().interactable = false;
                GameObject.Find("Canvas").GetComponent<canvasController>().skill.GetComponent<Button>().interactable = false;
                if (Obj1.hp <= 0)
                {
                    GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters.Remove(Obj1);
                    Obj1.gameObject.SetActive(false);
                }

                GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().checkEnd();
                break;
            }
        }
        sp = sp - skillSP1;
        canvasController.Instance.sp.GetComponent<Text>().text = sp + "/" + spMax;
    }

    void OnMouseDown(){
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
