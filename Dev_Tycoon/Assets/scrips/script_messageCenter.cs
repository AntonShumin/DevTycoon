using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class script_messageCenter : MonoBehaviour {

    public GameObject item_prefab;
    public GameObject grid;

    //Pool
    public int pooledAmount = 11;
    List<GameObject> items_list = new List<GameObject>();
    private int randomCount = 0;


    void Start()
    {
        pupulateList();
    }

    private void pupulateList()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            new_item();
        }
    }

    private void new_item()
    {
        GameObject item = Instantiate(item_prefab, grid.transform, false) as GameObject;
        
        items_list.Add(item);
        item.SetActive(false);
    }

    public void set_item(string para_text, string para_letter)
    {
        foreach(GameObject item in items_list)
        {
            if(!item.activeInHierarchy)
            {
                item.GetComponent<script_messageItem>().set_item(para_text, para_letter);
                item.transform.SetAsFirstSibling();
                item.SetActive(true);
                grid.transform.GetChild(grid.transform.childCount - 1).gameObject.SetActive(false);
                break;
            }
        }
    }

    public void test_set()
    {
        randomCount++;
        set_item("hello world " + randomCount, "XYZ");
    }
}
