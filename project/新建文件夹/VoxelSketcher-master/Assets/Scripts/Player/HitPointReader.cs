using UnityEngine;
using Valve.VR.Extras;
using Hi5_Interaction_Core;

[System.Serializable]
public struct HitPoint
{
    public Vector3 position;
    public Vector3 normal;
}
public class HitPointReader : MonoBehaviour
{
    public HitPoint hitPoint;
    public bool hitting { get; private set; }

    private Hi5InputController vrcon;
    private SteamVR_LaserPointer laserPointer;

    private void Awake()
    {
        vrcon = GameObject.Find("Hi5InputController").GetComponent<Hi5InputController>();
        this.laserPointer = vrcon.HI5_Right_Human_Collider.GetComponent<SteamVR_LaserPointer>();
    }

    private void Update()
    {
        SelectVoxel();
    }

    private void SelectVoxel()
    {
        hitting = false;
        hitPoint.position = Vector3.zero;
        hitPoint.normal = Vector3.zero;

        RaycastHit hit;
        if (ToolManager.Instance.Imode == ToolManager.InteractionMode.Desktop)
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        }
        else // VR mode
        {
            if (ToolManager.Instance.Tmode == ToolManager.ToolMode.FaceStretch)
            {
                Physics.Raycast(new Ray(laserPointer.transform.position, laserPointer.transform.forward), out hit);
                if (hit.collider)
                {
                    hitting = true;
                    hitPoint.position = hit.point; // / WorldDataManager.Instance.ActiveWorld.worldSize;
                    hitPoint.normal = hit.normal;
                }
            }
            else
            {
                //hitPoint.position = vrcon.HI5_Right_Human_Collider.GetThumbAndMiddlePoint();
                hitPoint.position = laserPointer.transform.position;

            }

        }
        
        

    }

    public void ToggleVRPointer(bool active)
    {
        if (ToolManager.Instance.Imode == ToolManager.InteractionMode.Desktop)
        {
            this.laserPointer.enabled = false;
        }
        else
        {
            this.laserPointer.enabled = active;
        }
    }
}