using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Papers.UDC.Utilities.DeveloperConsole.Commands
{
    [CreateAssetMenu(fileName = "Default Savefile Command", menuName ="Utilites/DeveloperConsole/Commands/Impulse Command/DefaultSaveFileCommand")]
    public class DefaultSaveFileCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if(args.Length != 1) { Debug.LogError("Command Not Long Enough"); return false; }

            if(!float.TryParse(args[0], out float value))
            {
                if(value != 0)
                {
                    Debug.LogError("Impulse Value Not a Float");
                    return false;
                }
            }

            if (!GameObject.FindGameObjectWithTag("Player"))
            {
                Debug.LogError("No Player Object To Reset");
                return false;
            }

            Debug.Log("Resetting Data");
            DataManager.ResetPlayerDataToJSON();

            return true;
        }
    }
}

