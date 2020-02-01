using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog m_Dialog;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DialogManager.Instance.BeginDialog(m_Dialog);
        }
    }
}
