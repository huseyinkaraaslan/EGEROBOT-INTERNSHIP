using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    private float playerSpeed;
    public GameObject pressF,pressQ;
    public GameObject driverPosition, outPosition;
    public bool walkSit, driveSit;  // sit --> situation
    void Start()
    {
        walkSit = true; driveSit = false;
        anim = this.GetComponent<Animator>();
        pressF.SetActive(false);
        pressQ.SetActive(false);
    }
    
    void Update()
    {
        if (walkSit)
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
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerSpeed = 8f;
                anim.SetBool("run", true);
                anim.SetBool("walking", false);
            }
            else
            {
                playerSpeed = 2.4f;
                anim.SetBool("walking", true);
                anim.SetBool("run", false);
            }       
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                playerSpeed = 5f;
            }
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
                this.gameObject.transform.position = driverPosition.transform.position;
                pressF.SetActive(false);
                pressQ.SetActive(true);
                driveSit = true;
                walkSit = false;
            }

            if (anim.GetBool("drive") & Input.GetKey(KeyCode.Q))
            {
                anim.SetBool("drive", false);
                this.gameObject.transform.position = outPosition.transform.position;
                pressQ.SetActive(false);
                driveSit = false;
                walkSit = true;
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
