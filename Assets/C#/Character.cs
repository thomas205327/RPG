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

    public virtual void moveDisplay(float dis){
        clearDisplay();
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("MovePlane");

        //劃出可行走位置
        int i;
        for(i=0;i< planes.Length; i++)
        {
            if(Mathf.Round(Math.Abs(planes[i].transform.position.x - pos.x)) + Mathf.Round(Math.Abs(planes[i].transform.position.z - pos.z)) <= dis)
            {
                
                planes[i].GetComponent<MeshRenderer>().material.color = Color.blue;
                //planes[i].GetComponent<CanMovePlane>().moveLock = true;
                planes[i].GetComponent<CanMovePlane>().Obj1 = this;
            }
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
    }

    public virtual void move(float x, float z)
    {
        
    }

    public virtual void menuShow()
    {
        canvasController.Instance.menuShow();
    }
}
