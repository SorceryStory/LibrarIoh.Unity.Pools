using SorceressSpell.LibrarIoh.Collections;
using SorceressSpell.LibrarIoh.Core;
using System;
using UnityEngine;
using UnityEngine.Audio;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public class AudioSourceProperties : ComponentProperties, IPoolObjectProperties<AudioSource>, IPoolObjectProperties<BehaviourPoolAudioSource>, ICopyFrom<AudioSourceProperties>
    {
        #region Enums

        [Flags]
        public enum Properties
        {
            None = 0,
            AudioClip = 1 << 0,
            StartingTime = 1 << 1,
            OutputAudioMixerGroup = 1 << 2,
            Mute = 1 << 3,
            BypassEffects = 1 << 4,
            BypassListenerEffects = 1 << 5,
            BypassReverbZones = 1 << 6,
            PlayOnAwake = 1 << 7,
            Loop = 1 << 8,
            Priority = 1 << 9,
            Volume = 1 << 10,
            Pitch = 1 << 11,
            StereoPan = 1 << 12,
            SpatialBlend = 1 << 13,
            ReverbZoneMix = 1 << 14,
            DopplerLevel = 1 << 15,
            Spread = 1 << 16,
            VolumeRolloff = 1 << 17,
            MinDistance = 1 << 18,
            MaxDistance = 1 << 19,
            VolumeCurve = 1 << 20,
            SpatialBlendCurve = 1 << 21,
            SpreadCurve = 1 << 22,
            ReverbZoneMixCurve = 1 << 23,
        }

        #endregion Enums

        #region Fields

        private AudioClip _audioClip;
        private bool _bypassEffects;
        private bool _bypassListenerEffects;
        private bool _bypassReverbZones;
        private Properties _changes;
        private float _dopplerLevel;
        private bool _loop;
        private float _maxDistance;
        private float _minDistance;
        private bool _mute;
        private AudioMixerGroup _outputAudioMixerGroup;
        private float _pitch;
        private bool _playOnAwake;
        private int _priority;
        private float _reverbZoneMix;
        private AnimationCurve _reverbZoneMixCurve;
        private float _spatialBlend;
        private AnimationCurve _spatialBlendCurve;
        private float _spread;
        private AnimationCurve _spreadCurve;
        private float _startingTime;
        private float _stereoPan;
        private float _volume;
        private AnimationCurve _volumeCurve;
        private AudioRolloffMode _volumeRolloff;

        #endregion Fields

        #region Properties

        public AudioClip AudioClip
        {
            set
            {
                _audioClip = value;
                _changes |= Properties.AudioClip;
            }
            get
            {
                return _audioClip;
            }
        }

        public bool BypassEffects
        {
            set
            {
                _bypassEffects = value;
                _changes |= Properties.BypassEffects;
            }
            get
            {
                return _bypassEffects;
            }
        }

        public bool BypassListenerEffects
        {
            set
            {
                _bypassListenerEffects = value;
                _changes |= Properties.BypassListenerEffects;
            }
            get
            {
                return _bypassListenerEffects;
            }
        }

        public bool BypassReverbZones
        {
            set
            {
                _bypassReverbZones = value;
                _changes |= Properties.BypassReverbZones;
            }
            get
            {
                return _bypassReverbZones;
            }
        }

        public Properties Changes
        {
            get
            {
                return _changes;
            }
        }

        public float DopplerLevel
        {
            set
            {
                _dopplerLevel = value;
                _changes |= Properties.DopplerLevel;
            }
            get
            {
                return _dopplerLevel;
            }
        }

        public bool Loop
        {
            set
            {
                _loop = value;
                _changes |= Properties.Loop;
            }
            get
            {
                return _loop;
            }
        }

        public float MaxDistance
        {
            set
            {
                _maxDistance = value;
                _changes |= Properties.MaxDistance;
            }
            get
            {
                return _maxDistance;
            }
        }

        public float MinDistance
        {
            set
            {
                _minDistance = value;
                _changes |= Properties.MinDistance;
            }
            get
            {
                return _minDistance;
            }
        }

        public bool Mute
        {
            set
            {
                _mute = value;
                _changes |= Properties.Mute;
            }
            get
            {
                return _mute;
            }
        }

        public AudioMixerGroup OutputAudioMixerGroup
        {
            set
            {
                _outputAudioMixerGroup = value;
                _changes |= Properties.OutputAudioMixerGroup;
            }
            get
            {
                return _outputAudioMixerGroup;
            }
        }

        public float Pitch
        {
            set
            {
                _pitch = value;
                _changes |= Properties.Pitch;
            }
            get
            {
                return _pitch;
            }
        }

        public bool PlayOnAwake
        {
            set
            {
                _playOnAwake = value;
                _changes |= Properties.PlayOnAwake;
            }
            get
            {
                return _playOnAwake;
            }
        }

        public int Priority
        {
            set
            {
                _priority = value;
                _changes |= Properties.Priority;
            }
            get
            {
                return _priority;
            }
        }

        public float ReverbZoneMix
        {
            set
            {
                _reverbZoneMix = value;
                _changes |= Properties.ReverbZoneMix;
            }
            get
            {
                return _reverbZoneMix;
            }
        }

        public AnimationCurve ReverbZoneMixCurve
        {
            set
            {
                _reverbZoneMixCurve = value;
                _changes |= Properties.ReverbZoneMixCurve;
            }
            get
            {
                return _reverbZoneMixCurve;
            }
        }

        public float SpatialBlend
        {
            set
            {
                _spatialBlend = value;
                _changes |= Properties.SpatialBlend;
            }
            get
            {
                return _spatialBlend;
            }
        }

        public AnimationCurve SpatialBlendCurve
        {
            set
            {
                _spatialBlendCurve = value;
                _changes |= Properties.SpatialBlendCurve;
            }
            get
            {
                return _spatialBlendCurve;
            }
        }

        public float Spread
        {
            set
            {
                _spread = value;
                _changes |= Properties.Spread;
            }
            get
            {
                return _spread;
            }
        }

        public AnimationCurve SpreadCurve
        {
            set
            {
                _spreadCurve = value;
                _changes |= Properties.SpreadCurve;
            }
            get
            {
                return _spreadCurve;
            }
        }

        public float StartingTime
        {
            set
            {
                _startingTime = value;
                _changes |= Properties.StartingTime;
            }
            get
            {
                return _startingTime;
            }
        }

        public float StereoPan
        {
            set
            {
                _stereoPan = value;
                _changes |= Properties.StereoPan;
            }
            get
            {
                return _stereoPan;
            }
        }

        public float Volume
        {
            set
            {
                _volume = value;
                _changes |= Properties.Volume;
            }
            get
            {
                return _volume;
            }
        }

        public AnimationCurve VolumeCurve
        {
            set
            {
                _volumeCurve = value;
                _changes |= Properties.VolumeCurve;
            }
            get
            {
                return _volumeCurve;
            }
        }

        public AudioRolloffMode VolumeRolloff
        {
            set
            {
                _volumeRolloff = value;
                _changes |= Properties.VolumeRolloff;
            }
            get
            {
                return _volumeRolloff;
            }
        }

        #endregion Properties

        #region Constructors

        public AudioSourceProperties()
        {
            _changes = Properties.None;

            _audioClip = null;
            _outputAudioMixerGroup = null;
            _mute = false;
            _bypassEffects = false;
            _bypassListenerEffects = false;
            _bypassReverbZones = false;
            _playOnAwake = true;
            _loop = false;
            _priority = 128;
            _volume = 1f;
            _pitch = 1f;
            _stereoPan = 0f;
            _spatialBlend = 0f;
            _reverbZoneMix = 0f;

            _dopplerLevel = 1f;
            _spread = 0f;
            _volumeRolloff = AudioRolloffMode.Linear;
            _minDistance = 1f;
            _maxDistance = 500f;
            _volumeCurve = null;
            _spatialBlendCurve = null;
            _spreadCurve = null;
            _reverbZoneMixCurve = null;
        }

        #endregion Constructors

        #region Methods

        public override void ApplyTo(GameObject gameObject)
        {
            ApplyPropertiesToComponent<AudioSource>(gameObject, this);
        }

        public void ApplyTo(AudioSource component)
        {
            if (Changes.IsAnyOf(Properties.AudioClip)) { component.clip = _audioClip; }
            if (Changes.IsAnyOf(Properties.StartingTime)) { component.time = _startingTime; }
            if (Changes.IsAnyOf(Properties.OutputAudioMixerGroup)) { component.outputAudioMixerGroup = _outputAudioMixerGroup; }
            if (Changes.IsAnyOf(Properties.Mute)) { component.mute = _mute; }
            if (Changes.IsAnyOf(Properties.BypassEffects)) { component.bypassEffects = _bypassEffects; }
            if (Changes.IsAnyOf(Properties.BypassListenerEffects)) { component.bypassListenerEffects = _bypassListenerEffects; }
            if (Changes.IsAnyOf(Properties.BypassReverbZones)) { component.bypassReverbZones = _bypassReverbZones; }
            if (Changes.IsAnyOf(Properties.PlayOnAwake)) { component.playOnAwake = _playOnAwake; }
            if (Changes.IsAnyOf(Properties.Loop)) { component.loop = _loop; }
            if (Changes.IsAnyOf(Properties.Priority)) { component.priority = _priority; }
            if (Changes.IsAnyOf(Properties.Volume)) { component.volume = _volume; }
            if (Changes.IsAnyOf(Properties.Pitch)) { component.pitch = _pitch; }
            if (Changes.IsAnyOf(Properties.StereoPan)) { component.panStereo = _stereoPan; }
            if (Changes.IsAnyOf(Properties.SpatialBlend)) { component.spatialBlend = _spatialBlend; }
            if (Changes.IsAnyOf(Properties.ReverbZoneMix)) { component.reverbZoneMix = _reverbZoneMix; }
            if (Changes.IsAnyOf(Properties.DopplerLevel)) { component.dopplerLevel = _dopplerLevel; }
            if (Changes.IsAnyOf(Properties.Spread)) { component.spread = _spread; }
            if (Changes.IsAnyOf(Properties.VolumeRolloff)) { component.rolloffMode = _volumeRolloff; }
            if (Changes.IsAnyOf(Properties.MinDistance)) { component.minDistance = _minDistance; }
            if (Changes.IsAnyOf(Properties.MaxDistance)) { component.maxDistance = _maxDistance; }
            if (Changes.IsAnyOf(Properties.VolumeCurve))
            {
                component.rolloffMode = AudioRolloffMode.Custom;
                component.SetCustomCurve(AudioSourceCurveType.CustomRolloff, _volumeCurve);
            }
            if (Changes.IsAnyOf(Properties.SpatialBlendCurve)) { component.SetCustomCurve(AudioSourceCurveType.SpatialBlend, _spatialBlendCurve); }
            if (Changes.IsAnyOf(Properties.SpreadCurve)) { component.SetCustomCurve(AudioSourceCurveType.Spread, _spreadCurve); }
            if (Changes.IsAnyOf(Properties.ReverbZoneMixCurve)) { component.SetCustomCurve(AudioSourceCurveType.ReverbZoneMix, _reverbZoneMixCurve); }
        }

        public void ApplyTo(BehaviourPoolAudioSource poolObject)
        {
            ApplyTo(poolObject.Behaviour);
        }

        public void CopyFrom(AudioSourceProperties original)
        {
            _changes = original._changes;

            _audioClip = original._audioClip;
            _startingTime = original._startingTime;
            _outputAudioMixerGroup = original._outputAudioMixerGroup;
            _mute = original._mute;
            _bypassEffects = original._bypassEffects;
            _bypassListenerEffects = original._bypassListenerEffects;
            _bypassReverbZones = original._bypassReverbZones;
            _playOnAwake = original._playOnAwake;
            _loop = original._loop;
            _priority = original._priority;
            _volume = original._volume;
            _pitch = original._pitch;
            _stereoPan = original._stereoPan;
            _spatialBlend = original._spatialBlend;
            _reverbZoneMix = original._reverbZoneMix;
            _dopplerLevel = original._dopplerLevel;
            _spread = original._spread;
            _volumeRolloff = original._volumeRolloff;
            _minDistance = original._minDistance;
            _maxDistance = original._maxDistance;
            _volumeCurve = original._volumeCurve;
            _spatialBlendCurve = original._spatialBlendCurve;
            _spreadCurve = original._spreadCurve;
            _reverbZoneMixCurve = original._reverbZoneMixCurve;
        }

        public void ResetChanges()
        {
            _changes = Properties.None;
        }

        #endregion Methods
    }
}
