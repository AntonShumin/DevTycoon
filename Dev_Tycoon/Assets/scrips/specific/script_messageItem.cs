using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class script_messageItem : MonoBehaviour {

    public GameObject text;
    public GameObject image;
    public GameObject letter;

    //item specific vars
    public int index = 0;

    public void set_item(string para_text, string para_letter)
    {
        text.GetComponent<Text>().text = para_text;
        letter.GetComponent<Text>().text = para_letter;
    }

    public void clicked()
    {
        Debug.Log("clicked");
    }
}
