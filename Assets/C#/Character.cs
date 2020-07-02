using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class Character : MonoBehaviour
{
    public Vector3 pos;
    public int moveDis;
    public int hp;
    public float speed;
    public int actionValue;
    public int attackDis;

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
                planes[i].GetComponent<CanMovePlane>().moveLock = true;
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
                planes[i].GetComponent<CanMovePlane>().moveLock = true;
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
        speed = 0.2f;
    }

    public virtual void menuShow()
    {
        canvasController.Instance.menuShow();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
