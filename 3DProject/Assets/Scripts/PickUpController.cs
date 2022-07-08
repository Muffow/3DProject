using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GunScript gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;
    public GameObject gun;

    public float pickUpRange=5f;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;


    // Start is called before the first frame update
    void Start()
    {
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            //gun.SetActive(false);
        }
        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
            //gun.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }
    
    public void PickUp()
    {
        equipped = true;
        slotFull = true;
        gunScript.enabled = true;
        //gun.SetActive(true);


        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one; 

        rb.isKinematic = true;
        coll.isTrigger = true;

        
    }

    public void Drop()
    {
        equipped = false;
        slotFull = false;
        gunScript.enabled = false;
        //gun.SetActive(false);


        transform.SetParent(null);
        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10); 


        rb.isKinematic = false;
        coll.isTrigger = false;

    }
}
