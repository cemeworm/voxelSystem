using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hi5_Interaction_Interface;

namespace Hi5_Interaction_Core
{

    public class Hi5InputController : MonoBehaviour
    {

        private Hi5_Object_JudgeMent hi5_object_judgeMent_1;
        private Hi5_Object_JudgeMent hi5_object_judgeMent_2;
        public Hi5_Switch_Mode_Button hi5_switch_mode_button;
        public Hi5_World_Menu_Button hi5_world_menu_button;
        public Hi5_Glove_Interaction_Hand HI5_Left_Human_Collider;
        public Hi5_Glove_Interaction_Hand HI5_Right_Human_Collider;
        private Hi5_Glove_Interaction_State hi5_Glove_Interaction_State_1;
        private Hi5_Glove_Interaction_State hi5_Glove_Interaction_State_2;
        public Hi5Button World_Menu_Button;
        public Hi5Button Switch_Mode_Button;
        public Hi5ButtonRect ButtonCreate;
        public Hi5ButtonRect ButtonSwitch;
        public Hi5ButtonRect ButtonSave;
        public Hi5ButtonRect ButtonLoad;
        public Hi5ButtonRect ButtonAnd;
        public Hi5ButtonRect ButtonOr;
        public Hi5ButtonRect ButtonNot;
        public WorldOptions worldOptions;
        public MergeOptions mergeOptions;
        public ObjectManipulator objectManipulator;

        public int selectObjectInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsHandIndexPoint() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    Debug.Log("selectObjectInput");
                    state = 1;
                }

                else
                {
                    state = 0;
                }
            return state;
        }

        public int createObjectInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsHandFist() && hi5_object_judgeMent_2.IsHandFist())
                {
                    Debug.Log("creatingObjectInput");
                    state = 2;
                }

                else if (hi5_object_judgeMent_2.IsHandFist())
                {
                    Debug.Log("createObjectInput");
                    state = 1;
                }
                else
                {
                    state = 0;
                }
            return state;
        }

        public int deleteObjectInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsFingerPlane() && hi5_object_judgeMent_2.IsFingerPlane())
                {
                    state = 1;
                }

                else
                {
                    state = 0;
                }
            return state;
        }


        public int copyObjectInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsHandIndexPoint() && hi5_object_judgeMent_2.IsHandFist())
                {
                    state = 1;
                }
                else
                {
                    state = 0;
                }
            return state;
        }

        public int moveObjectInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsHandFist() && hi5_object_judgeMent_2.IsFingerPlane())
                {
                    Debug.Log("movingObjectInput");
                    state = 2;
                }

                else if (hi5_object_judgeMent_1.IsHandFist())
                {
                    Debug.Log("moveObjectInput");
                    state = 1;
                }
                else
                {
                    state = 0;
                }
            return state;
        }

        /*public int rotateObjectInput()
        {
        int state;
        if (hi5_object_judgeMent.IsHandFist() && RecordGesState == "Fist")
        {
        state = 2;
        }

        else if (hi5_object_judgeMent.IsHandFist())
        {
        state = 1;
        RecordGesState = "Fist";
        }
        else
        {
        state = 0;
        RecordGesState = "None";
        }

        return state;
        }*/

        public int combineObjectInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsOK() && hi5_object_judgeMent_2.IsOK())
                {
                    Debug.Log("combineObjectInput");
                    state = 1;
                }
                else
                {
                    state = 0;
                }
            return state;
        }

        public int createVoxelInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsHandFist() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    Debug.Log("createVoxelInput");
                    state = 1;
                }
                else
                {
                    state = 0;
                }
            return state;
        }

        public int deleteVoxelInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsFingerPlane() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    Debug.Log("deleteVoxelInput");
                    state = 1;
                }

                else
                {
                    state = 0;
                }
            return state;
        }

        public int selectVoxelInput()
        {
            int state = 0;
                if (hi5_object_judgeMent_1.IsHandIndexPoint() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    Debug.Log("selectVoxelInput");
                    state = 1;
                }

                else
                {
                    state = 0;
                }
            return state;
        }

        public int selectFaceInput()
        {
            int state = 0;
               /* if (hi5_object_judgeMent_1.IsHandIndexPoint() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    Debug.Log("selectFacecInput");
                    state = 2;
                }

                else if (hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    state = 1;
                }
                else
                {
                    state = 0;
                }*/
            return state;
        }

        public int pullFaceInput()
        {
            int state = 0;
                /*if (hi5_object_judgeMent_1.IsHandFist() && hi5_object_judgeMent_2.IsFingerPlane())
                {
                    Debug.Log("pullFaceInput");
                    state = 2;
                }

                else if (hi5_object_judgeMent_2.IsHandFist())
                {
                    Debug.Log("pullFaceInput");
                    state = 1;
                }
                else
                {
                    state = 0;
                }*/
            return state;
        }

        public int switchModeInput()
        {
            int state = 0;

                if (Switch_Mode_Button.IsTouch())
                {
                    state = 1;
                Debug.Log("switchModeInput"+state);
            }

                else
                {
                    state = 0;
                }
            return state;
        }

        public int worldMenuInput()
        {
            int state;
                if (World_Menu_Button.IsTouch())
                {
                    Debug.Log("worldMenuInput");
                    state = 1;
                }

                else
                {
                    state = 0;
                }
            return state;
        }

        public int teleportInput()
        {
            int state;

                if (hi5_object_judgeMent_1.IsHandIndexPoint() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    state = 2;
                }

                else if (hi5_object_judgeMent_1.IsHandIndexPoint())
                {
                    state = 1;
                }
                else
                {
                    state = 0;
                }
            return state;
        }


        // Start is called before the first frame update
        private void Awake()
        {
        }

        private void Start()
        {
            hi5_object_judgeMent_1 = new Hi5_Object_JudgeMent();
            hi5_object_judgeMent_2 = new Hi5_Object_JudgeMent();
            HI5_Left_Human_Collider = GameObject.Find("HI5_Left_Human_Collider").GetComponent<Hi5_Glove_Interaction_Hand>();
            HI5_Right_Human_Collider = GameObject.Find("HI5_Right_Human_Collider").GetComponent<Hi5_Glove_Interaction_Hand>();
            hi5_Glove_Interaction_State_1 = null;
            hi5_Glove_Interaction_State_2 = null;
            hi5_object_judgeMent_1.mStateManager = hi5_Glove_Interaction_State_1;
            hi5_object_judgeMent_2.mStateManager = hi5_Glove_Interaction_State_2;
            hi5_object_judgeMent_1.Hand = HI5_Left_Human_Collider;
            hi5_object_judgeMent_2.Hand = HI5_Right_Human_Collider;
            World_Menu_Button = GameObject.Find("World_Menu_Button").GetComponent<Hi5Button>();
            Switch_Mode_Button = GameObject.Find("Switch_Mode_Button").GetComponent<Hi5Button>();
            ButtonCreate = GameObject.Find("ButtonCreate").GetComponent<Hi5ButtonRect>();
            ButtonSwitch = GameObject.Find("ButtonSwitch").GetComponent<Hi5ButtonRect>();
            ButtonSave = GameObject.Find("ButtonSave").GetComponent<Hi5ButtonRect>();
            ButtonLoad = GameObject.Find("ButtonLoad").GetComponent<Hi5ButtonRect>();
            ButtonAnd = GameObject.Find("ButtonAnd").GetComponent<Hi5ButtonRect>();
            ButtonOr = GameObject.Find("ButtonOr").GetComponent<Hi5ButtonRect>();
            ButtonNot = GameObject.Find("ButtonNot").GetComponent<Hi5ButtonRect>();
            mergeOptions = GameObject.Find("MergeMenu").GetComponent<MergeOptions>();
            worldOptions = GameObject.Find("WorldMenu").GetComponent<WorldOptions>();
            objectManipulator = GameObject.Find("ObjectManipulator").GetComponent<ObjectManipulator>();
        }

        // Update is called once per frame
        private void Update()
        {

        }

        internal void WorldChange()
        {
            if (worldOptions.gameObject.activeSelf)
            {
                Debug.Log("worldOptions.gameObject.activeSelf");
                ButtonCreate.setButtonPosition(0.1f);
                /*Debug.Log("button  "+"x:" + ButtonCreate.buttonPosition.x + " y:" + ButtonCreate.buttonPosition.y + " z:" + ButtonCreate.buttonPosition.y);
                    Debug.Log("finger  "+"x:" + HI5_Right_Human_Collider.mFingers[Hi5_Glove_Interaction_Finger_Type.EIndex].mChildNodes[4].transform.position.x + " y:" + HI5_Right_Human_Collider.mFingers[Hi5_Glove_Interaction_Finger_Type.EIndex].mChildNodes[4].transform.position.y + " z:" + HI5_Right_Human_Collider.mFingers[Hi5_Glove_Interaction_Finger_Type.EIndex].mChildNodes[4].transform.position.z);*/
                if (ButtonCreate.IsTouch() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    worldOptions.OnPressForCreate();
                }
                ButtonSwitch.setButtonPosition(0.0f);
                Debug.Log(ButtonSwitch.buttonPosition);
                if (ButtonSwitch.IsTouch() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    worldOptions.OnPressForSwitch();
                }
                ButtonSave.setButtonPosition(-0.1f);
                Debug.Log(ButtonSave.buttonPosition);
                if (ButtonSave.IsTouch() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    worldOptions.OnPressForSave();
                }
                ButtonLoad.setButtonPosition(-0.2f);
                Debug.Log(ButtonLoad.buttonPosition);
                if (ButtonLoad.IsTouch() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    worldOptions.OnPressForLoad();
                }
            }
            else if (mergeOptions.gameObject.activeSelf)
            {
                Debug.Log("mergeOptions.gameObject.activeSelf");
                ButtonAnd.setButtonPosition(0.0f);
                if (ButtonAnd.IsTouch() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    mergeOptions.OnPressForAdd();
                }
                ButtonOr.setButtonPosition(-0.1f);
                if (ButtonOr.IsTouch() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    mergeOptions.OnPressForOr();
                }
                ButtonNot.setButtonPosition(-0.2f);
                if (ButtonNot.IsTouch() && hi5_object_judgeMent_2.IsHandIndexPoint())
                {
                    mergeOptions.OnPressForNot();
                }
            }
        }
    }
}
