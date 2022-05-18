using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Papers.UDC.Utilities.DeveloperConsole.Commands
{
    public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
    {
        [SerializeField] private string _commandWord = string.Empty;

        public string CommandWord => _commandWord;

        public abstract bool Process(string[] args);
    }
}
