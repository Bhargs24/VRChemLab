using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grabbable : XRGrabInteractable
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        // Snap object to hand position and rotation
        args.interactorObject.transform.position = transform.position;
        args.interactorObject.transform.rotation = transform.rotation;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        // Release object
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
