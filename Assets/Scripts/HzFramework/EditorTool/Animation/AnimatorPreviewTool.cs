#if ODIN_INSPECTOR
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;

/// <summary>
/// 模型动画预览器
/// 使用方式：
///     绑在拥有Animator组件的对象上，拖入场景后即可查看
/// </summary>
[ExecuteInEditMode]
public class AnimatorPreviewTool : MonoBehaviour
{
    [LabelText("动画名"), ValueDropdown("_clips"), OnValueChanged("ChangeAnimation")]
    public AnimationClip CurrentClip;
    private AnimationClip[] _clips; // store all clips.

    //    [LabelText("状态名"), ValueDropdown("_states")]
    //    public string CurrentState;
    //    private string[] _states;

    [LabelText("动画长度"), PropertyRange(0f, "_clipLength"), OnValueChanged("ChangeSamples")]
    [DisableIf("@this.CurrentClip == null")]
    public float AnimationLength;
    private float _clipLength;      // use for range.

    private Animator _animator;
    private float _frameGap = 0.03f;    // 跳帧间隔

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _clips = AnimationUtility.GetAnimationClips(_animator.gameObject);
    }

    public void CustomUpdate()
    {
        if (CurrentClip != null)
        {
            if (_isPlaying)
            {
                AnimationLength += Time.deltaTime;

                if (AnimationLength >= CurrentClip.length)
                {
                    if (!_isLooping)
                    {
                        _isPlaying = false;
                    }
                    AnimationLength = 0f;
                }

            }
            CurrentClip.SampleAnimation(_animator.gameObject, AnimationLength);
        }
    }

    void OnDisable()
    {
        UnResgisterUpdate();
    }

    void OnEnable()
    {
        RegisterUpdate();
    }

    private void RegisterUpdate()
    {
        EditorApplication.update += CustomUpdate;
    }

    private void UnResgisterUpdate()
    {
        EditorApplication.update -= CustomUpdate;
    }

    private void ChangeAnimation()
    {
        if (CurrentClip != null)
        {
            _clipLength = CurrentClip.length;
        }
    }

    private void ChangeSamples()
    {
        if (CurrentClip != null)
        {
            _isPlaying = false;
            _isLooping = false;
        }
    }

    [HorizontalGroup("Operation"), Button("||◀")]
    [DisableIf("@this.CurrentClip == null")]
    private void FirstFrame()
    {
        _isPlaying = false;
        AnimationLength = 0f;
    }

    [HorizontalGroup("Operation"), Button("|◀")]
    [DisableIf("@this.CurrentClip == null")]
    private void PreFrame()
    {
        _isPlaying = false;
        AnimationLength = Mathf.Clamp(AnimationLength -= _frameGap, 0f, _clipLength);
    }

    private bool _isPlaying;
    [HorizontalGroup("Operation"), Button("@this._isPlaying?\"||\":\"▶\"")]
    [DisableIf("@this.CurrentClip == null")]
    private void Play()
    {
        _isPlaying = !_isPlaying;
        _isLooping = false;
    }

    [HorizontalGroup("Operation"), Button("■")]
    [DisableIf("@this.CurrentClip == null")]
    private void Stop()
    {
        _isPlaying = false;
        _isLooping = false;
        AnimationLength = 0f;
    }

    [HorizontalGroup("Operation"), Button("▶|")]
    [DisableIf("@this.CurrentClip == null")]
    private void NextFrame()
    {
        _isPlaying = false;
        AnimationLength = Mathf.Clamp(AnimationLength += _frameGap, 0f, _clipLength);
    }

    [HorizontalGroup("Operation"), Button("▶||")]
    [DisableIf("@this.CurrentClip == null")]
    private void LastFrame()
    {
        _isPlaying = false;
        AnimationLength = _clipLength;
    }

    private bool _isLooping;
    [HorizontalGroup("Operation"), Button("循环")]
    [DisableIf("@this.CurrentClip == null")]
    private void LoopPlay()
    {
        _isPlaying = true;
        _isLooping = true;
    }
}
#endif
