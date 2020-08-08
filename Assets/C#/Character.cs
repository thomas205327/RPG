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
    public int skillSP1;


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
        //Debug.Log(stones.Length);
        //劃出可行走位置
        int i;



        int j;


        List<float[]> enemy = new List<float[]>();          //敵人
        List<float[]> partner = new List<float[]>();        //隊友
        List<float> mCount = new List<float>();             //canMove走到哪一個後剩下幾步可以走 (A能走幾步)
        Character now = GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters[0];
        List<float[]> canMove = new List<float[]>();        //可以移動到哪一格

        List<float> enemydis = new List<float>();           //還沒用到

        List<float[]> obs = new List<float[]>();          //敵人




        GameObject[] gos;                               //障礙
        gos = GameObject.FindGameObjectsWithTag("obstacle");

        foreach (GameObject element in gos)
        {



            float[] entry = new float[2];
            entry[0] = Mathf.Round(element.transform.position.x);
            entry[1] = Mathf.Round(element.transform.position.z);
            obs.Add(entry);
        }


        foreach (Character element in GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters)           //分隊伍
        {
            if (element.team == now.team)
            {
                float[] entry = new float[2];
                entry[0] = element.pos.x;
                entry[1] = element.pos.z;
                partner.Add(entry);
            }
            else
            {
                float[] entry = new float[2];
                entry[0] = element.pos.x;
                entry[1] = element.pos.z;
                enemy.Add(entry);
            }



        }

        mCount.Add(now.moveDis);                    //此角色的可移動步數                           

        float[] temp = new float[2];                //此角色的位置          

        temp[0] = now.pos.x;
        temp[1] = now.pos.z;

        canMove.Add(temp);

        int canMovecount = 0;

        while (canMove.Count > canMovecount)
        {
            float move = mCount[canMovecount];

            if (move == 0)
            {
                canMovecount++;
                continue;
            }

            //上
            //Debug.Log("上");
            float duplicateflag = 0;
            float[] nowchecking = new float[2];
            nowchecking[0] = canMove[canMovecount][0];
            nowchecking[1] = canMove[canMovecount][1] + 10;

            //檢查是否有敵人
            foreach (float[] element in enemy)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有隊友
            foreach (float[] element in partner)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有重複
            foreach (float[] element in canMove)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有障礙
            foreach (float[] element in obs)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }





            if (duplicateflag == 0)
            {
                //Debug.Log("+上");
                canMove.Add(nowchecking);
                //Debug.Log("把nowchecking加進去囉" + nowchecking[0] + "   " + nowchecking[1]);
                mCount.Add(move - 10);
                //Debug.Log("canMove上" + canMove[1][0] + "   " + canMove[1][1]);
            }


            //下
            //Debug.Log("下");
            duplicateflag = 0;
            nowchecking = new float[2];
            nowchecking[0] = canMove[canMovecount][0];
            nowchecking[1] = canMove[canMovecount][1] - 10;
            //Debug.Log("canMove下" + canMove[1][0] + "   " + canMove[1][1]);

            //Debug.Log("X:"+canMove[1][0] + "Z:"+canMove[1][1]);

            //檢查是否有敵人
            foreach (float[] element in enemy)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有隊友
            foreach (float[] element in partner)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有重複
            foreach (float[] element in canMove)
            {
                //Debug.Log("x:"+element[0] +"z:"+ element[1]);
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    //Debug.Log("移動重複");
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有障礙
            foreach (float[] element in obs)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }

            if (duplicateflag == 0)
            {
                //Debug.Log("+下");
                canMove.Add(nowchecking);

                mCount.Add(move - 10);
                //Debug.Log("成功存取下");
            }

            //左
            //Debug.Log("左");
            duplicateflag = 0;
            nowchecking = new float[2];
            nowchecking[0] = canMove[canMovecount][0] - 10;
            nowchecking[1] = canMove[canMovecount][1];

            //檢查是否有敵人
            foreach (float[] element in enemy)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有隊友
            foreach (float[] element in partner)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有重複
            foreach (float[] element in canMove)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有障礙
            foreach (float[] element in obs)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }

            if (duplicateflag == 0)
            {
                //Debug.Log("+左");
                canMove.Add(nowchecking);
                mCount.Add(move - 10);
            }

            //右
            //Debug.Log("右");
            duplicateflag = 0;
            nowchecking = new float[2];
            nowchecking[0] = canMove[canMovecount][0] + 10;
            nowchecking[1] = canMove[canMovecount][1];

            //檢查是否有敵人
            foreach (float[] element in enemy)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有隊友
            foreach (float[] element in partner)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有重複
            foreach (float[] element in canMove)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有障礙
            foreach (float[] element in obs)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }

            if (duplicateflag == 0)
            {
                //Debug.Log("+右");
                canMove.Add(nowchecking);
                mCount.Add(move - 10);
            }


            canMovecount++;


        }


 //       foreach(float[] x in canMove)
//        {
 //           Debug.Log(x[0] + "," + x[1]);
 //       }

        Debug.Log(planes[0].transform.position.x + "," + planes[0].transform.position.z);
        


        for (i = 0; i < planes.Length; i++)
        {
            for (j = 0; j < canMove.Count; j++)
            {
                if (Mathf.Round(planes[i].transform.position.x)==canMove[j][0]&& Mathf.Round(planes[i].transform.position.z)==canMove[j][1])
                {
                    planes[i].GetComponent<MeshRenderer>().material.color = Color.blue;
                    planes[i].GetComponent<CanMovePlane>().Obj1 = this;
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
        GameObject.Find("Canvas").GetComponent<canvasController>().skill.GetComponent<Button>().interactable = false;

        if (Obj1.hp <= 0)
        {
            GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().characters.Remove(Obj1);
            Obj1.gameObject.SetActive(false);
        }

        GameObject.Find("CharacterOrder").GetComponent<CharacterOrder>().checkEnd();
    }

    public virtual void move(float x, float z)
    {
        
    }

    public virtual void menuShow()
    {
        canvasController.Instance.menuShow();
    }

    public virtual void skillDisplay()
    {

    }

    public virtual void skillAttack()
    {

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
