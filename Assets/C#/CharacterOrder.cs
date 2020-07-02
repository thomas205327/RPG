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
    }

    void orderSort()
    {
        characters.Sort((x, y) => { return x.actionValue.CompareTo(y.actionValue); });
        int i;
        int value = characters[0].actionValue;
        for (i = 0; i < characters.Count; i++)
        {
            characters[i].actionValue = characters[i].actionValue - value;
            Debug.Log(characters[i].actionValue);
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
        Debug.Log("重製後的"+ temp.actionValue);
        characters.Remove(characters[0]);
        characters.Add(temp);
        orderSort();
    }
}
