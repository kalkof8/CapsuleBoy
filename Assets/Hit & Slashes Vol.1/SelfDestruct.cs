using UnityEngine;
using System.Collections;


public class SelfDestruct : MonoBehaviour {
	public float selfdestruct_in = 1; // Setting this to 0 means no selfdestruct.

	void Start () {
		//if ( selfdestruct_in != 0){ 
		//	Destroy (gameObject, selfdestruct_in);
		//}
		Invoke(nameof(Deactivate), selfdestruct_in);
	}

	private void Deactivate()
    {
		gameObject.SetActive(false);
    }
}
