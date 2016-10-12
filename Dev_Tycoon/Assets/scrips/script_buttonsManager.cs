using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class script_buttonsManager : MonoBehaviour {

    private Button lastPressed;

    public UnityEngine.EventSystems.EventSystem event_system;
    public GameObject[] elements_array = new GameObject[10];
    public GameObject[] buttons_array = new GameObject[10];

	public void button_pressed(Button button)
    {

        int button_index = System.Array.IndexOf(buttons_array, button.gameObject);
        if(button_index > -1 && button_index < 6)
        {
            if (lastPressed && button.name == lastPressed.name)
            {
                event_system.SetSelectedGameObject(null);
                lastPressed = null;
                button_home();
                return;
            } else
            {
                lastPressed = button;
            }
        }
        button_event(button.gameObject);

    }

    private void button_event(GameObject button)
    {
        if(button == buttons_array[0])
        {

            elements_array[1].SetActive(false);
            elements_array[2].SetActive(true);

        } else if(button == buttons_array[6])
        {

            elements_array[2].SetActive(false);
            elements_array[3].SetActive(true);

        } else if(button == buttons_array[10])
        {
            //Close center_frame project progress window
            script_GameManager.Instance.manager_gm.events.project_progress_close();

        }
        
    }

    private void button_home()
    {
        foreach(GameObject go in elements_array)
        {
            if(go)
            {
                go.SetActive(false);
            }
            
        }
        elements_array[0].SetActive(true);
        elements_array[1].SetActive(true);
    }

}
