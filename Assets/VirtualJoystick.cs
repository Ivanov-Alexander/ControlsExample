using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
	private Image backgroundImage;
	private Image joystickImage;
	private Vector3 inputVector;

	//
	public Text text;

	void Start() {
		backgroundImage = GetComponent<Image>();
		joystickImage = transform.GetChild(0).GetComponent<Image>();
	}

	void Update() {

	}

	public void OnDrag(PointerEventData eventData) {
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImage.rectTransform,
			eventData.position,
			eventData.pressEventCamera,
			out pos)) {

			pos.x = (pos.x / backgroundImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / backgroundImage.rectTransform.sizeDelta.y);

			inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);

			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			joystickImage.rectTransform.anchoredPosition =
				new Vector3(inputVector.x * backgroundImage.rectTransform.sizeDelta.x / 3,
				inputVector.z * backgroundImage.rectTransform.sizeDelta.y / 3);

			text.text = inputVector.ToString();

		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		inputVector = Vector3.zero;
		joystickImage.rectTransform.anchoredPosition = inputVector;
		text.text = inputVector.ToString();
	}

	public void OnPointerDown(PointerEventData eventData) {
		OnDrag(eventData);
	}

	public Vector3 GetDirection() {
		return inputVector;
	}
}
