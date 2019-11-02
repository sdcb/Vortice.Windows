﻿using System;

namespace Vortice.Direct2D1.Effects
{
    using Props = HueRotationProperties;
    public class HueRotation : ID2D1Effect
    {
        public HueRotation(ID2D1DeviceContext deviceContext) : base(IntPtr.Zero)
        {
            deviceContext.CreateEffect(EffectGuids.HueRotation, this);
        }

        public float Angle
        {
            set => SetValue((int)Props.Angle, value);
            get => GetFloatValue((int)Props.Angle);
        }
    }
}
