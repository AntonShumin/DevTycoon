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
    private Vector3 drag_vector = new Vector3();
	
	// Update is called once per frame
	void Update () {
	
        if(target != null)
        {
            //Camera.main.transform.LookAt(target.transform);

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
                //float rotX = Input.GetAxis("Mouse X") * drag_speed * Mathf.Deg2Rad;
                float rotation_y = Camera.main.transform.rotation.eulerAngles.y;
                float rotation_y_adjusted = rotation_y;
                
                if(rotation_y > 180)
                {
                    rotation_y_adjusted -= 180 ;
                    
                }
                if (rotation_y_adjusted > 90)
                {
                    rotation_y_adjusted = 180 - rotation_y_adjusted;
                }
                
                Debug.Log(rotation_y_adjusted);

                float input_X = Input.GetAxis("Mouse X") * drag_speed * Time.deltaTime;
                float input_Y = Input.GetAxis("Mouse Y") * drag_speed * Time.deltaTime;
                Camera.main.transform.RotateAround(target.transform.position, Vector3.up, input_X);
                Camera.main.transform.RotateAround(target.transform.position, Vector3.left, input_Y);

            }
        }

	}

}
