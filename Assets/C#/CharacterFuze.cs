using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFuze : Character
{
    void Awake()
    {
        Vector3 move = new Vector3(170f, 3.5f, 10f);
        pos = move;
        moveDis = 20;
        hp = 80;
        hpMax = 80;
        sp = 50;
        spMax = 50;
        speed = 0;
        actionValue = 40;
        actionValueMax = 40;
        attackDis = 20;
        characterName = "Fuze";
        image = "Fuze";
        moveLock = 0;
        STR = 20;
        INT = 10;
        DEF = 5;
        RES = 10;
        team = 0;
        GetComponent<Character>().damageFloatUp = GameObject.Find("damage");

        skillSP1 = 25;
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
    

    override
    public void skillDisplay()
    {
        skillDirection = 1;

        Instantiate(Resources.Load("FuzePlane"), new Vector3(pos.x + 10, 1f, pos.z), new Quaternion(0, 0, 0, 0));
        Instantiate(Resources.Load("FuzePlane"), new Vector3(pos.x - 10, 1f, pos.z), new Quaternion(0, 0, 0, 0));
        Instantiate(Resources.Load("FuzePlane"), new Vector3(pos.x, 1f, pos.z + 10), new Quaternion(0, 0, 0, 0));
        Instantiate(Resources.Load("FuzePlane"), new Vector3(pos.x, 1f, pos.z - 10), new Quaternion(0, 0, 0, 0));
    }

    override
    public void skillAttack()
    {
        int i;
        for (i = 0; i < GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters.Count; i++)
        {
            if (GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i].plane.GetComponent<MeshRenderer>().material.color == Color.red && GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i].team == 1)
            {
                Character Obj1 = GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i];
                Obj1.hp = Obj1.hp - (STR - Obj1.DEF);
                damageFloatUp.GetComponent<DamageFloatUp>().beAttack(Obj1, (STR - Obj1.DEF));

                if (Obj1.hp <= 0)
                {
                    GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters.Remove(Obj1);
                    Obj1.gameObject.SetActive(false);
                }

                GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().checkEnd();
            }
        }
        clearDisplay();
        GameObject.Find("Canvas").GetComponent<canvasController>().attack.GetComponent<Button>().interactable = false;
        GameObject.Find("Canvas").GetComponent<canvasController>().skill.GetComponent<Button>().interactable = false;

        sp = sp - skillSP1;
        canvasController.Instance.sp.GetComponent<Text>().text = sp + "/" + spMax;
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
