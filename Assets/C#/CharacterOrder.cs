using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CharacterOrder : MonoBehaviour
{
    public List<Character> characters;

    void Awake()
    {
        Instantiate(Resources.Load("Kirito"), new Vector3(0, 3.5f, 0), new Quaternion(0, 90, 0, 0));
        Instantiate(Resources.Load("Fuze"), new Vector3(10f, 3.5f, 30f), new Quaternion(0, 90, 0, 0));
        Instantiate(Resources.Load("Midoriya"), new Vector3(-30f, 3.5f, 0), new Quaternion(0, 90, 0, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        characters.Add(GameObject.Find("Kirito(Clone)").GetComponent<Character>());
        characters.Add(GameObject.Find("Fuze(Clone)").GetComponent<Character>());
        characters.Add(GameObject.Find("Midoriya(Clone)").GetComponent<Character>());
        orderSort();
        planeCharacterChange();
        canvasController.Instance.characterName.GetComponent<Text>().text = characters[0].characterName;
        canvasController.Instance.hp.GetComponent<Text>().text = characters[0].hp + "/" + characters[0].hpMax;
        canvasController.Instance.sp.GetComponent<Text>().text = characters[0].sp + "/" + characters[0].spMax;
        GameObject.Find("Main Camera").GetComponent<MainCamera>().CameraReturn();
        GameObject.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(characters[0].image);
    }

    void orderSort()
    {
        characters.Sort((x, y) => { return x.actionValue.CompareTo(y.actionValue); });
        int i;
        int value = characters[0].actionValue;
        for (i = 0; i < characters.Count; i++)
        {
            characters[i].actionValue = characters[i].actionValue - value;
            //Debug.Log(characters[i].actionValue);
        } 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void orderChange()
    {
        Character temp = characters[0];
        temp.actionValue = temp.actionValueMax;
        //Debug.Log("重製後的"+ temp.actionValue);
        characters.Remove(characters[0]);
        characters.Add(temp);
        orderSort();
        planeCharacterChange();

        canvasController.Instance.characterName.GetComponent<Text>().text = characters[0].characterName;
        canvasController.Instance.hp.GetComponent<Text>().text = characters[0].hp + "/" + characters[0].hpMax;
        canvasController.Instance.sp.GetComponent<Text>().text = characters[0].sp + "/" + characters[0].spMax;
        GameObject.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(characters[0].image);
    }

    public void planeCharacterChange()
    {
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("MovePlane");
        int i;
        for (i = 0; i < planes.Length; i++)
        {
            planes[i].GetComponent<CanMovePlane>().Obj1 = characters[0];
        }
    }


    public void movingdis()
    {
        List<float[]> enemy = new List<float[]>();          //敵人
        List<float[]> partner = new List<float[]>();        //隊友
        List<float> mCount = new List<float>();             //canMove走到哪一個後剩下幾步可以走 (A能走幾步)
        Character now = characters[0];
        List<float[]> canMove = new List<float[]>();        //可以移動到哪一格

        List<float> enemydis = new List<float>();           //還沒用到



        foreach (Character element in characters)           //分隊伍
        {
            if (element.team == 0)                          
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

        while(canMove.Count > canMovecount)
        {
            float move = mCount[canMovecount];

            if(move == 0)
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

            if (duplicateflag == 0)
            {
                Debug.Log("+上");
                canMove.Add(nowchecking);
                Debug.Log("把nowchecking加進去囉" + nowchecking[0] + "   " + nowchecking[1]);
                mCount.Add(move - 10);
            }


            //下
            //Debug.Log("下");
            duplicateflag = 0;
            
            nowchecking[0] = canMove[canMovecount][0];
            nowchecking[1] = canMove[canMovecount][1] - 10;

            Debug.Log("X:"+canMove[1][0] + "Z:"+canMove[1][1]);

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
                Debug.Log("x:"+element[0] +"z:"+ element[1]);
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    Debug.Log("移動重複");
                    duplicateflag = 1;
                    break;
                }
            }

            if (duplicateflag == 0)
            {
                Debug.Log("+下");
                canMove.Add(nowchecking);
                mCount.Add(move - 10);
                Debug.Log("成功存取下");
            }

            //左
            //Debug.Log("左");
            duplicateflag = 0;
            
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

            if (duplicateflag == 0)
            {
                Debug.Log("+左");
                canMove.Add(nowchecking);
                mCount.Add(move - 10);
            }

            //右
            //Debug.Log("右");
            duplicateflag = 0;
            
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

            if (duplicateflag == 0)
            {
                Debug.Log("+右");
                canMove.Add(nowchecking);
                mCount.Add(move - 10);
            }

            
            canMovecount++;


        }










        
        float[] shortest = new float[2];
        float shortestdis = 999999999;
        //最近的敵人
        foreach(float[] e in enemy)
        {
            float dis = (now.pos.x - e[0])* (now.pos.x - e[0]) + (now.pos.z - e[1])* (now.pos.z - e[1]);
            if (dis < shortestdis)
            {
                shortest[0] = e[0];
                shortest[1] = e[1];
                shortestdis = dis;
            }

        }
        int enemyindis = 0;
        foreach (float[] e in canMove)
        {
            if (e[0] == shortest[0] && e[1] == shortest[1])
            {
                enemyindis = 1;
            }
        }

        Debug.Log(shortest[0]);
        Debug.Log(shortest[1]);
        Debug.Log(enemyindis);




        //範圍內
        if (enemyindis == 1)
        {
            float n = 999999999;
            float[] temp2 = new float[2];
            float[] near = new float[2];
            int index = 0;

            //上
            temp2[0] = shortest[0] + 10;
            temp2[1] = shortest[1];

            int notfound = 1;
            for(int i = 0; i < canMove.Count; i++)
            {
                if (canMove[i][0] == temp2[0] && canMove[i][1] == temp2[1])
                {
                    index = i;
                    notfound = 0;
                    break;
                }
            }
            if (notfound != 1)
            {
                if (mCount[index] < n)
                {
                    near[0] = temp2[0];
                    near[1] = temp2[1];
                    n = mCount[index];
                }
            }
            


            //下
            temp2[0] = shortest[0] - 10;
            temp2[1] = shortest[1];

            notfound = 1;
            for (int i = 0; i < canMove.Count; i++)
            {
                if (canMove[i][0] == temp2[0] && canMove[i][1] == temp2[1])
                {
                    index = i;
                    notfound = 0;
                    break;
                }
            }

            if (notfound != 1)
            {
                if (mCount[index] < n)
                {
                    near[0] = temp2[0];
                    near[1] = temp2[1];
                    n = mCount[index];
                }
            }

            


            //左
            temp2[0] = shortest[0];
            temp2[1] = shortest[1] - 10;

            notfound = 1;
            for (int i = 0; i < canMove.Count; i++)
            {
                if (canMove[i][0] == temp2[0] && canMove[i][1] == temp2[1])
                {
                    index = i;
                    notfound = 0;
                    break;
                }
            }

            if (notfound != 1)
            {
                if (mCount[index] < n)
                {
                    near[0] = temp2[0];
                    near[1] = temp2[1];
                    n = mCount[index];
                }
            }

            


            //右
            temp2[0] = shortest[0];
            temp2[1] = shortest[1] + 10;

            notfound = 1;
            for (int i = 0; i < canMove.Count; i++)
            {
                if (canMove[i][0] == temp2[0] && canMove[i][1] == temp2[1])
                {
                    index = i;
                    notfound = 0;
                    break;
                }
            }

            if (notfound != 1)
            {
                if (mCount[index] < n)
                {
                    near[0] = temp2[0];
                    near[1] = temp2[1];
                    n = mCount[index];
                }
            }

            now.move(near[0], near[1]);

            foreach(Character e in characters)
            {
                if(e.pos.x == shortest[0] && e.pos.z == shortest[1])
                {
                    now.attack(e);
                    GameObject ending = GameObject.Find("Canvas");
                    ending.GetComponent<canvasController>().endOnclick();
                    
                }
            }

        }

        //範圍外
        else
        {
            float[] nearest = new float[2];
            shortestdis = 999999999;
            
            //離最近敵人最近地板
            foreach (float[] e in canMove)
            {
                float dis = (shortest[0] - e[0]) * (shortest[0] - e[0]) + (shortest[1] - e[1]) * (shortest[1] - e[1]);
                //Debug.Log("canmove");
                //Debug.Log(e[0]);
                //Debug.Log(e[1]);
                //Debug.Log(dis);


                if (dis < shortestdis)
                {
                    nearest[0] = e[0];
                    nearest[1] = e[1];
                    shortestdis = dis;
                }

            }
            //Debug.Log(nearest[0]);
            //Debug.Log(nearest[1]);


            foreach (float[] e in canMove)
            {
                Debug.Log(e[0]+","+ e[1]);
            }


                

            now.move(nearest[0], nearest[1]);
        }


        



    }







}
