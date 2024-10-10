using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animation_Controller  : MonoBehaviour
{
    #region Variables
    Animator m_animator;

    [Header("Animation Properties")]
    [Tooltip("��������޸�")]
    public AnimatorOverrideController animationStyle;
    RuntimeAnimatorController m_animationOrigin;

    [Header("Animation Set Properties")]
    [Tooltip("����״̬�л�Ԥ�裬�����������ò㼶Ϊ���б�����")]
    public List<Animation_Object> AnimationSets;

    Dictionary<int, Animation_Processer> m_processersDic = new Dictionary<int, Animation_Processer>();
    #endregion

    #region BuiltIn Methods
    void Awake()
    {
        InitAnimationController();
    }

    void Update()
    {
        UpdateAnimationProcess();
        UpdateAnimationStyle();
    }
    #endregion

    #region Init
    void InitAnimationController()
    {
        m_animator = GetComponent<Animator>();
        m_animationOrigin = m_animator.runtimeAnimatorController;

        // ��ʼ�����ɴ����ű�
        for(int i = 0; i < AnimationSets.Count; i++) 
        {
            Animation_Processer tmpProcesser = new Animation_Processer();
            // ע��ű�
            tmpProcesser.Init();
            m_processersDic.Add(i, tmpProcesser);
            tmpProcesser.Register(m_animator, AnimationSets[i], i);
        }
    }
    #endregion

    #region Update Animation Process
    void UpdateAnimationProcess()
    {
        for(int i = 0;i < m_processersDic.Count; i++) 
        {
            m_processersDic[i].ProcessAnimation();
        }
    }

    void UpdateAnimationStyle()
    {
        if (animationStyle)
            m_animator.runtimeAnimatorController = animationStyle;
        else
            m_animator.runtimeAnimatorController = m_animationOrigin;
    }
    #endregion

    #region Play Methods
    /// <summary>
    /// ����״̬����(Update)
    /// </summary>
    /// <param name="animationName"></param>
    public void PlayStateAnimation(string animationName, int layer)
    {
        m_processersDic[layer].PlayStateAnimation(animationName);
    }

    /// <summary>
    /// ���Ų��붯��(����ı�״̬����)(Trigger)
    /// </summary>
    /// <param name="playableIndex"></param>
    public void PlayPlayableAnimation(string animationName, int layer)
    {
        m_processersDic[layer].PlayPlayableAnimation(animationName);
    }
    #endregion
    public void HandleDeg(float deg ,float fixedDeg)
    {
        m_animator.SetFloat("Deg",deg,0.15f,Time.deltaTime);
        m_animator.SetFloat("FixedDeg",fixedDeg);
    }
    #region Animation Parameter Handle Methods
    #endregion
}
