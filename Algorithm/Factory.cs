using SharpPrint.lib;

namespace SharpPrint.Algorithm;

public class AlgorithmFactory
{
    internal long _ptr { get; private set; } = Essentia.createAlgorithmFactoryInstance();
}