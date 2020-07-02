using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Character;

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
        characters.Sort((x, y) => { return x.actionValue.CompareTo(y.actionValue); });     //QuickSort
    }

    // Update is called once per frame
    void Update()
    {

    }

    void orderChange()
    {

    }
}
