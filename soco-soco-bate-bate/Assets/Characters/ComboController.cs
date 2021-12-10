using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboController : MonoBehaviour
{
    private Animator anim;
    private Movement movement;
    public bool comboPossible;
    public int comboStep = 0;

    public string[] comboAnimationNames;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        movement = gameObject.GetComponent<Movement>();
    }

    public void Attack()
    {
        if (comboStep == 0)
        {
            anim.Play(comboAnimationNames[0]);
            comboStep = 1;
        }
        else
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
            else
            {
                ResetCombo();
            }
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void ResetCombo()
    {
        comboPossible = false;
        comboStep = 0;
        movement.isAttacking = false;
    }

    public void Combo()
    {
        if (comboStep > 1)
        {
            int index = comboStep - 1;
            if (index < comboAnimationNames.Length)
            {
                anim.Play(comboAnimationNames[index]); 
            }
        }
    }
}
