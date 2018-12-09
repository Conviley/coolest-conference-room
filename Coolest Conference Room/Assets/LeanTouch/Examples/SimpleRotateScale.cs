using UnityEngine;

// This script will rotate and scale the GameObject based on finger gestures
public class SimpleRotateScale : MonoBehaviour
{
    private ArObject VideoPlaneController;

    private void Start() {
        VideoPlaneController = GetComponent<ArObject>();
    }

    protected virtual void LateUpdate()
	{
        if (VideoPlaneController.isSelected()) {
            // This will rotate the current transform based on a multi finger twist gesture
            Lean.LeanTouch.RotateObject(transform, Lean.LeanTouch.TwistDegrees);

            // This will scale the current transform based on a multi finger pinch gesture
            Lean.LeanTouch.ScaleObject(transform, Lean.LeanTouch.PinchScale);
        }
	}
}