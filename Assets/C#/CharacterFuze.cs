using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterFuze : Character
{
    int rotate = 0;
    int moveToX;
    int moveToZ;
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
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
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
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
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
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x -10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                        //redPlanes[0] = planes[i];
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 20) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z + 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                }
            }
            else if ((Camera.main.ScreenToViewportPoint(Input.mousePosition).x + Camera.main.ScreenToViewportPoint(Input.mousePosition).y) - 1 < 0
                && (Camera.main.ScreenToViewportPoint(Input.mousePosition).x - Camera.main.ScreenToViewportPoint(Input.mousePosition).y) > 0)
            {
                clearDisplay();
                GameObject[] planes;
                planes = GameObject.FindGameObjectsWithTag("MovePlane");
                //GameObject redPlanes[8];

                int i;
                for (i = 0; i < planes.Length; i++)
                {
                    if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                        //redPlanes[0] = planes[i];
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 10))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x - 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 20))
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                    else if (Mathf.Round(planes[i].transform.position.x) == Mathf.Round(pos.x + 10) && Mathf.Round(planes[i].transform.position.z) == Mathf.Round(pos.z - 20))
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
            case 1://移動x
                if (pos.x >= moveToX)
                {
                    //Debug.Log("x要減少");
                    if (pos.x <= moveToX)
                    {
                        moveLock = 2;
                        break;
                    }
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                    transform.position += new Vector3(-1, 0, 0);
                    pos.x = pos.x - 1;
                }
                else
                {
                    if (pos.x >= moveToX)
                    {
                        moveLock = 2;
                        break;
                    }
                    //Debug.Log("x要增加");
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    transform.position += new Vector3(1, 0, 0);
                    pos.x = pos.x + 1;
                }
                break;
            case 2://移動z
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
                    transform.rotation = Quaternion.Euler(0, 180, 0);
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
                    transform.rotation = Quaternion.Euler(0, 0, 0);
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
