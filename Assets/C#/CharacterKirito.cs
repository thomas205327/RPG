using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterKirito : Character
{
    int rotate = 0;
    int moveToX;
    int moveToZ;
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

    // Update is called once per frame
    void Update()
    {
        if (skillDirection == 1)
        {
            if ((Camera.main.ScreenToViewportPoint(Input.mousePosition).x + Camera.main.ScreenToViewportPoint(Input.mousePosition).y) - 1 > 0
                && (Camera.main.ScreenToViewportPoint(Input.mousePosition).x - Camera.main.ScreenToViewportPoint(Input.mousePosition).y) < 0)
            {
                clearDisplay();
                GameObject[] planes;
                planes = GameObject.FindGameObjectsWithTag("MovePlane");
                //GameObject redPlanes[8];

                int i;
                for (i = 0; i < planes.Length; i++)
                {
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                        //redPlanes[0] = planes[i];
                    }
                }
            }
            else if ((Camera.main.ScreenToViewportPoint(Input.mousePosition).x + Camera.main.ScreenToViewportPoint(Input.mousePosition).y) - 1 > 0
                && (Camera.main.ScreenToViewportPoint(Input.mousePosition).x - Camera.main.ScreenToViewportPoint(Input.mousePosition).y) > 0)
            {
                clearDisplay();
                GameObject[] planes;
                planes = GameObject.FindGameObjectsWithTag("MovePlane");
                //GameObject redPlanes[8];

                int i;
                for (i = 0; i < planes.Length; i++)
                {
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                        //redPlanes[0] = planes[i];
                    }
                }
            }
            else if ((Camera.main.ScreenToViewportPoint(Input.mousePosition).x + Camera.main.ScreenToViewportPoint(Input.mousePosition).y) - 1 < 0
                && (Camera.main.ScreenToViewportPoint(Input.mousePosition).x - Camera.main.ScreenToViewportPoint(Input.mousePosition).y) < 0)
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
                }
            }
            else if ((Camera.main.ScreenToViewportPoint(Input.mousePosition).x + Camera.main.ScreenToViewportPoint(Input.mousePosition).y) - 1 < 0
                && (Camera.main.ScreenToViewportPoint(Input.mousePosition).x - Camera.main.ScreenToViewportPoint(Input.mousePosition).y) > 0)
            {
                clearDisplay();
                GameObject[] planes;
                planes = GameObject.FindGameObjectsWithTag("MovePlane");

                int i;
                for (i = 0; i < planes.Length; i++)
                {
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("停止偵測");
            skillDirection = 0;
        }

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
                        moveLock = 5;
                        clearDisplay();                 //移動完清除藍色地板
                        //GameObject.Find("Canvas").GetComponent<canvasController>().move.GetComponent<Button>().interactable = false;
                        break;
                    }
                    transform.position += new Vector3(0, 0, -1);
                    pos.z = pos.z - 1;
                }
                else
                {
                    if (pos.z >= moveToZ)
                    {
                        moveLock = 5;
                        clearDisplay();                 //移動完清除藍色地板
                        //GameObject.Find("Canvas").GetComponent<canvasController>().move.GetComponent<Button>().interactable = false;
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

    override
    public void skillDisplay()
    {
        skillDirection = 1;
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
