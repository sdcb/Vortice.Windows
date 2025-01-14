﻿// Copyright © Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.Direct2D1.Effects;

public sealed class ConvolveMatrix : ID2D1Effect
{
    public ConvolveMatrix(ID2D1DeviceContext context)
        : base(context.CreateEffect(EffectGuids.ConvolveMatrix))
    {
    }

    public ConvolveMatrix(ID2D1EffectContext context)
        : base(context.CreateEffect(EffectGuids.ConvolveMatrix))
    {
    }

    public float KernelUnitLehgth
    {
        set => SetValue((int)ConvolveMatrixProperties.KernelUnitLength, value);
        get => GetFloatValue((int)ConvolveMatrixProperties.KernelUnitLength);
    }

    public ConvolveMatrixScaleMode ScaleMode
    {
        set => SetValue((int)ConvolveMatrixProperties.ScaleMode, value);
        get => GetEnumValue<ConvolveMatrixScaleMode>((int)ConvolveMatrixProperties.ScaleMode);
    }

    public int KernelSizeX
    {
        get => (int)GetUIntValue((int)ConvolveMatrixProperties.KernelSizeX);
        set => SetValue((int)ConvolveMatrixProperties.KernelSizeX, (uint)value);
    }

    public int KernelSizeY
    {
        get => (int)GetUIntValue((int)ConvolveMatrixProperties.KernelSizeY);
        set => SetValue((int)ConvolveMatrixProperties.KernelSizeY, (uint)value);
    }

    public unsafe float[] KernelMatrix
    {
        get
        {
            int size = KernelSizeX * KernelSizeY;
            float[] value = new float[size];
            fixed (float* valuePtr = value)
            {
                GetValue((int)ConvolveMatrixProperties.KernelMatrix, PropertyType.Blob, valuePtr, sizeof(float) * size);
            }

            return value;
        }
        set
        {
            var size = KernelSizeX * KernelSizeY;
            if (value.Length != size)
            {
                throw new ArgumentException();
            }

            fixed (void* valuePtr = value)
            {
                SetValue((int)ConvolveMatrixProperties.KernelMatrix, PropertyType.Blob, valuePtr, sizeof(float) * size);
            }
        }
    }

    public float Divisor
    {
        set => SetValue((int)ConvolveMatrixProperties.Divisor, value);
        get => GetFloatValue((int)ConvolveMatrixProperties.Divisor);
    }

    public float Bias
    {
        set => SetValue((int)ConvolveMatrixProperties.Bias, value);
        get => GetFloatValue((int)ConvolveMatrixProperties.Bias);
    }

    public Vector2 KernelOffset
    {
        set => SetValue((int)ConvolveMatrixProperties.KernelOffset, value);
        get => GetVector2Value((int)ConvolveMatrixProperties.KernelOffset);
    }

    public bool PreserveAlpha
    {
        set => SetValue((int)ConvolveMatrixProperties.PreserveAlpha, value);
        get => GetBoolValue((int)ConvolveMatrixProperties.PreserveAlpha);
    }

    public BorderMode BorderMode
    {
        set => SetValue((int)ConvolveMatrixProperties.BorderMode, value);
        get => GetEnumValue<BorderMode>((int)ConvolveMatrixProperties.BorderMode);
    }

    public bool ClampOutput
    {
        set => SetValue((int)ConvolveMatrixProperties.ClampOutput, value);
        get => GetBoolValue((int)ConvolveMatrixProperties.ClampOutput);
    }
}
