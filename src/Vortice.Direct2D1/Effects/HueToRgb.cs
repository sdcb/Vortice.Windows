﻿using System;

namespace Vortice.Direct2D1.Effects
{
    using Props = HueToRGBProperties;
    public class HueToRgb : ID2D1Effect
    {
        public HueToRgb(ID2D1DeviceContext deviceContext) : base(IntPtr.Zero)
        {
            deviceContext.CreateEffect(EffectGuids.HueToRgb, this);
        }

        public HueToRGBInputColorSpace InputColorSpace
        {
            set => SetValue((int)Props.InputColorSpace, value);
            get => GetEnumValue<HueToRGBInputColorSpace>((int)Props.InputColorSpace);
        }
    }
}
