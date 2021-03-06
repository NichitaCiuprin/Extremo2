﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FadeInOut))]
public class Death : MonoBehaviour
{
    public enum DeflectDirection
    {
        left = 0,
        right = 1,
        up = 2
    }
    public DeflectDirection deflectDirection;
    public enum State
    {
        idle = 0,
        deflect = 1,
        tierd = 2,
        dead = 3,
    }
    public State state;

    private Animator animator;
    public FadeInOut fadeInOut;

    public void Awake()
    {
        deflectDirection = DeflectDirection.left;
        state = State.idle;

        animator = GetComponent<Animator>();
        fadeInOut = GetComponent<FadeInOut>();
        fadeInOut.isDestroyOnFadeOut = true;
    }

    public void DeflectLeft()
    {
        if (this.state == State.dead) return;
        animator.SetTrigger("Deflect");
        state = State.deflect;
        deflectDirection = DeflectDirection.left;
    }
    public void DeflectRight()
    {
        if (this.state == State.dead) return;
        animator.SetTrigger("Deflect");
        state = State.deflect;
        deflectDirection = DeflectDirection.right;
    }
    public void DeflectUp()
    {
        if (this.state == State.dead) return;
        animator.SetTrigger("Deflect");
        state = State.deflect;
        deflectDirection = DeflectDirection.up;
    }
    public void AnimationEndDeath()
    {
        this.gameObject.SetActive(false);
    }
    public void ToIdleState()
    {
        this.state = Death.State.idle;
    }
    public void ToDeathState()
    {
        this.state = Death.State.dead;
        AudioManager.instance.PlaySound(AudioManager.instance.sound_death_death);
        fadeInOut.ForseFadeOut();
    }
    public void ToDeflectState()
    {
        this.state = Death.State.deflect;
        AudioManager.instance.PlaySound(AudioManager.instance.sound_death_deflect);
    }
    public void ToTierdState()
    {
        this.state = Death.State.tierd;
        AudioManager.instance.PlaySound(AudioManager.instance.sound_death_tierd);
    }
    public void Die()
    {
        animator.SetTrigger("Die");
    }
    public void Idle()
    {
        animator.SetTrigger("Idle");
    }
}


