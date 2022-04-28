// Copyright © Aaron Sun, Amer Koleci, and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.DirectML;

public partial struct MaxPooling1OperatorDescription : IOperatorDescription, IOperatorDescriptionMarshal
{
    public OperatorType OperatorType => OperatorType.MaxPooling1;

    public TensorDescription InputTensor { get; set; }

    public TensorDescription OutputTensor { get; set; }

    public TensorDescription? OutputIndicesTensor { get; set; }

    public uint DimensionCount { get; set; }

    public uint[] Strides { get; set; }

    public uint[] WindowSize { get; set; }

    public uint[] StartPadding { get; set; }

    public uint[] EndPadding { get; set; }

    #region Marshal
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct __Native
    {
        public IntPtr InputTensor;
        public IntPtr OutputTensor;
        public IntPtr OutputIndicesTensor;
        public uint DimensionCount;
        public IntPtr Strides;
        public IntPtr WindowSize;
        public IntPtr StartPadding;
        public IntPtr EndPadding;
    }

    unsafe IntPtr IOperatorDescriptionMarshal.__MarshalAlloc()
    {
        __Native* @ref = UnsafeUtilities.Alloc<__Native>();

        @ref->InputTensor = InputTensor.__MarshalAlloc();
        @ref->OutputTensor = OutputTensor.__MarshalAlloc();
        @ref->OutputIndicesTensor = (OutputIndicesTensor != null) ? OutputIndicesTensor.Value.__MarshalAlloc() : IntPtr.Zero;
        @ref->DimensionCount = DimensionCount;
        @ref->Strides = new(UnsafeUtilities.AllocWithData(Strides));
        @ref->WindowSize = new(UnsafeUtilities.AllocWithData(WindowSize));
        @ref->StartPadding = new(UnsafeUtilities.AllocWithData(StartPadding));
        @ref->EndPadding = new(UnsafeUtilities.AllocWithData(EndPadding));

        return new(@ref);
    }

    unsafe void IOperatorDescriptionMarshal.__MarshalFree(ref IntPtr pDesc)
    {
        var @ref = (__Native*)pDesc;

        InputTensor.__MarshalFree(ref @ref->InputTensor);
        OutputTensor.__MarshalFree(ref @ref->OutputTensor);

        if (OutputIndicesTensor != null)
        {
            OutputIndicesTensor.Value.__MarshalFree(ref @ref->OutputIndicesTensor);
        }

        UnsafeUtilities.Free(@ref->Strides);
        UnsafeUtilities.Free(@ref->WindowSize);
        UnsafeUtilities.Free(@ref->StartPadding);
        UnsafeUtilities.Free(@ref->EndPadding);
        UnsafeUtilities.Free(@ref);
    }
    #endregion

    public static implicit operator OperatorDescription(MaxPooling1OperatorDescription description)
    {
        return new(description);
    }
}