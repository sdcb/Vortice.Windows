// Copyright © Aaron Sun, Amer Koleci, and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.DirectML;

public partial struct ActivationReluGradOperatorDescription : IOperatorDescription, IOperatorDescriptionMarshal
{
    public OperatorType OperatorType => OperatorType.ActivationReluGrad;

    public TensorDescription InputTensor { get; set; }

    public TensorDescription InputGradientTensor { get; set; }

    public TensorDescription OutputGradientTensor { get; set; }

    #region Marshal
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct __Native
    {
        public IntPtr InputTensor;
        public IntPtr InputGradientTensor;
        public IntPtr OutputGradientTensor;
    }

    unsafe IntPtr IOperatorDescriptionMarshal.__MarshalAlloc()
    {
        __Native* @ref = UnsafeUtilities.Alloc<__Native>();

        @ref->InputTensor = InputTensor.__MarshalAlloc();
        @ref->InputGradientTensor = InputGradientTensor.__MarshalAlloc();
        @ref->OutputGradientTensor = OutputGradientTensor.__MarshalAlloc();

        return new(@ref);
    }

    unsafe void IOperatorDescriptionMarshal.__MarshalFree(ref IntPtr pDesc)
    {
        var @ref = (__Native*)pDesc;

        InputTensor.__MarshalFree(ref @ref->InputTensor);
        InputGradientTensor.__MarshalFree(ref @ref->InputGradientTensor);
        OutputGradientTensor.__MarshalFree(ref @ref->OutputGradientTensor);

        UnsafeUtilities.Free(@ref);
    }
    #endregion

    public static implicit operator OperatorDescription(ActivationReluGradOperatorDescription description)
    {
        return new(description);
    }
}