using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterYuzio : Character
{
    void Awake()
    {
        Vector3 move = new Vector3(170f, 3.5f, 0);
        pos = move;
        moveDis = 30;
        hp = 120;
        hpMax = 120;
        sp = 50;
        spMax = 50;
        speed = 0;
        actionValue = 50;
        actionValueMax = 50;
        attackDis = 10;
        characterName = "尤吉歐";
        image = "maxresdefault";
        moveLock = 0;
        STR = 25;
        INT = 0;
        DEF = 10;
        RES = 0;
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

    override
    public void skillDisplay()
    {
        clearDisplay();
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("MovePlane");
        //GameObject redPlanes[8];

        int i;
        for (i = 0; i < planes.Length; i++)
        {
            if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z))
            {
                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                //redPlanes[0] = planes[i];
            }
            else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
            {
                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
            else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
            {
                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
            else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
            {
                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
            else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
            {
                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
            else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
            {
                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
            else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z))
            {
                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
            else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
            {
                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
        }

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
