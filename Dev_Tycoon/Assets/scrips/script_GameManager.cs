using UnityEngine;
using System.Collections;

public class script_GameManager : script_singleton<script_GameManager> {

    public script_gameEvents o_EventsManager;
    public script_messageCenter o_MessageManager;

    public void setup_objects(int index, GameObject go)
    {
        switch (index)
        {
            case 0:
                o_EventsManager = go.GetComponent<script_gameEvents>();
                break;
            case 1:
                o_MessageManager = go.GetComponent<script_messageCenter>();
                break;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
