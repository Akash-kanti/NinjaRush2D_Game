using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
	[SerializeField] AudioSource finishsound;
	
	
	

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
    	if(collision.gameObject.name=="frog")
    	{
			finishsound.Play();
			Invoke("CompleteLevel", 2f);

		}
	}

	private void CompleteLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

}
