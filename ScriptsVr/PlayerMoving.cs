using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Vector2 moveInput;

    [SerializeField]
    private float speed;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private PostProcessVolume volume;

    private Vignette _vignette;

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        Vector3 input = new Vector3(moveInput.axis.x, 0, moveInput.axis.y);
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(input);

        controller.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);

        volume.profile.TryGetSettings(out _vignette);

        float intensity = Mathf.Lerp(_vignette.intensity.value, input.normalized.magnitude * 0.7f, Time.deltaTime * 5);
        _vignette.intensity.value = intensity;
    }
}
