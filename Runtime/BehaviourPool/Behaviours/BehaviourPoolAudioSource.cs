using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public class BehaviourPoolAudioSource : BehaviourPoolBehaviour<AudioSource>
    {
        #region Methods

        protected override void BehaviourPoolBehaviour_OnActivate()
        {
            Behaviour.Play();
        }

        protected override void BehaviourPoolBehaviour_OnDeactivate()
        {
            Behaviour.Stop();
        }

        protected override void BehaviourPoolBehaviour_OnUpdate(float deltaTime)
        {
            if (!Behaviour.isPlaying)
            {
                Deactivate();
            }
        }

        #endregion Methods
    }
}
