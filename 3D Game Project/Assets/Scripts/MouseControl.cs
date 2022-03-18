using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public bool lockCursor = true;
    private bool m_cursorIsLocked = true;

    private void Start()
    {
        m_cursorIsLocked = false;
        InternalLockUpdate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            InternalLockUpdate();
        }
    }

    public void InternalLockUpdate()
    {
        if (m_cursorIsLocked == true)
        {
            m_cursorIsLocked = false;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        }
        else if (m_cursorIsLocked == false)
        {
            m_cursorIsLocked = true;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}