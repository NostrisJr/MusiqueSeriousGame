using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    public static FMODEvents instance { get; private set; }
    [field: Header("Enigma opening SFX")]
    [field: SerializeField] public EventReference enigmaOpeningSFX { get; private set; }

    [field: Header("Ambiance Lv1")]
    [field: SerializeField] public EventReference ambianceLv1 { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There is already an instance of FMODEvents in the scene");
        }
    }
}
