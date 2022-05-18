using Papers.UDC.Utilities.DeveloperConsole.Commands;
using UnityEngine;
using TMPro;

namespace Papers.UDC.Utilities.DeveloperConsole 
{
    public class DeveloperConsoleBehaviour : MonoBehaviour
    {
        [SerializeField] private string _prefix = string.Empty;
        [SerializeField] private ConsoleCommand[] _commands = new ConsoleCommand[0];

        [Header("UI")]
        [SerializeField] private GameObject _uiCanvas = null;
        [SerializeField] private TMP_InputField _inputField = null;

        private float pausedTimeScale;

        private static DeveloperConsoleBehaviour instance;

        private DeveloperConsole developerConsole;

        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if(developerConsole != null) { return developerConsole; }
                return developerConsole = new DeveloperConsole(_prefix, _commands);
            }
        }

        private void Awake()
        {
            if(instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Console"))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            if (_uiCanvas.activeSelf)
            {
                Time.timeScale = pausedTimeScale;
                _uiCanvas.SetActive(false);
            }
            else
            {
                pausedTimeScale = Time.timeScale;
                Time.timeScale = 0;
                _uiCanvas.SetActive(true);
                _inputField.ActivateInputField();
            }
        }

        public void ProcessCommand(string inputValue)
        {
            DeveloperConsole.ProcessCommand(inputValue);

            _inputField.text = string.Empty;
        }
    }
}

