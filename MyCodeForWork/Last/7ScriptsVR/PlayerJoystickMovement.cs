using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.Rendering.PostProcessing;

public class PlayerJoystickMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private SteamVR_Action_Vector2 moveInput;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private PostProcessVolume volume;

    [SerializeField]
    private Vignette vignette;

    private void Update()
    {
        Vector3 input = new Vector3(moveInput.axis.x, 0, moveInput.axis.y);
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(input);

        controller.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.8f, 0));

        volume.profile.TryGetSettings(out vignette);
        float intensity = Mathf.Lerp(vignette.intensity.value, input.normalized.magnitude * 0.7f, Time.deltaTime * 5);
        vignette.intensity.value = intensity;
    }
}
