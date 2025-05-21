using SharpPrint.Algorithm;
using SharpPrint.lib;

namespace SharpPrint;

public class Example
{
    public static void Main()
    {
        const float sampleRate = 44100;
        
        Essentia.init();
        AlgorithmFactory factory = new AlgorithmFactory();
        MonoLoader loader = new MonoLoader(factory, "/whatever track.mp3", sampleRate);
        ChromaPrinter chroma = new ChromaPrinter(factory, 3, sampleRate);

        string signature = chroma.Scan(loader);
        
        Console.WriteLine("Generated signature for song: " + signature);
        
        Essentia.destroy();
    }
}