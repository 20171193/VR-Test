using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ������Ʈ�� ���带 ������ �������, ȯ������, UI ���� ����
/// Enum �������� ���带 ����
/// </summary>
public class SoundManager : MonoBehaviour
{
    public enum BGMType { Main, Title, Stage1, Stage2, Stage3 }

    [Header("Components")]
    [Space(5)]
    [Header("������� �ҽ�")]
    [SerializeField]
    private AudioSource bgmSource;
    [Header("������� Ŭ��")]
    [Tooltip("����, Ÿ��Ʋ, ��������1, ��������2, ��������3")]
    private AudioClip[] bgmClips;

    public enum AMBType { }

    [Header("ȯ���� �ҽ�")]
    [SerializeField]
    private AudioSource[] ambSources;

    [Header("ȯ���� Ŭ��")]
    [Tooltip("")]
    private AudioClip[] ambClips;

    public enum SFXType { }

    [Header("ȿ���� �ҽ�")]
    [SerializeField]
    private AudioSource sfxSource;
    [Header("ȿ���� Ŭ��")]
    [Tooltip("")]
    private AudioClip[] sfxClips;

    #region ����� ����/����
    public void PlayBGM(BGMType type)
    {
        int playIndex = (int)type;
        // Ŭ�� �ε��� ������ ��� ���
        if (bgmClips.Length < playIndex)
        { 
            Debug.Log("error bgmClips index out of range");
            return;
        }
        // ������� ������� ���
        if(bgmSource.isPlaying)
            bgmSource.Stop();

        bgmSource.clip = bgmClips[playIndex];
        bgmSource.Play();
    }
    public void StopBGM()
    {
        // ������� ������� �ƴ� ���
        if (!bgmSource.isPlaying)
            return;
       
        bgmSource.Stop();
    }
    #endregion
    #region ȿ����
    public void PlaySFX(SFXType type)
    {
        int playIndex = (int)type;
        // Ŭ�� �ε��� ������ ��� ���
        if (sfxClips.Length < playIndex)
        {
            Debug.Log("error bgmClips index out of range");
            return;
        }
        // ȿ������ ������� ���
        if (sfxSource.isPlaying)
            sfxSource.Stop();

        sfxSource.clip = sfxClips[playIndex];
        sfxSource.Play();
    }
    public void StopSFX()
    {
        // ȿ������ ������� �ƴ� ���
        if (!sfxSource.isPlaying)
            return;

        sfxSource.Stop();
    }
    #endregion
    public void PlayAMB(AMBType type)
    {

    }
    public void StopAMB()
    {

    }
}
