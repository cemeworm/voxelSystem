using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hi5_Interaction_Interface;
using Hi5_Interaction_Core;
public class Hi5_Switch_Mode_Button : Hi5_Interface_Button
{
	internal bool isButtonTrigger = false;
	float cd = 0.8f;

	override public void MessageFun(string messageKey, object param1, object param2)
	{
		if (messageKey.CompareTo(Hi5_Glove_Interaction_Message.Hi5_MessageMessageKey.messageObjectEvent) == 0)
		{
			Hi5_Glove_Interaction_Object_Event_Data data = param1 as Hi5_Glove_Interaction_Object_Event_Data;
			if (data.mObjectId == ObjectItem.idObject)
			{
				if (data.mEventType == EEventObjectType.EClap)
				{
					ObjectItem.ChangeColor(Color.gray);
					if (!isButtonTrigger)
					{
						Hi5_Interaction_Message.GetInstance().DispenseMessage(Hi5_MessageKey.messageSwitchModeInput, null, null);
						isButtonTrigger = true;
					}

				}
				else if (data.mEventType == EEventObjectType.EPoke)
				{
					ObjectItem.ChangeColor(Color.red);
				}
				else if (data.mEventType == EEventObjectType.EStatic)
				{

				}
			}
		}
	}

	private void Update()
	{
		base.Update();
		if (isButtonTrigger)
		{
			cd -= Time.deltaTime;
			if (cd <= 0.0f)
			{
				cd = 0.5f;
				isButtonTrigger = false;
			}
		}
	}
}
