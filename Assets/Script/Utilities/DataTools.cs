using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTools
{
    //team memberµÄ×Ö·û´®ÇÐ¸îÎªList<int>
    public List<int> GetTeamMemberList(string teamMember)
    {
        if(teamMember == "")
        {
            return null;
        }
        string[] teamMembers = teamMember.Split(",");
        List<int> result = new List<int>();
        foreach(var member in teamMembers)
        {
            int temp = int.Parse(member);
            result.Add(temp);
        }
        return result;  
    }

    public List<string> GetTriggerNameList(string triggerName)
    {
        string[] triggerNames = triggerName.Split(",");
        List<string> result = new List<string>();
        foreach(var trigger in triggerNames)
        {
            string temp = trigger;
            result.Add(temp);
        }
        return result;
    }

    public List<string> GetChoicesList(string choicesString)
    {
        List<string> result = new List<string>();
        string[] choices = choicesString.Split(";");
        foreach(var choice in choices)
        {
            result.Add(choice);
        }
        return result;
    }

    public GameObject GetChildWithTag(GameObject farher,string tag)
    {
        foreach (Transform child in farher.transform)
        {
            if(child.tag == tag)
            {
                return child.gameObject;
            }

        }
        return null;

    }
    public GameObject GetChildWithName(GameObject farher, string name)
    {
        foreach (Transform child in farher.transform)
        {
            if (child.name == name)
            {
                return child.gameObject;
            }

        }
        return null;

    }

}
