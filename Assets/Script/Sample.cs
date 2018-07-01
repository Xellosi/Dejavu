using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class Sample : MonoBehaviour
{
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			PointerEventData pointer = new PointerEventData(EventSystem.current);
			pointer.position = Input.mousePosition;

			List<RaycastResult> raycastResults = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointer, raycastResults);

			if (raycastResults.Count > 0)
			{
				raycastResults[0].gameObject.transform.position = Input.mousePosition;
			}
		}
	}
}