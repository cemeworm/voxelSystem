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
    private Hi5Laser hi5Laser;

    private void Awake()
    {
        vrcon = GameObject.Find("Hi5InputController").GetComponent<Hi5InputController>();
        this.hi5Laser = vrcon.HI5_Right_Human_Collider.GetComponent<Hi5Laser>();
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
                Physics.Raycast(new Ray(hi5Laser.transform.position, hi5Laser.transform.forward), out hit);
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
                hitPoint.position = hi5Laser.transform.position;

            }

        }
        
        

    }

    public void ToggleVRPointer(bool active)
    {
        if (ToolManager.Instance.Imode == ToolManager.InteractionMode.Desktop)
        {
            this.hi5Laser.enabled = false;
        }
        else
        {
            this.hi5Laser.enabled = active;
        }
    }
}