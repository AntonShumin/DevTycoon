using UnityEngine;
using System.Collections;

public class script_orbit : MonoBehaviour {

    //FIELDS
    public GameObject target = null;
    //auto rotation
    public int rotation_speed = 15;
    public bool auto_orbit = false;
    //drag rotation
    public int drag_speed = 300;
    public bool mouse_pressed = false;
	
	// Update is called once per frame
	void Update () {
	
        if(target != null)
        {
            Camera.main.transform.LookAt(target.transform);

            if(auto_orbit)
            {
                Camera.main.transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * rotation_speed);
            }

            if(Input.GetMouseButtonDown(0))
            {
                mouse_pressed = true;
                auto_orbit = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                mouse_pressed = false;
            }

            if (mouse_pressed)
            {
                float rotX = Input.GetAxis("Mouse X") * drag_speed * Mathf.Deg2Rad;
                float rotY = Input.GetAxis("Mouse Y") * drag_speed * Mathf.Deg2Rad;
                //Camera.main.transform.RotateAround(target.transform.position, Vector3.up, rotX);
                Camera.main.transform.RotateAround(target.transform.position, Vector3.right, -rotY);
            }
        }

	}

    void OnMouseDragss()
    {
        Debug.Log("test");
        float rotX = Input.GetAxis("Mouse X") * drag_speed * Mathf.Deg2Rad;
        Debug.Log(rotX);
        

    }

}
