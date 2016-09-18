using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class script_messageCenter : MonoBehaviour {

    public GameObject item_prefab;
    public GameObject grid;

    //Pool
    public int pooledAmount = 11;
    List<GameObject> items_list;


    void Start()
    {
        pupulateList();
    }

    private void pupulateList()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            new_item("", "");
        }
    }

    public void create_item()
    {
        new_item("HUD ITEM", "H");
    }

    private void new_item(string para_text, string para_letter)
    {
        GameObject item = Instantiate(item_prefab, grid.transform, false) as GameObject;
        item.transform.SetAsFirstSibling();
        item.GetComponent<script_messageItem>().set_item(para_text,para_letter);
        items_list.Add(item);
        item.SetActive(false);
    }

    public void set_item(string para_text, string para_letter)
    {

    }
}
