using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
 //   public GameObject bulletPrefab;
 //   public Transform bulletSpawn;

	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        CmdFire();
    //    }
    }
    
    // This [Command] cod is called on the Client, but it is urn on the Server

 /*   [Command]
    void CmdFire()
    {
        // Create the Bullet From the Bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        // Destory the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
*/
//    public override void OnStartLocalPlayer()
 //   {
 //       GetComponent<MeshRenderer>().material.color = Color.blue;
  //  }
}
