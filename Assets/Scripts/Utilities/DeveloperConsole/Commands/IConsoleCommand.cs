using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Papers.UDC.Utilities.DeveloperConsole.Commands
{
    public interface IConsoleCommand
    {
        string CommandWord { get; }
        bool Process(string[] args);
    }
}

