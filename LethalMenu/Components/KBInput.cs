﻿using UnityEngine;
using UnityEngine.InputSystem;

namespace LethalMenu.Components;

internal class KBInput : MonoBehaviour
{
    private float sprintMultiplier = 1f;


    private void Update()
    {
        if (Cursor.visible) return;

        var input = new Vector3();

        if (Keyboard.current.wKey.isPressed) input += transform.forward;
        if (Keyboard.current.sKey.isPressed) input -= transform.forward;
        if (Keyboard.current.aKey.isPressed) input -= transform.right;
        if (Keyboard.current.dKey.isPressed) input += transform.right;
        if (Keyboard.current.spaceKey.isPressed) input += transform.up;
        if (Keyboard.current.ctrlKey.isPressed) input -= transform.up;

        if (input.Equals(Vector3.zero)) return;

        sprintMultiplier = Keyboard.current.shiftKey.isPressed
            ? Mathf.Min(sprintMultiplier + 5f * Time.deltaTime, 5f)
            : 1f;
        transform.position += input * Time.deltaTime * Settings.f_inputMovementSpeed * sprintMultiplier;
    }
}