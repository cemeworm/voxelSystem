using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Hi5_Interaction_Core;

/// <summary>
/// 管理交互的内容与形式
/// </summary>
public class ToolManager : Singleton<ToolManager>
{
    public VoxelPlacer voxelPlacer;
    public FaceStretcher faceStretcher;
    public ObjectManipulator objectManipulator;
    //public ObjectSelector objectSelector;
    private Hi5InputController vrcon;
    public UnityEngine.TextMesh Switch_Mode_Button_Text;
    public static int Id;

    public enum ToolMode
    {
        PlaceVoxel,
        FaceStretch,
        ObjectManipulation
    }
    public ToolMode Tmode;
    public enum InteractionMode
    {
        Desktop,
        VR
    }
    public InteractionMode Imode;

    private void Start()
    {
        this.Imode = InteractionMode.VR;
        vrcon = GameObject.Find("Hi5InputController").GetComponent<Hi5InputController>();
        Switch_Mode_Button_Text = GameObject.Find("Switch_Mode_Button/Switch_Text").GetComponent<TextMesh>();
        Debug.Log("text:"+Switch_Mode_Button_Text.text);
        objectManipulator = GameObject.Find("ObjectManipulator").GetComponent<ObjectManipulator>();
/*        objectSelector = GameObject.Find("ObjectSelector").GetComponent<ObjectSelector>();*/

        ToolModeSwitching();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update:toolmanager");
        ToolModeUpdate();
        InteractionModeUpdate();
        
    }

    private void ToolModeUpdate()
    {
        if (Imode == InteractionMode.Desktop)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Tmode = ToolMode.ObjectManipulation;
                ToolModeSwitching();
            }
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                if (objectManipulator.objectSelector.selectedObjects.Count != 0)
                {
                    Tmode = ToolMode.PlaceVoxel;
                    ToolModeSwitching();
                }
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                if (objectManipulator.objectSelector.selectedObjects.Count != 0)
                {
                    Tmode = ToolMode.FaceStretch;
                    ToolModeSwitching();
                }
            }
        }
        else if (Imode == InteractionMode.VR)
        {
            if (vrcon.switchModeInput() == 1)
            {
                if (Tmode == ToolMode.ObjectManipulation && objectManipulator.objectSelector.selectedObjects.Count > 0)
                {
                    Tmode = ToolMode.PlaceVoxel;
                    ToolModeSwitching();
                }
                else if (Tmode == ToolMode.PlaceVoxel)
                {
                    Tmode = ToolMode.FaceStretch;
                    ToolModeSwitching();
                    voxelPlacer.targetObj.gameObject.GetComponent<Outline>().enabled = false;
                    voxelPlacer.targetObj.gameObject.GetComponent<Outline>().enabled = true;
                }
                else if (Tmode == ToolMode.FaceStretch)
                {
                    Tmode = ToolMode.ObjectManipulation;
                    ToolModeSwitching();
                    faceStretcher.targetObj.gameObject.GetComponent<Outline>().enabled = false;
                    faceStretcher.targetObj.gameObject.GetComponent<Outline>().enabled = true;
                }
                Debug.Log("Current Mode: "+Tmode);
            }
        }
    }

    private void ToolModeSwitching()
    {
        switch (Tmode)
        {
            case ToolMode.ObjectManipulation:
                objectManipulator.gameObject.SetActive(true);
                Switch_Mode_Button_Text.text = "object";
                voxelPlacer.gameObject.SetActive(false);
                faceStretcher.faceSelector.hitPointReader.ToggleVRPointer(false);
                faceStretcher.gameObject.SetActive(false);
                break;
            case ToolMode.PlaceVoxel:
                voxelPlacer.gameObject.SetActive(true);
                voxelPlacer.SetTargetObj();
                Switch_Mode_Button_Text.text = "voxel";
                objectManipulator.gameObject.SetActive(false);
                faceStretcher.gameObject.SetActive(false);
                break;
            case ToolMode.FaceStretch:
                faceStretcher.gameObject.SetActive(true);
                Switch_Mode_Button_Text.text = "face";
                faceStretcher.faceSelector.hitPointReader.ToggleVRPointer(true);
                faceStretcher.targetObj = voxelPlacer.targetObj;
                voxelPlacer.gameObject.SetActive(false);
                objectManipulator.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void InteractionModeUpdate()
    {
        // Switch to VR mode
        if (Input.GetKeyDown(KeyCode.F4) && Imode == InteractionMode.Desktop)
        {
            Imode = InteractionMode.VR;
            Debug.Log("InteractionMode.VR");
        }
        // VR to desktop
        if (Input.GetKeyDown(KeyCode.F5) && Imode == InteractionMode.VR)
        {
            Imode = InteractionMode.Desktop;
            Debug.Log("InteractionMode.Desktop");
        }
    }

    static public void highlightObject(GameObject obj, Color c, float width)
    {
            var outline = obj.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = c;
            outline.OutlineWidth = width;
    }

    static public void unHighlightObject(GameObject obj)
    {
        Destroy(obj.GetComponent<Outline>());
    }
}
