using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 오브젝트의 사운드를 제외한 배경음악, 환경음악, UI 사운드 관리
/// Enum 형식으로 사운드를 관리
/// </summary>
public class SoundManager : MonoBehaviour
{
    public enum BGMType { Main, Title, Stage1, Stage2, Stage3 }

    [Header("Components")]
    [Space(5)]
    [Header("배경음악 소스")]
    [SerializeField]
    private AudioSource bgmSource;
    [Header("배경음악 클립")]
    [Tooltip("메인, 타이틀, 스테이지1, 스테이지2, 스테이지3")]
    private AudioClip[] bgmClips;

    public enum AMBType { }

    [Header("환경음 소스")]
    [SerializeField]
    private AudioSource[] ambSources;

    [Header("환경음 클립")]
    [Tooltip("")]
    private AudioClip[] ambClips;

    public enum SFXType { }

    [Header("효과음 소스")]
    [SerializeField]
    private AudioSource sfxSource;
    [Header("효과음 클립")]
    [Tooltip("")]
    private AudioClip[] sfxClips;

    #region 배경음 시작/종료
    public void PlayBGM(BGMType type)
    {
        int playIndex = (int)type;
        // 클립 인덱스 범위를 벗어난 경우
        if (bgmClips.Length < playIndex)
        { 
            Debug.Log("error bgmClips index out of range");
            return;
        }
        // 배경음이 재생중인 경우
        if(bgmSource.isPlaying)
            bgmSource.Stop();

        bgmSource.clip = bgmClips[playIndex];
        bgmSource.Play();
    }
    public void StopBGM()
    {
        // 배경음이 재생중이 아닌 경우
        if (!bgmSource.isPlaying)
            return;
       
        bgmSource.Stop();
    }
    #endregion
    #region 효과음
    public void PlaySFX(SFXType type)
    {
        int playIndex = (int)type;
        // 클립 인덱스 범위를 벗어난 경우
        if (sfxClips.Length < playIndex)
        {
            Debug.Log("error bgmClips index out of range");
            return;
        }
        // 효과음이 재생중인 경우
        if (sfxSource.isPlaying)
            sfxSource.Stop();

        sfxSource.clip = sfxClips[playIndex];
        sfxSource.Play();
    }
    public void StopSFX()
    {
        // 효과음이 재생중이 아닌 경우
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
