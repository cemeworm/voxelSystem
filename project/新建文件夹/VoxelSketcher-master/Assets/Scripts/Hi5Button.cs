using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hi5_Interaction_Core
{
    public class Hi5Button : MonoBehaviour
    {
        internal bool isButtonTrigger = false;
        float cd = 0.8f;
        public Hi5_Glove_Interaction_Hand HI5_Left_Human_Collider;
        public Hi5_Glove_Interaction_Hand HI5_Right_Human_Collider;
        // Start is called before the first frame update
        void Start()
        {
            HI5_Left_Human_Collider = GameObject.Find("HI5_Left_Human_Collider").GetComponent<Hi5_Glove_Interaction_Hand>();
            HI5_Right_Human_Collider = GameObject.Find("HI5_Right_Human_Collider").GetComponent<Hi5_Glove_Interaction_Hand>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        internal bool IsTouch()
        {
            Transform tailIndex = HI5_Right_Human_Collider.mFingers[Hi5_Glove_Interaction_Finger_Type.EIndex].mChildNodes[4];
            
            float distance = Vector3.Distance(this.transform.position, tailIndex.position);
            if (distance < 0.05f)
            {
                return true;
            }
            else
                return false;
        }
    }
}