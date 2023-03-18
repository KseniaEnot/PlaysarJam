using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuButtonsUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject gameObject1;
	public void OnPointerEnter(PointerEventData eventData)
	{
		gameObject1.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		gameObject1.SetActive(false);
	}
}
