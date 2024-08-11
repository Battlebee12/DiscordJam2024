using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private HealthEntity healthEntity;

    private void Update() {
        //Debug.Log("Loggin from progressbar: " + healthEntity.Health);
        bar.fillAmount = HealthNormalized();
    }
    private float HealthNormalized(){
        return healthEntity.Health/healthEntity.MaxHealth;
    }
}
