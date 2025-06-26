using UnityEngine;
using UnityEngine.InputSystem;

public class UIButton : MonoBehaviour
{
    [Header("Trigger Settings")]
    public InputActionReference inputButton;
    public GameObject canvasToActivate;
    public ShowMessageFromList targetMessageList;

    [Tooltip("Optional: Deaktiviert andere Canvases")]
    public GameObject[] otherCanvasesToDisable;

    private bool isInside = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInside && inputButton != null && inputButton.action.WasPressedThisFrame())
        {
            if (targetMessageList != null)
                targetMessageList.NextMessage();
            if (canvasToActivate != null)
                canvasToActivate.SetActive(true);
            foreach (var other in otherCanvasesToDisable)
            {
                if (other != null)
                    other.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = false;
        }
    }
}