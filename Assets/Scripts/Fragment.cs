using UnityEngine;
using System.Collections;

public class Fragment : MonoBehaviour 
{

	void OnTriggerStay(Collider col)
	{
		if(col.tag == "Player"){
			col.transform.parent.gameObject.GetComponent<Stats>().FragmentFound();
			Destroy(gameObject);
		}
	}

}
