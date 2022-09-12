using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

	private Animator anim;
	private Rigidbody2D rb2d;
	[SerializeField] private AudioSource deathsound;

	// Start is called before the first frame update
    private void Start()
    {
    	anim= GetComponent<Animator>();
    	rb2d = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    	{
    		if(collision.gameObject.CompareTag("Traps"))
    		{
    			Die();
			}
		}


    private void Die()
    {
    	deathsound.Play();
    	anim.SetTrigger("death");
    	rb2d.bodyType = RigidbodyType2D.Static;
	}

	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


}
