using UnityEngine;
using System.Collections;

public class script_GameManager : script_singleton<script_GameManager> {

    public script_GM_objects manager_gm;
    public script_ui manager_ui;

    public void setup_objects(int index, GameObject go)
    {
        switch (index)
        {
            case 0:
                manager_gm = go.GetComponent<script_GM_objects>();
                break;
            case 1:
                manager_ui = go.GetComponent<script_ui>();
                break;
        }
    }

}
