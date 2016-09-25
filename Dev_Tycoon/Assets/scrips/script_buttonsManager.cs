using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class script_buttonsManager : MonoBehaviour {

    private Button lastPressed;
    public UnityEngine.EventSystems.EventSystem event_system;

	public void button_pressed(Button button)
    {
        if(lastPressed && button.name == lastPressed.name)
        {
            event_system.SetSelectedGameObject(null);
            lastPressed = null;
        }
        else
        {
            lastPressed = button;
        }
        

        if(event_system)
        {
            Debug.Log(event_system.name);
        }
    }

}
