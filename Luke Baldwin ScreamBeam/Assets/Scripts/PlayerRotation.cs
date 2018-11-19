using UnityEngine;

public class PlayerRotation: MonoBehaviour
{


	void Update()
    {
        //Gives Character a Directional value of where it should be looking in comparision with the mouse
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}