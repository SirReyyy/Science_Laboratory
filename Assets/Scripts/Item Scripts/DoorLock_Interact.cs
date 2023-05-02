using UnityEngine;

public class DoorLock_Interact : MonoBehaviour, IInteractable {
    public Transform doorTransform;
    Vector3 initialPosition, newPosition, difference;
    bool isClose;
    int interpolationFramesCount = 60;
	int elapsedFrame = 0;
    float interpolationRatio;

    void Start() {
        initialPosition = new Vector3(22.8f, 0.0f, 0.0f);
        newPosition = new Vector3(17.0f, 0.0f, 0.0f);
    } //-- Start() --

    void Update() {
        interpolationRatio = (float)elapsedFrame/interpolationFramesCount;
    }

    public void Interact() {
        Debug.Log("door interact");

        if(isClose) {
            doorTransform.localPosition = Vector3.Lerp(initialPosition, newPosition, interpolationRatio);

            isClose = false;
        } else {
            doorTransform.localPosition = Vector3.Lerp(newPosition, initialPosition, interpolationRatio);

            isClose = true;
        }

        elapsedFrame = (elapsedFrame + 1) % (interpolationFramesCount + 1);
       
    } //-- Interact() --
}


/*

Made by : Rey M. Oronos, Jr.
Project : Science Laboratory

*/