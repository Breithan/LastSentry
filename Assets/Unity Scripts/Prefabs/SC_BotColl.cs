using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BotColl : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D coll)
    {
		var tagCGO = coll.gameObject.tag;
        if (tagCGO == "Enemy" || tagCGO == "Meteor" || tagCGO == "BackMeteor" || tagCGO == "Restore" ||tagCGO == "Enemy Laser" || tagCGO == "Power Up" || tagCGO == "Shield")
        {
			Destroy(coll.gameObject);
        }
    }
}
