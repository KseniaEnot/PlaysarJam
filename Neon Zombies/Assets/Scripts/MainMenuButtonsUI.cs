using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuButtonsUI : MonoBehaviour, IEventSystemHandler
{
	public GameObject gameObject1;
	public void OnPointerEnter(PointerEventData eventData)
	{
		gameObject1.SetActive(true);
		Debug.Log("OK");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		gameObject1.SetActive(false);
	}
}
