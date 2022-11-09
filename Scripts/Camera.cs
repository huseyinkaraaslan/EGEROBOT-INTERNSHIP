using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 distance;
    public Transform targetPlayer,targetForklift;
    float mouseX,mouseY;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        if (gameObject.GetComponent<Player>().walkSit == 1)
        {
            Debug.Log("walkSit Accessible");
            this.transform.position = Vector3.Lerp(this.transform.position, targetPlayer.transform.position + distance, Time.deltaTime * 10);
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y");

            if (mouseY >= 25)
            {
                mouseY = 25;
            }
            if (mouseY <= -50)
            {
                mouseY = -50;
            }

            this.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
            targetPlayer.transform.eulerAngles = new Vector3(0, mouseX, 0);
        }

        if (gameObject.GetComponent<Player>().driveSit == 1)
        {
            Debug.Log("driveSit Accessible");
            this.transform.position = Vector3.Lerp(this.transform.position, targetForklift.transform.position + distance, Time.deltaTime * 10);
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y");

            if (mouseY >= 25)
            {
                mouseY = 25;
            }
            if (mouseY <= -50)
            {
                mouseY = -50;
            }

            this.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
        }
        

        
    }
}
