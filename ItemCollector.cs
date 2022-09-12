using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
	[SerializeField] private Text StrawberryText;
	[SerializeField] private AudioSource itemcollectsound;
	public static int TotalBerry=0;

	private void Start()
	{
		StrawberryText.text=PlayerPrefs.GetInt("StrawberryText", TotalBerry).ToString();
		TotalBerry = PlayerPrefs.GetInt("StrawberryText");
	}




   private void OnTriggerEnter2D(Collider2D collision)
   {
   	if(collision.gameObject.CompareTag("Strawberry"))
   	{
		itemcollectsound.Play();
   		Destroy(collision.gameObject);
   		TotalBerry++;
		PlayerPrefs.SetInt("StrawberryText", TotalBerry);
		StrawberryText.text ="" +TotalBerry;
		

	   }

   }




}
