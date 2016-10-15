using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class script_character_manager : MonoBehaviour {

    private List<GameObject> characters = new List<GameObject>();

    public void add_character(GameObject ch)
    {
        characters.Add(ch);
    }
}
