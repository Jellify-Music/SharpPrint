using SharpPrint.Algorithm;
using SharpPrint.lib;

namespace SharpPrint;

public class Example
{
    public static void Main()
    {
        const float sampleRate = 44100;
        
        Essentia.init();
        // Essentia.TestChroma();
        AlgorithmFactory factory = new AlgorithmFactory();
        MonoLoader loader = new MonoLoader(factory, "/home/brys0/Downloads/008 - NF - Paralyzed.flac", sampleRate);
        ChromaPrinter chroma = new ChromaPrinter(factory, 30, sampleRate);
        
        string signature = chroma.Scan(loader);
        
        Console.WriteLine("Generated signature for song: " + signature);
        
        Essentia.destroy();
    }
}