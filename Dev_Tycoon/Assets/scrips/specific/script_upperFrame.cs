using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class script_upperFrame : MonoBehaviour {

    public GameObject o_date;
	public Text text_date;

    void Awake()
    {
        text_date = o_date.GetComponent<Text>();
    }
}
