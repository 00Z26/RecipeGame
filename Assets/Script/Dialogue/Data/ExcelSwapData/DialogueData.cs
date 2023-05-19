using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class DialogueData : ScriptableObject
{
	public List<DialogueStruct> dialogueList; // Replace 'EntityType' to an actual type that is serializable.
}
