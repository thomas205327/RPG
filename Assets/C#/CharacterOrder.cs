using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterOrder : MonoBehaviour
{
    public List<Character> characters;

    void Awake()
    {
        Instantiate(Resources.Load("Kirito"), new Vector3(0, 3.5f, 0), new Quaternion(0, 90, 0, 0));
        Instantiate(Resources.Load("Fuze"), new Vector3(10f, 3.5f, 0), new Quaternion(0, 90, 0, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        characters.Add(GameObject.Find("Kirito(Clone)").GetComponent<Character>());
        characters.Add(GameObject.Find("Fuze(Clone)").GetComponent<Character>());
        orderSort();
        planeCharacterChange();
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


    void movingdis()
    {
        List<int[]> enemy = new List<int[2]>();
        List<int[]> partner = new List<int[2]>();
        List<int> mCount = new List<int>();
        Character now;
        List<int[]> canMove = new List<int[2]>();

        foreach (Character element in characters)
        {
            if (element.team == 0)
            {
                int[2] entry;
                entry[0] = element.pos.x;
                entry[1] = element.pos.z;
                partner.Add(entry);
            }
            else
            {
                int[2] entry;
                entry[0] = element.pos.x;
                entry[1] = element.pos.z;
                enemy.Add(entry);
            }



        }
        mCount.Add(now.movDis);
        canMove.Add(new int[] = (now.pos.x, now.pos.z));

        int canMovecount = 0;

        while(canMove.Count > canMovecount)
        {

            //上
            int duplicateflag = 0;
            int[2] nowchecking;
            nowchecking[0] = canMove.FindIndex(canMovecount)[0];
            nowchecking[1] = canMove.FindIndex(canMovecount)[1] + 1;

            //檢查是否有敵人
            foreach (int[] element in enemy)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有隊友
            foreach (int[] element in partner)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有重複
            foreach (int[] element in canMove)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }

            if (duplicateflag == 0)
            {
                canMove.Add(nowchecking);
            }



            //下
            int duplicateflag = 0;
            int[2] nowchecking;
            nowchecking[0] = canMove.FindIndex(canMovecount)[0];
            nowchecking[1] = canMove.FindIndex(canMovecount)[1] - 1;

            //檢查是否有敵人
            foreach (int[] element in enemy)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有隊友
            foreach (int[] element in partner)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有重複
            foreach (int[] element in canMove)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }

            if (duplicateflag == 0)
            {
                canMove.Add(nowchecking);
            }

            //左
            int duplicateflag = 0;
            int[2] nowchecking;
            nowchecking[0] = canMove.FindIndex(canMovecount)[0] - 1;
            nowchecking[1] = canMove.FindIndex(canMovecount)[1];

            //檢查是否有敵人
            foreach (int[] element in enemy)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有隊友
            foreach (int[] element in partner)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有重複
            foreach (int[] element in canMove)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }

            if (duplicateflag == 0)
            {
                canMove.Add(nowchecking);
            }

            //右
            int duplicateflag = 0;
            int[2] nowchecking;
            nowchecking[0] = canMove.FindIndex(canMovecount)[0] + 1;
            nowchecking[1] = canMove.FindIndex(canMovecount)[1];

            //檢查是否有敵人
            foreach (int[] element in enemy)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有隊友
            foreach (int[] element in partner)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }
            //檢查是否有重複
            foreach (int[] element in canMove)
            {
                if (element[0] == nowchecking[0] && element[1] == nowchecking[1])
                {
                    duplicateflag = 1;
                    break;
                }
            }

            if (duplicateflag == 0)
            {
                canMove.Add(nowchecking);
            }

            canMovecount++;


        }


    }




}
