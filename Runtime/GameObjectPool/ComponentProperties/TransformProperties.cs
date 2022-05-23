using SorceressSpell.LibrarIoh.Collections;
using SorceressSpell.LibrarIoh.Core;
using System;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public class TransformProperties : ComponentProperties, IPoolObjectProperties<Transform>, ICopyFrom<TransformProperties>
    {
        #region Enums

        [Flags]
        public enum Properties
        {
            None = 0,
            Parent = 1 << 0,
            Position = 1 << 1,
            Rotation = 1 << 2,
            Scale = 1 << 3,
        }

        #endregion Enums

        #region Fields

        private Properties _changes;
        private bool _localSpace;
        private Transform _parent;
        private Vector3 _position;
        private Quaternion _rotation;
        private Vector3 _scale;

        #endregion Fields

        #region Properties

        public Properties Changes
        {
            get { return _changes; }
        }

        public bool LocalSpace
        {
            set { _localSpace = value; }
            get { return _localSpace; }
        }

        public Transform Parent
        {
            set
            {
                _parent = value;
                _changes |= Properties.Parent;
            }
            get
            {
                return _parent;
            }
        }

        public Vector3 Position
        {
            set
            {
                _position = value;
                _changes |= Properties.Position;
            }
            get
            {
                return _position;
            }
        }

        public Quaternion Rotation
        {
            set
            {
                _rotation = value;
                _changes |= Properties.Rotation;
            }
            get
            {
                return _rotation;
            }
        }

        public Vector3 Scale
        {
            set
            {
                _scale = value;
                _changes |= Properties.Scale;
            }
            get
            {
                return _scale;
            }
        }

        #endregion Properties

        #region Constructors

        public TransformProperties()
        {
            _changes = Properties.None;

            _parent = null;
            _localSpace = true;

            _position = Vector3.zero;
            _rotation = Quaternion.identity;
            _scale = Vector3.one;
        }

        #endregion Constructors

        #region Methods

        public override void ApplyTo(GameObject gameObject)
        {
            ApplyPropertiesToComponent<Transform>(gameObject, this);
        }

        public void ApplyTo(Transform component)
        {
            if (Changes.IsAnyOf(Properties.Parent)) { component.SetParent(Parent); }
            if (Changes.IsAnyOf(Properties.Position))
            {
                if (LocalSpace) { component.localPosition = Position; }
                else { component.position = Position; }
            }
            if (Changes.IsAnyOf(Properties.Rotation))
            {
                if (LocalSpace) { component.localRotation = Rotation; }
                else { component.rotation = Rotation; }
            }
            if (Changes.IsAnyOf(Properties.Scale)) { component.localScale = Scale; }
        }

        public void ResetChanges()
        {
            _changes = Properties.None;
        }

        public void CopyFrom(TransformProperties original)
        {
            _changes = original._changes;

            _parent = original._parent;
            _localSpace = original._localSpace;

            _position = original._position;
            _rotation = original._rotation;
            _scale = original._scale;
        }

        #endregion Methods
    }
}
