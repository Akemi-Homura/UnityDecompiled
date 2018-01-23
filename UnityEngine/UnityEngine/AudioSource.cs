﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.AudioSource
// Assembly: UnityEngine, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D290425A-E4B3-4E49-A420-29F09BB3F974
// Assembly location: C:\Program Files\Unity 5\Editor\Data\Managed\UnityEngine.dll

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine.Audio;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine
{
  /// <summary>
  ///   <para>A representation of audio sources in 3D.</para>
  /// </summary>
  [RequireComponent(typeof (Transform))]
  public sealed class AudioSource : Behaviour
  {
    internal AudioSourceExtension spatializerExtension = (AudioSourceExtension) null;
    internal AudioSourceExtension ambisonicExtension = (AudioSourceExtension) null;

    /// <summary>
    ///   <para>PanLevel has been deprecated. Use spatialBlend instead.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("AudioSource.panLevel has been deprecated. Use AudioSource.spatialBlend instead (UnityUpgradable) -> spatialBlend", true)]
    public float panLevel
    {
      get
      {
        return this.spatialBlend;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>Pan has been deprecated. Use panStereo instead.</para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("AudioSource.pan has been deprecated. Use AudioSource.panStereo instead (UnityUpgradable) -> panStereo", true)]
    public float pan
    {
      get
      {
        return this.panStereo;
      }
      set
      {
      }
    }

    /// <summary>
    ///   <para>The volume of the audio source (0.0 to 1.0).</para>
    /// </summary>
    public extern float volume { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The pitch of the audio source.</para>
    /// </summary>
    public extern float pitch { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Playback position in seconds.</para>
    /// </summary>
    public extern float time { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Playback position in PCM samples.</para>
    /// </summary>
    [ThreadAndSerializationSafe]
    public extern int timeSamples { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The default AudioClip to play.</para>
    /// </summary>
    [ThreadAndSerializationSafe]
    public extern AudioClip clip { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>The target group to which the AudioSource should route its signal.</para>
    /// </summary>
    public extern AudioMixerGroup outputAudioMixerGroup { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Plays the clip with an optional certain delay.</para>
    /// </summary>
    /// <param name="delay">Delay in number of samples, assuming a 44100Hz sample rate (meaning that Play(44100) will delay the playing by exactly 1 sec).</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Play([DefaultValue("0")] ulong delay);

    [ExcludeFromDocs]
    public void Play()
    {
      this.Play(0UL);
    }

    /// <summary>
    ///   <para>Plays the clip with a delay specified in seconds. Users are advised to use this function instead of the old Play(delay) function that took a delay specified in samples relative to a reference rate of 44.1 kHz as an argument.</para>
    /// </summary>
    /// <param name="delay">Delay time specified in seconds.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void PlayDelayed(float delay);

    /// <summary>
    ///   <para>Plays the clip at a specific time on the absolute time-line that AudioSettings.dspTime reads from.</para>
    /// </summary>
    /// <param name="time">Time in seconds on the absolute time-line that AudioSettings.dspTime refers to for when the sound should start playing.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void PlayScheduled(double time);

    /// <summary>
    ///   <para>Changes the time at which a sound that has already been scheduled to play will start.</para>
    /// </summary>
    /// <param name="time">Time in seconds.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetScheduledStartTime(double time);

    /// <summary>
    ///   <para>Changes the time at which a sound that has already been scheduled to play will end. Notice that depending on the timing not all rescheduling requests can be fulfilled.</para>
    /// </summary>
    /// <param name="time">Time in seconds.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetScheduledEndTime(double time);

    /// <summary>
    ///   <para>Stops playing the clip.</para>
    /// </summary>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void Stop();

    /// <summary>
    ///   <para>Pauses playing the clip.</para>
    /// </summary>
    public void Pause()
    {
      AudioSource.INTERNAL_CALL_Pause(this);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_Pause(AudioSource self);

    /// <summary>
    ///   <para>Unpause the paused playback of this AudioSource.</para>
    /// </summary>
    public void UnPause()
    {
      AudioSource.INTERNAL_CALL_UnPause(this);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_UnPause(AudioSource self);

    /// <summary>
    ///   <para>Is the clip playing right now (Read Only)?</para>
    /// </summary>
    public extern bool isPlaying { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>True if all sounds played by the AudioSource (main sound started by Play() or playOnAwake as well as one-shots) are culled by the audio system.</para>
    /// </summary>
    public extern bool isVirtual { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; }

    /// <summary>
    ///   <para>Plays an AudioClip, and scales the AudioSource volume by volumeScale.</para>
    /// </summary>
    /// <param name="clip">The clip being played.</param>
    /// <param name="volumeScale">The scale of the volume (0-1).</param>
    [ExcludeFromDocs]
    public void PlayOneShot(AudioClip clip)
    {
      float volumeScale = 1f;
      this.PlayOneShot(clip, volumeScale);
    }

    /// <summary>
    ///   <para>Plays an AudioClip, and scales the AudioSource volume by volumeScale.</para>
    /// </summary>
    /// <param name="clip">The clip being played.</param>
    /// <param name="volumeScale">The scale of the volume (0-1).</param>
    public void PlayOneShot(AudioClip clip, [DefaultValue("1.0F")] float volumeScale)
    {
      if ((Object) clip != (Object) null && clip.ambisonic)
      {
        AudioSourceExtension extension = AudioExtensionManager.AddAmbisonicDecoderExtension(this);
        if ((Object) extension != (Object) null)
          AudioExtensionManager.GetReadyToPlay(extension);
      }
      this.PlayOneShotHelper(clip, volumeScale);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void PlayOneShotHelper(AudioClip clip, [DefaultValue("1.0F")] float volumeScale);

    [ExcludeFromDocs]
    private void PlayOneShotHelper(AudioClip clip)
    {
      float volumeScale = 1f;
      this.PlayOneShotHelper(clip, volumeScale);
    }

    /// <summary>
    ///   <para>Plays an AudioClip at a given position in world space.</para>
    /// </summary>
    /// <param name="clip">Audio data to play.</param>
    /// <param name="position">Position in world space from which sound originates.</param>
    /// <param name="volume">Playback volume.</param>
    [ExcludeFromDocs]
    public static void PlayClipAtPoint(AudioClip clip, Vector3 position)
    {
      float volume = 1f;
      AudioSource.PlayClipAtPoint(clip, position, volume);
    }

    /// <summary>
    ///   <para>Plays an AudioClip at a given position in world space.</para>
    /// </summary>
    /// <param name="clip">Audio data to play.</param>
    /// <param name="position">Position in world space from which sound originates.</param>
    /// <param name="volume">Playback volume.</param>
    public static void PlayClipAtPoint(AudioClip clip, Vector3 position, [DefaultValue("1.0F")] float volume)
    {
      GameObject gameObject = new GameObject("One shot audio");
      gameObject.transform.position = position;
      AudioSource audioSource = (AudioSource) gameObject.AddComponent(typeof (AudioSource));
      audioSource.clip = clip;
      audioSource.spatialBlend = 1f;
      audioSource.volume = volume;
      audioSource.Play();
      Object.Destroy((Object) gameObject, clip.length * ((double) Time.timeScale >= 0.00999999977648258 ? Time.timeScale : 0.01f));
    }

    /// <summary>
    ///   <para>Is the audio clip looping?</para>
    /// </summary>
    public extern bool loop { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>This makes the audio source not take into account the volume of the audio listener.</para>
    /// </summary>
    public extern bool ignoreListenerVolume { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>If set to true, the audio source will automatically start playing on awake.</para>
    /// </summary>
    public extern bool playOnAwake { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Allows AudioSource to play even though AudioListener.pause is set to true. This is useful for the menu element sounds or background music in pause menus.</para>
    /// </summary>
    public extern bool ignoreListenerPause { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Whether the Audio Source should be updated in the fixed or dynamic update.</para>
    /// </summary>
    public extern AudioVelocityUpdateMode velocityUpdateMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Pans a playing sound in a stereo way (left or right). This only applies to sounds that are Mono or Stereo.</para>
    /// </summary>
    public extern float panStereo { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets how much this AudioSource is affected by 3D spatialisation calculations (attenuation, doppler etc). 0.0 makes the sound full 2D, 1.0 makes it full 3D.</para>
    /// </summary>
    public extern float spatialBlend { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    internal extern bool spatializeInternal { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Enables or disables spatialization.</para>
    /// </summary>
    public bool spatialize
    {
      get
      {
        return this.spatializeInternal;
      }
      set
      {
        if (this.spatializeInternal == value)
          return;
        this.spatializeInternal = value;
        if (value)
        {
          AudioSourceExtension extension = AudioExtensionManager.AddSpatializerExtension(this);
          if ((Object) extension != (Object) null && this.isPlaying)
            AudioExtensionManager.GetReadyToPlay(extension);
        }
      }
    }

    /// <summary>
    ///   <para>Determines if the spatializer effect is inserted before or after the effect filters.</para>
    /// </summary>
    public extern bool spatializePostEffects { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Set the custom curve for the given AudioSourceCurveType.</para>
    /// </summary>
    /// <param name="type">The curve type that should be set.</param>
    /// <param name="curve">The curve that should be applied to the given curve type.</param>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern void SetCustomCurve(AudioSourceCurveType type, AnimationCurve curve);

    /// <summary>
    ///   <para>Get the current custom curve for the given AudioSourceCurveType.</para>
    /// </summary>
    /// <param name="type">The curve type to get.</param>
    /// <returns>
    ///   <para>The custom AnimationCurve corresponding to the given curve type.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern AnimationCurve GetCustomCurve(AudioSourceCurveType type);

    /// <summary>
    ///   <para>The amount by which the signal from the AudioSource will be mixed into the global reverb associated with the Reverb Zones.</para>
    /// </summary>
    public extern float reverbZoneMix { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Bypass effects (Applied from filter components or global listener filters).</para>
    /// </summary>
    public extern bool bypassEffects { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>When set global effects on the AudioListener will not be applied to the audio signal generated by the AudioSource. Does not apply if the AudioSource is playing into a mixer group.</para>
    /// </summary>
    public extern bool bypassListenerEffects { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>When set doesn't route the signal from an AudioSource into the global reverb associated with reverb zones.</para>
    /// </summary>
    public extern bool bypassReverbZones { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets the Doppler scale for this AudioSource.</para>
    /// </summary>
    public extern float dopplerLevel { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets the spread angle (in degrees) of a 3d stereo or multichannel sound in speaker space.</para>
    /// </summary>
    public extern float spread { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets the priority of the AudioSource.</para>
    /// </summary>
    public extern int priority { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Un- / Mutes the AudioSource. Mute sets the volume=0, Un-Mute restore the original volume.</para>
    /// </summary>
    public extern bool mute { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Within the Min distance the AudioSource will cease to grow louder in volume.</para>
    /// </summary>
    public extern float minDistance { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>(Logarithmic rolloff) MaxDistance is the distance a sound stops attenuating at.</para>
    /// </summary>
    public extern float maxDistance { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets/Gets how the AudioSource attenuates over distance.</para>
    /// </summary>
    public extern AudioRolloffMode rolloffMode { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetOutputDataHelper(float[] samples, int channel);

    /// <summary>
    ///   <para>Deprecated Version. Returns a block of the currently playing source's output data.</para>
    /// </summary>
    /// <param name="numSamples"></param>
    /// <param name="channel"></param>
    [Obsolete("GetOutputData return a float[] is deprecated, use GetOutputData passing a pre allocated array instead.")]
    public float[] GetOutputData(int numSamples, int channel)
    {
      float[] samples = new float[numSamples];
      this.GetOutputDataHelper(samples, channel);
      return samples;
    }

    /// <summary>
    ///   <para>Provides a block of the currently playing source's output data.</para>
    /// </summary>
    /// <param name="samples">The array to populate with audio samples. Its length must be a power of 2.</param>
    /// <param name="channel">The channel to sample from.</param>
    public void GetOutputData(float[] samples, int channel)
    {
      this.GetOutputDataHelper(samples, channel);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private extern void GetSpectrumDataHelper(float[] samples, int channel, FFTWindow window);

    /// <summary>
    ///   <para>Deprecated Version. Returns a block of the currently playing source's spectrum data.</para>
    /// </summary>
    /// <param name="numSamples">The number of samples to retrieve. Must be a power of 2.</param>
    /// <param name="channel">The channel to sample from.</param>
    /// <param name="window">The FFTWindow type to use when sampling.</param>
    [Obsolete("GetSpectrumData returning a float[] is deprecated, use GetSpectrumData passing a pre allocated array instead.")]
    public float[] GetSpectrumData(int numSamples, int channel, FFTWindow window)
    {
      float[] samples = new float[numSamples];
      this.GetSpectrumDataHelper(samples, channel, window);
      return samples;
    }

    /// <summary>
    ///   <para>Provides a block of the currently playing audio source's spectrum data.</para>
    /// </summary>
    /// <param name="samples">The array to populate with audio samples. Its length must be a power of 2.</param>
    /// <param name="channel">The channel to sample from.</param>
    /// <param name="window">The FFTWindow type to use when sampling.</param>
    public void GetSpectrumData(float[] samples, int channel, FFTWindow window)
    {
      this.GetSpectrumDataHelper(samples, channel, window);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern int GetNumExtensionProperties();

    internal int GetNumExtensionPropertiesForThisExtension(PropertyName extensionName)
    {
      return AudioSource.INTERNAL_CALL_GetNumExtensionPropertiesForThisExtension(this, ref extensionName);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int INTERNAL_CALL_GetNumExtensionPropertiesForThisExtension(AudioSource self, ref PropertyName extensionName);

    internal PropertyName ReadExtensionName(int sourceIndex)
    {
      PropertyName propertyName;
      AudioSource.INTERNAL_CALL_ReadExtensionName(this, sourceIndex, out propertyName);
      return propertyName;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ReadExtensionName(AudioSource self, int sourceIndex, out PropertyName value);

    internal PropertyName ReadExtensionPropertyName(int sourceIndex)
    {
      PropertyName propertyName;
      AudioSource.INTERNAL_CALL_ReadExtensionPropertyName(this, sourceIndex, out propertyName);
      return propertyName;
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ReadExtensionPropertyName(AudioSource self, int sourceIndex, out PropertyName value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    internal extern float ReadExtensionPropertyValue(int sourceIndex);

    internal bool ReadExtensionProperty(PropertyName extensionName, PropertyName propertyName, ref float propertyValue)
    {
      return AudioSource.INTERNAL_CALL_ReadExtensionProperty(this, ref extensionName, ref propertyName, ref propertyValue);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool INTERNAL_CALL_ReadExtensionProperty(AudioSource self, ref PropertyName extensionName, ref PropertyName propertyName, ref float propertyValue);

    internal void WriteExtensionProperty(PropertyName pluginName, PropertyName extensionName, PropertyName propertyName, float propertyValue)
    {
      AudioSource.INTERNAL_CALL_WriteExtensionProperty(this, ref pluginName, ref extensionName, ref propertyName, propertyValue);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_WriteExtensionProperty(AudioSource self, ref PropertyName pluginName, ref PropertyName extensionName, ref PropertyName propertyName, float propertyValue);

    internal void ClearExtensionProperties(PropertyName extensionName)
    {
      AudioSource.INTERNAL_CALL_ClearExtensionProperties(this, ref extensionName);
    }

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void INTERNAL_CALL_ClearExtensionProperties(AudioSource self, ref PropertyName extensionName);

    internal AudioSourceExtension AddSpatializerExtension(System.Type extensionType)
    {
      if ((Object) this.spatializerExtension == (Object) null)
        this.spatializerExtension = ScriptableObject.CreateInstance(extensionType) as AudioSourceExtension;
      return this.spatializerExtension;
    }

    internal AudioSourceExtension AddAmbisonicExtension(System.Type extensionType)
    {
      if ((Object) this.ambisonicExtension == (Object) null)
        this.ambisonicExtension = ScriptableObject.CreateInstance(extensionType) as AudioSourceExtension;
      return this.ambisonicExtension;
    }

    [Obsolete("minVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
    public extern float minVolume { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("maxVolume is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
    public extern float maxVolume { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    [Obsolete("rolloffFactor is not supported anymore. Use min-, maxDistance and rolloffMode instead.", true)]
    public extern float rolloffFactor { [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] get; [GeneratedByOldBindingsGenerator, MethodImpl(MethodImplOptions.InternalCall)] set; }

    /// <summary>
    ///   <para>Sets a user-defined parameter of a custom spatializer effect that is attached to an AudioSource.</para>
    /// </summary>
    /// <param name="index">Zero-based index of user-defined parameter to be set.</param>
    /// <param name="value">New value of the user-defined parameter.</param>
    /// <returns>
    ///   <para>True, if the parameter could be set.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool SetSpatializerFloat(int index, float value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool GetSpatializerFloat(int index, out float value);

    /// <summary>
    ///   <para>Sets a user-defined parameter of a custom ambisonic decoder effect that is attached to an AudioSource.</para>
    /// </summary>
    /// <param name="index">Zero-based index of user-defined parameter to be set.</param>
    /// <param name="value">New value of the user-defined parameter.</param>
    /// <returns>
    ///   <para>True, if the parameter could be set.</para>
    /// </returns>
    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool SetAmbisonicDecoderFloat(int index, float value);

    [GeneratedByOldBindingsGenerator]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public extern bool GetAmbisonicDecoderFloat(int index, out float value);
  }
}
