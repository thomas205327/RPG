using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class Character : MonoBehaviour
{
    public Vector3 pos;                     //角色位置
    public int moveDis;                     //移動距離  
    public int hp;                          //角色現在HP
    public int hpMax;                       //角色Max Hp        儲存用
    public int sp;                          //角色魔力
    public int spMax;                       //角色Max 魔力      儲存用
    public int STR;                         //物理攻擊力
    public int INT;                         //魔法攻擊力
    public int DEF;                         //物防
    public int RES;                         //魔防
    public float speed;                     //角色移動速度(用於移動動畫)
    public int actionValue;                 //角色行動順序數值
    public int actionValueMax;              //角色行動順序數值  儲存用
    public int attackDis;                   //角色攻擊距離
    public string characterName;            //角色名字
    public string image;                    //角色圖片
    public int moveLock;
    public GameObject plane;
    public GameObject damageFloatUp;
    public int team;                        //隊伍


    public virtual void planeSet()
    {
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("MovePlane");
        int i;
        for (i = 0; i < planes.Length; i++)
        {
            if (Mathf.Round(planes[i].GetComponent<Transform>().position.x) == Mathf.Round(pos.x) && Mathf.Round(planes[i].GetComponent<Transform>().position.z) == Mathf.Round(pos.z))
            {
                this.GetComponent<Character>().plane = planes[i];
                break;
            }
        }
    }

    public virtual void moveDisplay(float dis){
        clearDisplay();
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("MovePlane");

        GameObject[] stones;
        stones = GameObject.FindGameObjectsWithTag("obstacle");
        Debug.Log(stones.Length);
        //劃出可行走位置
        int i;
        int j;
        for(i=0;i< planes.Length; i++)
        {
            int count = 0;
            if(Mathf.Round(Math.Abs(planes[i].transform.position.x - pos.x)) + Mathf.Round(Math.Abs(planes[i].transform.position.z - pos.z)) <= dis)
            {
                for (j = 0; j < stones.Length; j++)
                {
                    if ((Mathf.Round(stones[j].transform.position.x) == Mathf.Round(planes[i].transform.position.x)) && (Mathf.Round(stones[j].transform.position.z) == Mathf.Round(planes[i].transform.position.z)))
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                    if(count== stones.Length)
                    {
                        planes[i].GetComponent<MeshRenderer>().material.color = Color.blue;
                        planes[i].GetComponent<CanMovePlane>().Obj1 = this;
                    }
                }
            }
        }
        


        for (i = 0; i < GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters.Count; i++) //設置角色所在地面
        {
            GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i].planeSet();
        }
    }

    public virtual void attackDisplay(float attackDis)
    {
        clearDisplay();
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("MovePlane");
        int i;
        for (i = 0; i < planes.Length; i++)
        {
            if (Mathf.Round(Math.Abs(planes[i].transform.position.x - pos.x)) + Mathf.Round(Math.Abs(planes[i].transform.position.z - pos.z)) <= attackDis)
            {

                planes[i].GetComponent<MeshRenderer>().material.color = Color.red;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
        }

        for (i=0;i< GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters.Count; i++)
        {
            GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i].planeSet();
        }
        
    }

    public virtual void clearDisplay()
    {
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("MovePlane");
        int i;
        for (i = 0; i < planes.Length; i++)
        {
            planes[i].GetComponent<MeshRenderer>().material.color = Color.clear;
        }

        for (i = 0; i < GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters.Count; i++)
        {
            GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[i].planeSet();
        }
    }

    public virtual void attack(Character Obj1)
    {
        Obj1.hp = Obj1.hp - (STR - Obj1.DEF);
        Debug.Log(Obj1.name+"已受到"+ (STR - Obj1.DEF) +"點攻擊");

        canvasController.Instance.enemyName.GetComponent<Text>().text = Obj1.characterName;
        canvasController.Instance.enemyHp.GetComponent<Text>().text = Obj1.hp + "/" + Obj1.hpMax;
        canvasController.Instance.enemySp.GetComponent<Text>().text = Obj1.sp + "/" + Obj1.spMax;

        damageFloatUp.GetComponent<DamageFloatUp>().beAttack(Obj1, (STR - Obj1.DEF));
        clearDisplay();                 //攻擊完清除藍色地板
        GameObject.Find("Canvas").GetComponent<canvasController>().attack.GetComponent<Button>().interactable = false;
    }

    public virtual void move(float x, float z)
    {
        
    }

    public virtual void menuShow()
    {
        canvasController.Instance.menuShow();
    }

    public virtual void automove()
    {





    }

    private void OnMouseEnter()
    {
        if (plane.GetComponent<MeshRenderer>().material.color == Color.red &&
            GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[0] != this)
        {
            canvasController.Instance.enemyName.GetComponent<Text>().text = characterName;
            canvasController.Instance.enemyHp.GetComponent<Text>().text = hp + "/" + hpMax;
            canvasController.Instance.enemySp.GetComponent<Text>().text = sp + "/" + spMax;
            canvasController.Instance.enemyImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(image);
            canvasController.Instance.enemyName.SetActive(true);
            canvasController.Instance.enemyHp.SetActive(true);
            canvasController.Instance.enemySp.SetActive(true);
            canvasController.Instance.enemyImage.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        canvasController.Instance.enemyName.SetActive(false);
        canvasController.Instance.enemyHp.SetActive(false);
        canvasController.Instance.enemySp.SetActive(false);
        canvasController.Instance.enemyImage.enabled = false;
    }

}
