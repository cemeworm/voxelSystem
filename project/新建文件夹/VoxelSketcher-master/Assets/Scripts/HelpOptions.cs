using UnityEngine;
using Hi5_Interaction_Core;
using System;

public class HelpOptions : MonoBehaviour
{
    public ObjectManipulator om;

    public void closeHelpMenu()
    {
        this.gameObject.SetActive(false);
    }
}
