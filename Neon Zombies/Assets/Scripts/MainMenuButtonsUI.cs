using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuButtonsUI : MonoBehaviour, IEventSystemHandler
{
	public GameObject gameObject;
	public void OnPointerEnter(PointerEventData eventData)
	{
		gameObject.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		gameObject.SetActive(false);
	}
}
