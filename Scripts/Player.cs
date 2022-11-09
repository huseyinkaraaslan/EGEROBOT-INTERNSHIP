using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    private float playerSpeed;
    public GameObject pressF,pressQ;
    public GameObject driverPosition, outPosition;
    public int walkSit, driveSit;
    void Start()
    {
        walkSit = 1; driveSit = 0;
        anim = this.GetComponent<Animator>();
        pressF.SetActive(false);
        pressQ.SetActive(false);
    }

    
    void Update()
    {
        if (walkSit == 1)
        {
            movement();
        }
    }

    void movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);

        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Horizontal") > 0)
        {
            playerSpeed = 2.4f;
            anim.SetBool("walking", true);          
        }

        if (Input.GetAxis("Vertical") < 0 & Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") < 0 & Input.GetAxis("Horizontal") < 0)
        {
            playerSpeed = .7f;
            anim.SetBool("walking", true);
        }

        if (Input.GetAxis("Vertical") == 0 & Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("walking", false);
        }
        
        this.gameObject.transform.Translate(horizontal * playerSpeed * Time.deltaTime, 0, vertical * playerSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Forklift")
        {
            pressF.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Forklift")
        {
            if (Input.GetKey(KeyCode.F))
            {
                anim.SetBool("drive", true);
                driveSit = 1;
                this.gameObject.transform.position = driverPosition.transform.position;
                pressF.SetActive(false);
                pressQ.SetActive(true);
                driveSit = 1;
                walkSit = 0;
            }

            else if (anim.GetBool("drive") & Input.GetKey(KeyCode.Q))
            {
                anim.SetBool("drive", false);
                this.gameObject.transform.position = outPosition.transform.position;
                pressQ.SetActive(false);
                driveSit = 0;
                walkSit = 1;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Forklift")
        {
            pressF.SetActive(false);
        }
    }


}
