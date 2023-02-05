using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSlider : MonoBehaviour
{
    [SerializeField] private Grappler grappler;
    [SerializeField] private Slider slider;
    [SerializeField] private bool IsSwing;
    // Start is called before the first frame update
    void Start()
    {
        grappler = GameObject.FindGameObjectWithTag("Player").GetComponent<Grappler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSwing == true)
        {
            slider.value = grappler.SwingCooldown / grappler.MaxCooldown;
        }
        else
        {
            slider.value = grappler.GrappleCooldown / grappler.MaxCooldown;
        }
    }
}
