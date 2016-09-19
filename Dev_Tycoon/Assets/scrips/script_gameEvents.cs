using UnityEngine;
using System.Collections;

public class script_gameEvents : MonoBehaviour {

    private string[][] messages;

    void Awake()
    {
        setup_messages();
    }

    void Start()
    {

    }


    public void set_message(string index)
    {

    }

    private void setup_messages()
    {
        messages[0][0] = "Develop your first game";
        messages[0][1] = "G";

    }


}
