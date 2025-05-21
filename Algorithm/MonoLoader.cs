using SharpPrint.lib;

namespace SharpPrint.Algorithm;

public class MonoLoader(AlgorithmFactory factory, string file, float sampleRate)
{
    internal long _ptr { get; private set; } = Essentia.AlgorithmCreateMonoLoader(factory._ptr, file, sampleRate);
}