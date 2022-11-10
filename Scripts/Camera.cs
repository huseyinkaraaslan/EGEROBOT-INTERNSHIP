using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 distance;
    public Transform targetPlayer,targetForklift;
    float mouseX,mouseY;
    bool isWalking, isDriving;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        isWalking = gameObject.GetComponent<Player>().walkSit;
        isDriving = gameObject.GetComponent<Player>().driveSit;
    }

    private void LateUpdate()
    {
        if (isWalking)
        {
            Debug.Log("Is Walking");
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

        if (isDriving)
        {
            Debug.Log("Is Driving");
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
